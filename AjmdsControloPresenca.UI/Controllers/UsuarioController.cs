using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Usuario;
using PagedList;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        UsuarioRepositoryEF usuarioRepository = new UsuarioRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepository = new FuncionarioRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var usuarios = usuarioRepository.ListarTodos().ToUsuarioIndexVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(usuarios.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            var usuario = new UsuarioAddEditVM();
            return View(usuario);
        }
        [HttpGet]
        public ActionResult Edit(short? Id)
        {
            try
            {
                if (Id == null) return RedirectToAction("Index");
                var user = usuarioRepository.ListarPorIdFunconario(Id.Value).ToUsuarioAddEdit();
                return View(user);
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
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(UsuarioAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                var user = Entity.ToUsuario();
                usuarioRepository.Alter(user);
                TempData["Mensagem"] = "Usuário editado com sucesso";
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
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(UsuarioAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                var user = Entity.ToUsuario();

                var funcionario = funcionarioRepository.ListarBI(user.Nome);
                if (funcionario == null) ModelState.AddModelError("NomeFuncionario", "Funcionário não existe");

                var usuarios = usuarioRepository.ListarTodos();
                var exists = usuarios.Where(u => u.Funcionario.Bilhete.ToLower() == user.Nome).FirstOrDefault();
                if (exists != null) ModelState.AddModelError("NomeFuncionario", "Funcionário já cadastrado");

                usuarioRepository.Add(user);
                TempData["Mensagem"] = "Usuário cadastrado com sucesso";
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
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Search(string Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var funcionario = funcionarioRepository.ListarBI(Id);
            if (funcionario == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            var usuarios = usuarioRepository.ListarTodos();
            var exists = usuarios.Where(u => u.Funcionario.Bilhete.ToLower() == Id).FirstOrDefault();

            if (exists != null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.Conflict);

            return Json(new { FuncionarioId = funcionario.Id, NomeFuncionario = funcionario.Nome, Bilhete = funcionario.Bilhete.ToUpper().Trim() }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            try
            {
                if (Id == null) return RedirectToAction("Index");
                usuarioRepository.Delete(usuarioRepository.ListarPorId(Id));
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
            return RedirectToAction("Index");
        }
    }
}