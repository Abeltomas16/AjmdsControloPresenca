using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Domain.Entities.Relatorio;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Afastamento;
using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
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
        public ActionResult Edit(short? Id)
        {
            try
            {
                if (Id is null) return RedirectToAction("Index");
                var afasta = afastamentoRepositoryEF.ListarPorId(Id).ToAfastamentoVM();
                PreencherSelects();
                return View(afasta);
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
        public ActionResult Edit(AfastamentoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                afastamentoRepositoryEF.Alter(Entity.ToAfastamento());
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
        public ActionResult Delete(short? Id)
        {
            try
            {
                if (Id is null) return RedirectToAction("Index");
                afastamentoRepositoryEF.Delete(afastamentoRepositoryEF.ListarPorId(Id));
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
        private void PreencherSelects()
        {
            FuncionarioRepositoryEF funcionarioRepositoryEF = new FuncionarioRepositoryEF();
            ISituacaoRepositoryEF situacaoRepositoryEF = new ISituacaoRepositoryEF();
            ViewBag.Funcionarios = funcionarioRepositoryEF.ListarTodos();
            ViewBag.Situacao = situacaoRepositoryEF.ListarTodos();
        }
        [HttpGet]
        public ActionResult GerarPdf(short id)
        {
            try
            {

                var lista = afastamentoRepositoryEF.ListarPoId(id);
                 var funcionario = funcionarioRepository.ListarTudoPorId(lista.FuncionarioId);
                ViewBag.NomeFuncionario = string.Concat(funcionario.Nome, " ", funcionario.Nome);
                ViewBag.Bilhete = funcionario.Bilhete;
                ViewBag.CargoFuncionario = funcionario.Cargo.Descricao;
                ViewBag.Data = string.Concat(string.Format("{0:dd/MM/yyyy}", lista.DataAfastamento), " a ", string.Format("{0:dd/MM/yyyy}", lista.DataTermino));
                ViewBag.Situacao = lista.Situacao.Descricao;
                ViewBag.Obs = lista.Observacao;

                var relatorioPdf = new ViewAsPdf
                {
                    ViewName = "../Relatorio/RelatorioAfastamento",
                    IsGrayScale = true
                };
                return relatorioPdf;
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
                return RedirectToAction("Index");
            }
        }
    }
}