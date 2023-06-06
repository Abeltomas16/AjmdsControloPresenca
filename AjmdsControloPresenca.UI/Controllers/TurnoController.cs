using AjmdsControloPresenca.Domain.Contract;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Funcionario;
using AjmdsControloPresenca.UI.Models.Turno;
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
    public class TurnoController : Controller
    {
        TurnoRepositoryEF turnoRepositoryEF = new TurnoRepositoryEF();
        public ActionResult Index(int? pagina)
        {
            try
            {
                var turnos = turnoRepositoryEF.ListarTodos().ToTurnoVM();
                int numeroRegistros = 10;
                int numeroPagina = (pagina ?? 1);
                return View(turnos.ToPagedList(numeroPagina, numeroRegistros));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            TurnoAddEditVM turno = new TurnoAddEditVM();
            return View(turno);
        }
        [HttpPost]
        public ActionResult Add(TurnoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                turnoRepositoryEF.Add(Entity.ToTurno());
                TempData["Mensagem"] = "Turno cadastrado com sucesso";
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
                var turno = turnoRepositoryEF.ListarPorId(Id).ToTurnoVM();
                return View(turno);
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
        public ActionResult Edit(TurnoAddEditVM Entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(Entity);
                turnoRepositoryEF.Alter(Entity.ToTurno());
                TempData["Mensagem"] = "Turno editado com sucesso";
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
                turnoRepositoryEF.Delete(turnoRepositoryEF.ListarPorId(Id));
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