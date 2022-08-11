using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Turno;
using System;
using System.Collections.Generic;
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
    }
}