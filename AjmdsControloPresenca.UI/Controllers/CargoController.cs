using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Cargo;
using PagedList;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllersa
{
    [Authorize]
    public class CargoController : Controller
    {
        CargoRepositoryEF cargoRepository = new CargoRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var cargos = cargoRepository.ListarTodos().ToCargoIndexVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(cargos.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            CargoIndexVM cargo = new CargoIndexVM();
            return View(cargo);
        }
        [HttpPost]
        public ActionResult Add(CargoIndexVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                cargoRepository.Add(Entity.ToCargo());
               TempData["Mensagem"] = "Cargo inserido com sucesso!";
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
               TempData["Mensagem"] = err.ToString();
                return View(Entity);
            }
        }
        [HttpGet]
        public ActionResult Edit(short? Id)
        {
            try
            {
                if (Id is null) return RedirectToAction("Index");
                var cargo = cargoRepository.ListarPorId(Id).ToCargoVM();
                return View(cargo);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(CargoIndexVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                cargoRepository.Alter(Entity.ToCargo());
               TempData["Mensagem"] = "Cargo editado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(short? Id)
        {
            try
            {
                if (Id is null) return RedirectToAction("Index");
                cargoRepository.Delete(cargoRepository.ListarPorId(Id));
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
               TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction("Index");
        }
    }
}