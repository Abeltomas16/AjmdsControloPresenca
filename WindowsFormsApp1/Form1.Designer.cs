namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LblConfiguracao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPortas = new System.Windows.Forms.ComboBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btServico = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblConfiguracao
            // 
            this.LblConfiguracao.AutoSize = true;
            this.LblConfiguracao.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.LblConfiguracao.Location = new System.Drawing.Point(18, 12);
            this.LblConfiguracao.Name = "LblConfiguracao";
            this.LblConfiguracao.Size = new System.Drawing.Size(284, 25);
            this.LblConfiguracao.TabIndex = 2;
            this.LblConfiguracao.Text = "FINGERPRINT CONFIGURAÇÃO";
            this.LblConfiguracao.Click += new System.EventHandler(this.LblConfiguracao_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione a porta COM para comunicação com o sensor";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Controls.Add(this.btSalvar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbxPortas);
            this.panel1.Location = new System.Drawing.Point(23, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 194);
            this.panel1.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.BackgroundImage")));
            this.btnPesquisar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Location = new System.Drawing.Point(212, 52);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(22, 22);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btSalvar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvar.ForeColor = System.Drawing.Color.White;
            this.btSalvar.Location = new System.Drawing.Point(7, 100);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(79, 31);
            this.btSalvar.TabIndex = 2;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Portas";
            // 
            // cbxPortas
            // 
            this.cbxPortas.FormattingEnabled = true;
            this.cbxPortas.Location = new System.Drawing.Point(4, 53);
            this.cbxPortas.Name = "cbxPortas";
            this.cbxPortas.Size = new System.Drawing.Size(202, 21);
            this.cbxPortas.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(300, 276);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(115, 45);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btServico
            // 
            this.btServico.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btServico.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btServico.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btServico.ForeColor = System.Drawing.Color.White;
            this.btServico.Location = new System.Drawing.Point(421, 276);
            this.btServico.Name = "btServico";
            this.btServico.Size = new System.Drawing.Size(136, 45);
            this.btServico.TabIndex = 6;
            this.btServico.Text = "Fechar serviço";
            this.btServico.UseVisualStyleBackColor = false;
            this.btServico.Click += new System.EventHandler(this.btServico_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 333);
            this.Controls.Add(this.btServico);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblConfiguracao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblConfiguracao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxPortas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btServico;
        private System.Windows.Forms.Button btnPesquisar;
    }
}

