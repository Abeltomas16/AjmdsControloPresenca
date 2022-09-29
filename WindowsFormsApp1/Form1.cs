using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.Win32;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<string> portas = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void LblConfiguracao_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region Metodos
        private string GetPorta()
        {
            ConnectionOptions options = GetConnectionOptions();
            ManagementScope connectionScope = new ManagementScope(); //GetConnectionScope(Environment.MachineName, options, @"\root\CIMV2");
            SelectQuery q = new SelectQuery("SELECT * FROM Win32_SerialPort");
           // ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM MSSerial_PortName");
            ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope,q);
            foreach (var item in comPortSearcher.Get())
            {
                Console.WriteLine();
            }
           /* using (comPortSearcher)
            {
                string caption = null;
                foreach (ManagementObject obj in comPortSearcher.Get())
                {
                    if (obj == null) return null;
                    object captionObj = obj["Caption"];
                    if (captionObj == null) return null;
                    caption = captionObj.ToString();
                    if (!caption.Contains("(COM")) return null;
                    if (caption.Contains("CH340") || caption.Contains("Arduino"))
                        return caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                }
            }*/
            return null;
        }
        private static ManagementScope GetConnectionScope(string machineName, ConnectionOptions options, string path)
        {
            ManagementScope connectScope = new ManagementScope();
            connectScope.Path = new ManagementPath(@"\\" + machineName + path);
            connectScope.Options = options;
            connectScope.Connect();
            return connectScope;
        }

        private static ConnectionOptions GetConnectionOptions()
        {
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.Authentication = AuthenticationLevel.Default;
            options.EnablePrivileges = true;
            return options;
        }
        #endregion
        private void ActualizaLista()
        {

            try
            {
                GetPorta();
                /*  int i;
                  bool quantDiferente; // para sinalizar que a quantidade de portas mudou
                  i = 0;
                  quantDiferente = false;

                  //se a quantidade de portas mudou

                  if (cbxPortas.Items.Count == SerialPort.GetPortNames().Length)
                  {
                      foreach (string item in SerialPort.GetPortNames())
                      {
                          if (cbxPortas.Items[i++].Equals(item) == false)
                          {
                              quantDiferente = true;
                          }
                      }
                  }
                  else
                  {
                      quantDiferente = true;
                  }
                  //se nao foi detectado diferenca
                  if (quantDiferente == false)
                  {
                      return;
                  }
                  cbxPortas.Items.Clear();

                  foreach (string item in SerialPort.GetPortNames())
                  {
                      cbxPortas.Items.Add(item);
                  }
                  //seleciona a primeira posicao

                  if (cbxPortas.Items.Count > 1)
                  {
                      cbxPortas.SelectedIndex = 1;
                  }
                  else
                  {
                      cbxPortas.SelectedIndex = 0;
                  }*/
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ActualizaLista();
            // ListarPortas();
            try
            {
                /*string pasta = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string pastaCompleta = Path.Combine(pasta, "FingerPrint");
                string file = pastaCompleta + $@"\fingerprint.txt";
                string porta = string.Empty;

                if (!Directory.Exists(pastaCompleta))
                    Directory.CreateDirectory(pastaCompleta);

                if (!File.Exists(file)) return;

                TextReader ler = new StreamReader(file);
                while (ler.Peek() != -1)
                {
                    string p = ler.ReadLine();
                    if (p.ToUpper().Contains("COM")) porta = p.ToUpper();
                }
                ler.Dispose();*/

                string pasta = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string pastaCompleta = Path.Combine(pasta, "FingerPrint");
                string file = pastaCompleta + $@"\fingerprint.txt";
                string porta = string.Empty;

                if (!Directory.Exists(pastaCompleta))
                    Directory.CreateDirectory(pastaCompleta);

                TextWriter escrita = new StreamWriter(file, false, Encoding.Default);
                escrita.Write(cbxPortas.Text);
                escrita.Dispose();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
