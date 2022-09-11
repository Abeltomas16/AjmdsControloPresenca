using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.TurnoFunc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class TurnoFuncController : Controller
    {
        TurnoFuncRepositoryEF repositoryEF = new TurnoFuncRepositoryEF();
        public ActionResult Index()
        {
            var turnosF = repositoryEF.ListarTodos().ToTurnoFuncVM();
            return View(turnosF);
        }
    }
}