using AjmdsControloPresenca.Domain.Entities;
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
        DepartamentoRepositoryEF DepartamentoRepository = new DepartamentoRepositoryEF();
        public ActionResult Index()
        {
            var funcionarios=repositoryEF.ListarTodos();
            return View(funcionarios);
        }
        public ActionResult Add()
        {
            Funcionario funcionario = new Funcionario();
            var departamento = DepartamentoRepository.ListarTodos();

            //Cargos
            //Genero
            //Estado Civil
            return View(funcionario);
        }
    }
}