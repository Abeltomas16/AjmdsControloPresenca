using AjmdsControloPresenca.Domain.Entities;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.TurnoFunc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class TurnoFuncController : Controller
    {
        TurnoFuncRepositoryEF repositoryEF = new TurnoFuncRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var turnosF = repositoryEF.ListarTodos().ToTurnoFuncVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(turnosF.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            TurnoFuncAddEditVM turnof = new TurnoFuncAddEditVM();
            PreencherSelects();
            return View(turnof);
        }
        [HttpPost]
        public ActionResult Add(TurnoFuncAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                repositoryEF.Add(Entity.ToFuncionarioTurno());
                TempData["Mensagem"] = "Turno funcionário cadastrado com sucesso";
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
        public ActionResult Edit(int? Id)
        {
            try
            {
                if (Id == null) return RedirectToAction("Index");
                TurnoFuncAddEditVM turnof = repositoryEF.ListarPorId(Id.Value).ToFuncionarioTurnoVM();
                PreencherSelects();
                return View(turnof);
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
        public ActionResult Edit(TurnoFuncAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                repositoryEF.Alter(Entity.ToFuncionarioTurno());
                TempData["Mensagem"] = "Turno funcionário editado com sucesso";
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
            return RedirectToAction("Index");
        }
        private void PreencherSelects()
        {
            TurnoRepositoryEF turnoRepositoryEF = new TurnoRepositoryEF();
            FuncionarioRepositoryEF funcionarioRepositoryEF = new FuncionarioRepositoryEF();
            ViewBag.Funcionarios = funcionarioRepositoryEF.ListarTodos();
            ViewBag.Turnos = turnoRepositoryEF.ListarTodos();
        }
    }
}