using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.TurnoFunc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class TurnoFuncController : Controller
    {
        TurnoFuncRepositoryEF repositoryEF = new TurnoFuncRepositoryEF();
        TurnoRepositoryEF turnoRepositoryEF = new TurnoRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepositoryEF = new FuncionarioRepositoryEF();
        public ActionResult Index()
        {
            var turnosF = repositoryEF.ListarTodos().ToTurnoFuncVM();
            return View(turnosF);
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Funcionarios = funcionarioRepositoryEF.ListarTodos();
            ViewBag.Turnos = turnoRepositoryEF.ListarTodos();
            TurnoFuncAddEditVM turno = new TurnoFuncAddEditVM();
            return View(turno);
        }
        [HttpPost]
        public ActionResult Add(TurnoFuncAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                repositoryEF.Add(Entity.ToFuncionarioTurno());
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
    }
}