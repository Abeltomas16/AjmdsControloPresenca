using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Usuario;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        UsuarioRepositoryEF usuarioRepository = new UsuarioRepositoryEF();
        public ActionResult Index()
        {
            var usuarios = usuarioRepository.ListarTodos().ToUsuarioIndexVM();
            return View(usuarios);
        }
    }
}