using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Funcionario;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web.Mvc;
 
namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        FuncionarioRepositoryEF repositoryEF = new FuncionarioRepositoryEF();
        DepartamentoRepositoryEF _departamentoRepository = new DepartamentoRepositoryEF();
        CargoRepositoryEF _cargosRepositoryEF = new CargoRepositoryEF();
        GeneroRepositoryEF _generoRepositoryEF = new GeneroRepositoryEF();
        EstadoCivilRepositoryEF _estadoCivilRepository = new EstadoCivilRepositoryEF();
        UsuarioRepositoryEF _usuarioRepository = new UsuarioRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                IEnumerable<FuncionarioIndexVM> funcionarios = repositoryEF.ListarTodos().ToFuncionarioIndex();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(funcionarios.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            try
            {
                var id = repositoryEF.ListarTodos().Max(i => i.Id) + 1;
                FuncionarioAddEditVM funcionario = new FuncionarioAddEditVM();
                funcionario.Id = (short)id;
                PreencherSelects();
                return View(funcionario);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpPost]
        public ActionResult Add(FuncionarioAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                if (Entity.Id >= 240)
                {
                    ModelState.AddModelError("Id", "O id tem que ser menor que 240");
                    return View(Entity);
                }
                IEnumerable<FuncionarioIndexVM> funcionarios = repositoryEF.ListarTodos().ToFuncionarioIndex();
                if (funcionarios.Where(f => f.Id == Entity.Id).Count() > 0)
                {
                    ModelState.AddModelError("Id", "Este id Já existe");
                    return View(Entity);
                }
                repositoryEF.Add(Entity.ToFuncionario());
                TempData["Mensagem"] = "Funcionário cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public ActionResult Edit(int? Id)
        {
            try
            {
                if (Id == null) return RedirectToAction("Index");
                FuncionarioAddEditVM funcionarioVM = repositoryEF.ListarPorId(Id).ToFuncionarioAddEdit();
                PreencherSelects();
                return View(funcionarioVM);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpPost]
        public ActionResult Edit(FuncionarioAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                repositoryEF.Alter(Entity.ToFuncionario());
                TempData["Mensagem"] = "Funcionário editado com sucesso";
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            try
            {
                if (Id == null) return RedirectToAction("Index");
                repositoryEF.Delete(repositoryEF.ListarPorId(Id));
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public ActionResult UserInfo()
        {
            try
            {
                string _nome = User.Identity.Name;
                FuncionarioInfoVM funcionario = _usuarioRepository.ListarPorNome(_nome).ToFuncionarioInfoVM();
                return View(funcionario);
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder err = new StringBuilder();
                foreach (var eve in ex.EntityValidationErrors)
                {
                    foreach (var item in eve.ValidationErrors)
                    {
                        err.Append(item.ErrorMessage);
                    }
                }
                TempData["Mensagem"] = err.ToString();
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        private void PreencherSelects()
        {
            var cargos = _cargosRepositoryEF.ListarTodos();
            var genero = _generoRepositoryEF.ListarTodos();
            var estadoCivil = _estadoCivilRepository.ListarTodos();
            var departamento = _departamentoRepository.ListarTodos();
            ViewBag.Departamentos = departamento;
            ViewBag.Cargos = cargos;
            ViewBag.Genero = genero;
            ViewBag.EstadoCivil = estadoCivil;
        }
    }
}