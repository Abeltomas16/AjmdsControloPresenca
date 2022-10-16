using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.ServiceProcess;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> portas = new List<string>();
        const string Path = @"C:\FingerPrint";
        const string PathPorta = @"C:\FingerPrint\FingerPrintPorta.txt";
        const string FecharServico = "Fechar serviço";
        const string StartServico = "Iniciar serviço";
        const string NomeServico = "FingerPrint Arduino";
        readonly ServiceController servico ;
        public Form1()
        {
            InitializeComponent();
            servico = new ServiceController(NomeServico);
        }

        #region Metodos
        private List<string> GetPorta()
        {
            List<string> portas = new List<string>();
            ConnectionOptions options = GetConnectionOptions();
            ManagementScope connectionScope = new ManagementScope(); //GetConnectionScope(Environment.MachineName, options, @"\root\CIMV2");
            SelectQuery q = new SelectQuery("select * from Win32_PnpEntity where ClassGuid = '{4d36e978-e325-11ce-bfc1-08002be10318}' ");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, q);
            using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj == null) return null;
                    object captionObj = obj["Name"];
                    if (captionObj == null) return null;
                    caption = captionObj.ToString();
                    if (!caption.Contains("(COM")) return null;
                    if (caption.Contains("CH340") || caption.Contains("Arduino"))
                        portas.Add(caption);
                }
            }
            return portas;
        }
        private static ConnectionOptions GetConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Authentication = AuthenticationLevel.Default;
            options.EnablePrivileges = true;
            return options;
        }
        void RestartService()
        {
            int tick1 = Environment.TickCount;
            int tick2 = Environment.TickCount;
            TimeSpan timeout = TimeSpan.FromMilliseconds(6000);
            if ((servico.Status == ServiceControllerStatus.Running) || (servico.Status == ServiceControllerStatus.StartPending))
            {
                servico.Stop();
            }
            servico.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            timeout = TimeSpan.FromMilliseconds(6000 - (tick1 - tick2));
            servico.Start();
            servico.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }
        void StartService()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(6000);
            servico.Stop();
            servico.WaitForStatus(ServiceControllerStatus.Running, timeout);
        }
        void StopService()
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(6000);
            servico.Stop();      
            servico.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
        }
        bool StatService()
        {
            if ((servico.Status == ServiceControllerStatus.Running) || (servico.Status == ServiceControllerStatus.StartPending))
            {
                return true;
            }
            return false;
        }
        void AnalisarServico()
        {
            if (StatService())
                btServico.Text = FecharServico;
            else
                btServico.Text = StartServico;
        }
        #endregion

        #region eventos
        private void LblConfiguracao_Click(object sender, EventArgs e)
        {
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> portas = GetPorta();
                cbxPortas.Items.Clear();
                foreach (var item in portas)
                {
                    cbxPortas.Items.Add(item);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string porta = cbxPortas.Text.Substring(cbxPortas.Text.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);

                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);

                TextWriter escrita = new StreamWriter(PathPorta, false, Encoding.Default);
                escrita.Write(porta);
                escrita.Dispose();
                RestartService();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AnalisarServico();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btServico_Click(object sender, EventArgs e)
        {
            try
            {
                if (btServico.Text == FecharServico)
                {
                    StopService();
                }
                else
                {
                    StartService();
                }

                AnalisarServico();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion
    }
}

