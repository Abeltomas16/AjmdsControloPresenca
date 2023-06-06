using AjmdsControloPresenca.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjmdsControloPresenca.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        GraficosRepositoryEF repositoryEF = new GraficosRepositoryEF();
        // GET: Home
        public ActionResult Index()
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


    }
}