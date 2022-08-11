using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Usuario;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        UsuarioRepositoryEF usuarioRepository = new UsuarioRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepository = new FuncionarioRepositoryEF();
        public ActionResult Index()
        {
            var usuarios = usuarioRepository.ListarTodos().ToUsuarioIndexVM();
            return View(usuarios);
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
            if (Id == null) return RedirectToAction("Index");
            var user = usuarioRepository.ListarPorIdFunconario(Id.Value).ToUsuarioAddEdit();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UsuarioAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                var user = Entity.ToUsuario();
                usuarioRepository.Alter(user);
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    System.Console.WriteLine("Entity do tipo \"{0}\" in state \"{1}\" causou erro:", eve.Entry.Entity.GetType().Name, eve.ValidationErrors);
                    foreach (var item in eve.ValidationErrors)
                    {
                        System.Console.WriteLine("- Propiedade: \"{0}\", Error: \"{1}\"", item.PropertyName, item.ErrorMessage);
                    }
                }
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
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    System.Console.WriteLine("Entity do tipo \"{0}\" in state \"{1}\" causou erro:", eve.Entry.Entity.GetType().Name, eve.ValidationErrors);
                    foreach (var item in eve.ValidationErrors)
                    {
                        System.Console.WriteLine("- Propiedade: \"{0}\", Error: \"{1}\"", item.PropertyName, item.ErrorMessage);
                    }
                }
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
            if (Id == null) return RedirectToAction("Index");
            usuarioRepository.Delete(usuarioRepository.ListarPorId(Id));
            return RedirectToAction("Index");
        }
    }
}