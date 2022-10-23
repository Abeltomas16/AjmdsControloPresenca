using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Departamento;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
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
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity do tipo \"{0}\" in state \"{1}\" causou erro:", eve.Entry.Entity.GetType().Name, eve.ValidationErrors);
                    foreach (var item in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Propiedade: \"{0}\", Error: \"{1}\"", item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(short? Id)
        {
            if (Id is null) return RedirectToAction("Index");
            var departamento = departamentoRepository.ListarPorId(Id).ToDepartamentoVM();
            return View(departamento);
        }
        [HttpPost]
        public ActionResult Edit(DepartamentoAddEditVM Entity)
        {
            if (!ModelState.IsValid) return View(Entity);
            departamentoRepository.Alter(Entity.ToDepartamento());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(short? Id)
        {
            if (Id is null) return RedirectToAction("Index");
            departamentoRepository.Delete(departamentoRepository.ListarPorId(Id));
            return RedirectToAction("Index");
        }
    }
}