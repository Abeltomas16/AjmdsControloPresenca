using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Departamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        DepartamentoRepositoryEF departamentoRepository = new DepartamentoRepositoryEF();
        public ActionResult Index()
        {
            var departamentos = departamentoRepository.ListarTodos().ToDepartamentoVM();
            return View(departamentos);
        }
    }
}