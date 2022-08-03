using AjmdsControloPresenca.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        FuncionarioRepositoryEF repositoryEF = new FuncionarioRepositoryEF();
        public ActionResult Index()
        {
            var funcionarios=repositoryEF.ListarTodos();
            return View(funcionarios);
        }
    }
}