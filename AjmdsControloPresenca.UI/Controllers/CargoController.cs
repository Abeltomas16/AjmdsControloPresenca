using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllersa
{
    [Authorize]
    public class CargoController : Controller
    {
        CargoRepositoryEF cargoRepository = new CargoRepositoryEF();
        public ActionResult Index()
        {
            var cargos = cargoRepository.ListarTodos().ToCargoIndexVM();
            return View(cargos);
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