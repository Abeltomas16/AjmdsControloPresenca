using AjmdsControloPresenca.Domain.Entities.Relatorio;
using AjmdsControloPresenca.Infra.Repository;
using AjmdsControloPresenca.UI.Models.Justificar;
using AjmdsControloPresenca.UI.Models.Relatorio;
using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class ApuramentoController : Controller
    {
        PresencaRepositoryEF presencaRepository = new PresencaRepositoryEF();
        RelatorioRepositorioEF relatorioRepositorioEF = new RelatorioRepositorioEF();
        TurnoFuncRepositoryEF turnoRepositoryEF = new TurnoFuncRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepository = new FuncionarioRepositoryEF();
        IEnumerable<RelFolhaPresenca> Folha = null;
        // GET: Apuramento
        public ActionResult Index()
        {
            try
            {
                PreencherSelects();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Index(RelPresencaVM Entity)
        {
            try
            {
                PreencherSelects();
                if (!ModelState.IsValid) return View(Entity);
                DateTime DataIn = DateTime.Parse(Entity.DataInicial);
                DateTime DataFim = DateTime.Parse(Entity.DataFinal);
                if (DataIn > DataFim)
                {
                    ModelState.AddModelError("DataInicial", "Data Inicial não pode ser maior que data final");
                    return View(Entity);
                }
                Folha = relatorioRepositorioEF.Listar(Entity.FuncionarioId, DataIn, DataFim);
                if (Folha.Count() <= 0)
                {
                    ModelState.AddModelError("FuncionarioId", "Nenhum registro encontrado neste período para este funcionário");
                    return View(Entity);
                }
                ViewBag.Funcionario = Entity.FuncionarioId;
                ViewBag.Title = "Presença";
                ViewBag.Inicio = DataIn;
                ViewBag.Fim = DataFim;
                return View("Presenca", Folha);
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
                return RedirectToAction("Index");
            }
        }
        public ActionResult Justificar(int id)
        {
            try
            {
                var JustificarVM = presencaRepository.ListarPorId(id).ToJustificativaVM();
                return View(JustificarVM);
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
                return RedirectToAction(nameof(Index), "Home");
            }
        }
        [HttpPost]
        public ActionResult Justificar(JustificarVM entity)
        {
            try
            {
                if (!ModelState.IsValid) return View(entity);
                var presenca = presencaRepository.ListarPorId(entity.Id);
                var JustificarVM = presenca.ToJustificativaVM();
                if (presenca == null || JustificarVM.Data != entity.Data)
                {
                    ModelState.AddModelError("Data", "Data inválida não encontrada");
                    return View(entity);
                }
                var PresencaAlter = entity.ToJustificativaPresenca(presenca.FuncionarioId);
                presenca.Entrada = PresencaAlter.Entrada;
                presenca.Saida = PresencaAlter.Saida;

                if (presenca.Saida <= presenca.Entrada)
                {
                    ModelState.AddModelError("HoraFinal", "A hora final deve ser maior que a hora inicial");
                    return View(entity);
                }

                presenca.Cadastro = PresencaAlter.Cadastro;
                presencaRepository.Alter(presenca);
                return RedirectToAction(nameof(Index), "Home");
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
                return RedirectToAction(nameof(Index), "Home");
            }
        }
        public string RetornaDiaSemana(ushort dia)
        {
            string[] DiasSemana = new string[] { "DOM", "SEG", "TER", "QUA", "QUI", "SEX", "SAB" };
            return DiasSemana[dia];
        }
        [HttpGet]
        public ActionResult GerarPdf(short id, DateTime Inicio, DateTime Fim)
        {
            try
            {
                var funcionario = funcionarioRepository.ListarTudoPorId(id);
                var lista = relatorioRepositorioEF.Listar(id, Inicio, Fim);
                var qtd = Fim.Day - Inicio.Day;
                int dia = Inicio.Day;
                List<RelFolhaPresenca> folhaPresencas = new List<RelFolhaPresenca>();
                for (int i = 0; i <= qtd; i++)
                {
                    var _Semana = RetornaDiaSemana((ushort)(DateTime.Parse(string.Concat(dia, "/", Inicio.Month, "/", Inicio.Year, " ")).DayOfWeek));
                    RelFolhaPresenca f = new RelFolhaPresenca()
                    {
                        Dia = dia,
                        DiaMes = string.Concat(dia, "/", Inicio.Month),
                        Semana = _Semana,
                        Marcacoes = "DSR",
                        DataCompleta = "",
                        Falta = 0,
                        HorasTrabalhadas = 0,
                        FuncionarioId = id,
                        Id = 0
                    };
                    folhaPresencas.Add(f);
                    dia++;
                }
                foreach (RelFolhaPresenca p in lista)
                {
                    var index = folhaPresencas.FindIndex(f => f.Dia == p.Dia);
                    folhaPresencas[index] = p;
                }
                ViewBag.NomeFuncionario = string.Concat(funcionario.Nome, " ", funcionario.SobreNome);
                ViewBag.CodigoFuncionario = string.Concat("00", funcionario.Id);
                ViewBag.CargoFuncionario = funcionario.Cargo.Descricao;
                ViewBag.DepartamentoFuncionario = funcionario.Departamento.Descricao;
                ViewBag.BIFuncionario = funcionario.Bilhete;
                ViewBag.Inicio = Inicio.ToShortDateString();
                ViewBag.Fim = Fim.ToShortDateString();
                ViewBag.TotalFaltas = folhaPresencas.Sum(s => s.Falta);
                ViewBag.TotalHorasTrabalhadas = folhaPresencas.Sum(s => s.HorasTrabalhadas);
                int numeroPagina = 1;
                var relatorioPdf = new ViewAsPdf
                {
                    ViewName = "../Relatorio/RelatorioPresenca",
                    IsGrayScale = true,
                    Model = folhaPresencas.ToPagedList(numeroPagina, folhaPresencas.Count())
                };
                return relatorioPdf;
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
                return RedirectToAction("Index");
            }
        }
        private void PreencherSelects()
        {
            FuncionarioRepositoryEF funcionarioRepositoryEF = new FuncionarioRepositoryEF();
            var Funcionario = funcionarioRepositoryEF.ListarTodos();
            ViewBag.Funcionario = Funcionario;
        }
    }
}