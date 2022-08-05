using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Usuario;
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
            var usuarios = usuarioRepository.ListarTodos().ToUsuarioIndexVM();
            return View(usuarios);
        }
        [HttpGet]
        public ActionResult Search(string Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var funcionario = funcionarioRepository.ListarBI(Id);
            if(funcionario ==null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            var usuarios = usuarioRepository.ListarTodos();
            var exists = usuarios.Where(u => u.Funcionario.Bilhete.ToLower() == Id).FirstOrDefault();

            if (exists != null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.Conflict);
            
            return Json(new { FuncionarioId = funcionario.Id, NomeFuncionario = funcionario.Nome },JsonRequestBehavior.AllowGet);
        }
    }
}