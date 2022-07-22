using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace AjmdsControloPresenca.UI.Controllers
{
    public class LoginController : Controller
    {
        private UsuarioRepositoryEF RepositoryEF = new UsuarioRepositoryEF();

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            LoginViewModel login = new LoginViewModel { GoUrl = ReturnUrl };
            return View(login);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            try
            {
                var usuario = RepositoryEF.ListarPorNome(login.Nome);
                if (usuario == null)
                {
                    ModelState.AddModelError("Nome", "Email incorreto");
                }
                else
                {
                    if (usuario.Senha != login.Senha)
                        ModelState.AddModelError("Senha", "Senha incorreta");
                }

                if (ModelState.IsValid)
                {
                    FormsAuthentication.SetAuthCookie(login.Nome, login.Logado);
                    if (!string.IsNullOrEmpty(login.GoUrl) &&
                       Url.IsLocalUrl(login.GoUrl))
                        return Redirect(login.GoUrl);

                    return RedirectToAction("Index", "Home");
                }
                return View(login);
            }
            catch (Exception exc)
            {
                ModelState.AddModelError("ErroLogin", exc.Message);
                return View(login);
            }
        }
    }
}