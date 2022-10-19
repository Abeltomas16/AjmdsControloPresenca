using FingerPrintServico.Data;
using System;
using System.IO;
using System.IO.Ports;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FingerPrintServico
{
    public partial class Service1 : ServiceBase
    {
        const string Path = @"C:\FingerPrint";
        const string PathError = @"C:\FingerPrint\FingerPrintErro.txt";
        const string PathPorta = @"C:\FingerPrint\FingerPrintPorta.txt";

        static string COM = string.Empty;
        System.Threading.Timer timer1;
        SerialPort conexao;
        string rtx = string.Empty;
        SqlServer bll;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                conexao = new SerialPort();
                conexao.DataReceived += Conexao_DataReceived;
                bll = new SqlServer();
                timer1 = new System.Threading.Timer(new System.Threading.TimerCallback(timer1_Tick), null, 5000, 5000);

            }
            catch (Exception erro)
            {
                StreamWriter vWriter = new StreamWriter(PathError, false);
                vWriter.WriteLine(erro.Message + erro.Source + erro.StackTrace + erro.InnerException + erro.Data + erro);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        private void timer1_Tick(object state)
        {
            try
            {
                if (!conexao.IsOpen)
                {
                    COM = GetPorta();
                    if (COM == null) return;
                    conexao.PortName = COM;
                    conexao.Open();
                }
            }
            catch (Exception erro)
            {
                StreamWriter vWriter = new StreamWriter(PathError, false);
                vWriter.WriteLine(erro.Message + erro.Source + erro.StackTrace + erro.InnerException + erro.Data + erro);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        private string GetPorta()
        {
            string porta = string.Empty;

            if (!File.Exists(PathPorta) || !Directory.Exists(Path)) return null;

            TextReader ler = new StreamReader(PathPorta);
            while (ler.Peek() != -1)
            {
                string p = ler.ReadLine();
                if (p.ToUpper().Contains("COM")) porta = p.ToUpper();
            }
            ler.Dispose();

            return porta;
        }

        private void Conexao_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            rtx = conexao.ReadExisting();
            Task.Run(() => trataDadosRecebidos(rtx));
        }

        private void trataDadosRecebidos(string rtx)
        {
            try
            {
                int ids = int.Parse(rtx);
                string retorno = bll.Cadastrar(ids);
                StreamWriter vWriter = new StreamWriter(@"c:\FingerPrintRecebido.txt", true);
                vWriter.WriteLine("Funcionário: " + ids.ToString() + " " + DateTime.Now);
                vWriter.Flush();
                vWriter.Close();
                conexao.Write(retorno);
            }
            catch (Exception erro)
            {
                StreamWriter vWriter = new StreamWriter(PathError, true);
                vWriter.WriteLine(erro.Message + erro.Source + erro.StackTrace + erro.InnerException + erro.Data + erro);
                vWriter.Flush();
                vWriter.Close();
            }
        }

        protected override void OnStop()
        {
            if (conexao.IsOpen)
            {
                conexao.Close();
            }
        }
    }
}
