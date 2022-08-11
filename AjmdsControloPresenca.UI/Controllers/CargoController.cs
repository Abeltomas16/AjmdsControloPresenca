using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Cargo;
using System;
using System.Collections.Generic;
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
    }
}