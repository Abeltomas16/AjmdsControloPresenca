using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Departamento;
using PagedList;
using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        DepartamentoRepositoryEF departamentoRepository = new DepartamentoRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var departamentos = departamentoRepository.ListarTodos().ToDepartamentoVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(departamentos.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            DepartamentoAddEditVM departamento = new DepartamentoAddEditVM();
            return View(departamento);
        }
        [HttpPost]
        public ActionResult Add(DepartamentoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                departamentoRepository.Add(Entity.ToDepartamento());
                TempData["Mensagem"] = "Departamento cadastrado com sucesso!";
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
                var departamento = departamentoRepository.ListarPorId(Id).ToDepartamentoVM();
                return View(departamento);
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
        public ActionResult Edit(DepartamentoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                departamentoRepository.Alter(Entity.ToDepartamento());
                TempData["Mensagem"] = "Departamento editado com sucesso!";
                ViewBag.Mensagem = "Mensagem de sucesso!";
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
        public ActionResult Delete(short? Id)
        {
            try
            {
                if (Id is null) return RedirectToAction("Index");
                departamentoRepository.Delete(departamentoRepository.ListarPorId(Id));
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