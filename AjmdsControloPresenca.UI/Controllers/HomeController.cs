using AjmdsControloPresenca.Domain.Entities.Relatorio;
using AjmdsControloPresenca.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Parser.SyntaxTree;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        GraficosRepositoryEF repositoryEF = new GraficosRepositoryEF();
        FuncionarioRepositoryEF funcionarioRepository = new FuncionarioRepositoryEF();
        DepartamentoRepositoryEF departamentoRepositoryEF = new DepartamentoRepositoryEF();
        AfastamentoRepositoryEF afastamentoRepositoryEF = new AfastamentoRepositoryEF();
        RelatorioRepositorioEF relatorioRepositorioEF = new RelatorioRepositorioEF();
        List<string> cores = new List<string>
        { "bg-primary" ,"bg-secondary","bg-warning","bg-info","bg-danger","bg-success",
        };
        List<string> coresUtilizadas = new List<string>();
        // GET: Home
        public ActionResult Index()
        {
            int TotalFuncionario = funcionarioRepository.ListarTodos().Where(x => x.Estado).Count();
            int TotalDepto = departamentoRepositoryEF.ListarTodos().Where(x => x.Estado).Count();
            int TotalAfastamento = afastamentoRepositoryEF.ListarTodos().Where(x => x.Estado).Count();
            var presencas = relatorioRepositorioEF.ListarHoje();


            Random random = new Random();
            foreach (Presencas presenca in presencas)
            {
                // Verifica se todas as cores já foram utilizadas
                if (coresUtilizadas.Count == cores.Count)
                {
                    // Se todas as cores já foram utilizadas, reinicia a lista de cores utilizadas
                    coresUtilizadas.Clear();
                }
                // Obtém uma cor aleatória que não tenha sido utilizada anteriormente
                string corAleatoria = ObterCorAleatoria(cores, coresUtilizadas, random);
                presenca.Cor = corAleatoria; // Define a cor aleatória na propriedade "cor" da presenca
                coresUtilizadas.Add(corAleatoria); // Adiciona a cor utilizada na lista de cores utilizadas
            }

            ViewBag.TotalFuncionario = TotalFuncionario;
            ViewBag.Depto = TotalDepto;
            ViewBag.TotalAfastamento = TotalAfastamento;
            ViewBag.ListaPresencas = presencas;

            return View();
        }
        public ActionResult grafico()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetDados()
        {
            List<string> labels = repositoryEF.Labels();

            List<string> labelsPortugues = new List<string>();
            List<string> coresPresenca = new List<string>();
            List<string> coresFalta = new List<string>();
            foreach (string label in labels)
            {
                labelsPortugues.Add(ConverterMesInglesParaPortugues(label));
                coresPresenca.Add(ObterCorPorMes(ConverterMesInglesParaPortugues(label)));
                coresFalta.Add("red");
            }

            List<int> faltas = repositoryEF.ListarFalta();
            List<int> presencas = repositoryEF.ListarPresenca();

            List<object> data = new List<object>();
            data.Add(labelsPortugues);
            data.Add(presencas);
            data.Add(faltas);
            data.Add(coresPresenca);
            data.Add(coresFalta);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public string ObterCorPorMes(string nomeMes)
        {
            Dictionary<string, string> coresMeses = new Dictionary<string, string>()
                    {
                        { "janeiro", "#FF00FF" },    // Magenta
                        { "fevereiro", "#00FF00" },  // Verde
                        { "março", "#0000FF" },      // Azul
                        { "abril", "#00FFFF" },      // Ciano
                        { "maio", "#FF00FF" },       // Índigo
                        { "junho", "#FFFF00" },      // Amarelo
                        { "julho", "#FFA500" },      // Laranja
                        { "agosto", "#800080" },     // Roxo
                        { "setembro", "#008000" },   // Verde escuro
                        { "outubro", "#800000" },    // Marrom
                        { "novembro", "#FFC0CB" },   // Rosa
                        { "dezembro", "#FFA07A" }    // Salmão
                    };

            if (coresMeses.ContainsKey(nomeMes.ToLower()))
            {
                return coresMeses[nomeMes.ToLower()];
            }
            else
            {
                return "#000000"; // Cor padrão para outros meses
            }
        }

        public string ConverterMesInglesParaPortugues(string mesIngles)
        {
            string mesPortugues;

            switch (mesIngles.ToLower())
            {
                case "january":
                    mesPortugues = "janeiro";
                    break;
                case "february":
                    mesPortugues = "fevereiro";
                    break;
                case "march":
                    mesPortugues = "março";
                    break;
                case "april":
                    mesPortugues = "abril";
                    break;
                case "may":
                    mesPortugues = "maio";
                    break;
                case "june":
                    mesPortugues = "junho";
                    break;
                case "july":
                    mesPortugues = "julho";
                    break;
                case "august":
                    mesPortugues = "agosto";
                    break;
                case "september":
                    mesPortugues = "setembro";
                    break;
                case "october":
                    mesPortugues = "outubro";
                    break;
                case "november":
                    mesPortugues = "novembro";
                    break;
                case "december":
                    mesPortugues = "dezembro";
                    break;
                default:
                    mesPortugues = mesIngles; // Retorna o próprio valor de entrada se não houver correspondência
                    break;
            }

            return mesPortugues;
        }
        string ObterCorAleatoria(List<string> cores, List<string> coresUtilizadas, Random random)
        {
            List<string> coresDisponiveis = cores.Except(coresUtilizadas).ToList(); // Obtém as cores disponíveis (ainda não utilizadas)

            int index = random.Next(0, coresDisponiveis.Count); // Gera um índice aleatório na lista de cores disponíveis
            string corAleatoria = coresDisponiveis[index]; // Obtém a cor aleatória correspondente ao índice

            return corAleatoria;
        }

    }
}