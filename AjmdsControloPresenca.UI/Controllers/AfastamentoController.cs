using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Afastamento;
using PagedList;
using System;
using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class AfastamentoController : Controller
    {
        AfastamentoRepositoryEF afastamentoRepositoryEF = new AfastamentoRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepository = new FuncionarioRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var afastamentos = afastamentoRepositoryEF.ListarTodos().ToAfastamentoIndexVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(afastamentos.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            AfastamentoAddEditVM afastamento = new AfastamentoAddEditVM();
            PreencherSelects();
            return View(afastamento);
        }
        [HttpPost]
        public ActionResult Add(AfastamentoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                if (Convert.ToDateTime(Entity.DataTermino) < Convert.ToDateTime( Entity.DataAfastamento))
                {
                    ModelState.AddModelError("DataTermino", "Data término deve ser maior que a data de afastamento");
                    PreencherSelects();
                    return View(Entity);
                }
                Afastamento afastamento_ = Entity.ToAfastamento();
                
                if (afastamentoRepositoryEF.AtestadoDataExiste(afastamento_))
                {
                    ModelState.AddModelError("DataAfastamento", "Já existem situações marcadas para este funcionário neste intervalo");
                    ModelState.AddModelError("DataTermino", "Já existem situações marcadas para este funcionário neste intervalo");
                    PreencherSelects();
                    return View(Entity);
                }

                afastamentoRepositoryEF.Add(afastamento_);
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity do tipo \"{0}\" in state \"{1}\" causou erro:", eve.Entry.Entity.GetType().Name, eve.ValidationErrors);
                    foreach (var item in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Propiedade: \"{0}\", Error: \"{1}\"", item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(short? Id)
        {
            if (Id is null) return RedirectToAction("Index");
            var afasta = afastamentoRepositoryEF.ListarPorId(Id).ToAfastamentoVM();
            PreencherSelects();
            return View(afasta);
        }
        [HttpPost]
        public ActionResult Edit(AfastamentoAddEditVM Entity)
        {
            if (!ModelState.IsValid) return View(Entity);
            afastamentoRepositoryEF.Alter(Entity.ToAfastamento());
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(short? Id)
        {
            if (Id is null) return RedirectToAction("Index");
            afastamentoRepositoryEF.Delete(afastamentoRepositoryEF.ListarPorId(Id));
            return RedirectToAction("Index");
        }
        private void PreencherSelects()
        {
            FuncionarioRepositoryEF funcionarioRepositoryEF = new FuncionarioRepositoryEF();
            ISituacaoRepositoryEF situacaoRepositoryEF = new ISituacaoRepositoryEF();
            ViewBag.Funcionarios = funcionarioRepositoryEF.ListarTodos();
            ViewBag.Situacao = situacaoRepositoryEF.ListarTodos();
        }
    }
}