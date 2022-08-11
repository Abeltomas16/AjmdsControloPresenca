using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Turno;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class TurnoController : Controller
    {
        TurnoRepositoryEF turnoRepositoryEF = new TurnoRepositoryEF();
        public ActionResult Index()
        {
            var turnos = turnoRepositoryEF.ListarTodos().ToTurnoVM();
            return View(turnos);
        }
        [HttpGet]
        public ActionResult Add()
        {
            TurnoAddEditVM turno = new TurnoAddEditVM();
            return View(turno);
        }
        [HttpPost]
         public ActionResult Add(TurnoAddEditVM Entity)
         {
             try
             {
                 if (!ModelState.IsValid) return View(Entity);
                 turnoRepositoryEF.Add(Entity.ToTurno());
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