using FingerPrintServico.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintServico
{
    public partial class Service1 : ServiceBase
    {
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
            conexao = new SerialPort();
            conexao.DataReceived += Conexao_DataReceived;
            bll = new SqlServer();
            timer1 = new System.Threading.Timer(new System.Threading.TimerCallback(timer1_Tick), null, 5000, 5000);
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
                StreamWriter vWriter = new StreamWriter(@"c:\FingerPrintError.txt", false);
                vWriter.WriteLine(erro.Message + erro.Source + erro.StackTrace + erro.InnerException + erro.Data + erro);
                vWriter.Flush();
                vWriter.Close();
            }

        }

        private string GetPorta()
        {
            string pasta = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string pastaCompleta = Path.Combine(pasta, "FingerPrint");
            string file = pastaCompleta + $@"\fingerprint.txt";
            string porta = string.Empty;

            if (!File.Exists(file) || !Directory.Exists(pastaCompleta)) return null;

            TextReader ler = new StreamReader(file);
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
                StreamWriter vWriter = new StreamWriter(@"c:\FingerPrintRecebidotxt", true);
                vWriter.WriteLine(ids.ToString());
                vWriter.Flush();
                vWriter.Close();
            }
            catch (Exception erro)
            {
                StreamWriter vWriter = new StreamWriter(@"c:\FingerPrintError.txt", true);
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
