﻿namespace MapeadorDeEntidades.Form
{
    partial class formPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.ddlTabelas = new System.Windows.Forms.ComboBox();
            this.btnEntidade = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnChamadaProc = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.radioCsharp = new System.Windows.Forms.RadioButton();
            this.radioJava = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioSGBD3 = new System.Windows.Forms.RadioButton();
            this.radioSGBD2 = new System.Windows.Forms.RadioButton();
            this.radioSGBD1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnJSON = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnChkTabela = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExemplo = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.salvar = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlTabelas
            // 
            this.ddlTabelas.FormattingEnabled = true;
            this.ddlTabelas.Location = new System.Drawing.Point(11, 17);
            this.ddlTabelas.Name = "ddlTabelas";
            this.ddlTabelas.Size = new System.Drawing.Size(498, 21);
            this.ddlTabelas.TabIndex = 0;
            this.ddlTabelas.SelectedIndexChanged += new System.EventHandler(this.ddlTabelas_SelectedIndexChanged);
            // 
            // btnEntidade
            // 
            this.btnEntidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEntidade.Location = new System.Drawing.Point(4, 17);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(169, 23);
            this.btnEntidade.TabIndex = 1;
            this.btnEntidade.Text = "Mapeamento de Entidade";
            this.btnEntidade.UseVisualStyleBackColor = true;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(77, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 433);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnChamadaProc
            // 
            this.btnChamadaProc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChamadaProc.Location = new System.Drawing.Point(4, 46);
            this.btnChamadaProc.Name = "btnChamadaProc";
            this.btnChamadaProc.Size = new System.Drawing.Size(169, 23);
            this.btnChamadaProc.TabIndex = 4;
            this.btnChamadaProc.Text = "Chamada Procedure";
            this.btnChamadaProc.UseVisualStyleBackColor = true;
            this.btnChamadaProc.Click += new System.EventHandler(this.btnChamadaProc_Click);
            // 
            // btnProc
            // 
            this.btnProc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProc.Location = new System.Drawing.Point(4, 75);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(169, 23);
            this.btnProc.TabIndex = 5;
            this.btnProc.Text = "Procedure";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProcSql_Click);
            // 
            // radioCsharp
            // 
            this.radioCsharp.AutoSize = true;
            this.radioCsharp.Checked = true;
            this.radioCsharp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioCsharp.Location = new System.Drawing.Point(6, 19);
            this.radioCsharp.Name = "radioCsharp";
            this.radioCsharp.Size = new System.Drawing.Size(42, 17);
            this.radioCsharp.TabIndex = 7;
            this.radioCsharp.TabStop = true;
            this.radioCsharp.Text = "C #";
            this.radioCsharp.UseVisualStyleBackColor = true;
            this.radioCsharp.CheckedChanged += new System.EventHandler(this.radioCsharp_CheckedChanged);
            // 
            // radioJava
            // 
            this.radioJava.AutoSize = true;
            this.radioJava.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioJava.Location = new System.Drawing.Point(6, 42);
            this.radioJava.Name = "radioJava";
            this.radioJava.Size = new System.Drawing.Size(48, 17);
            this.radioJava.TabIndex = 8;
            this.radioJava.TabStop = true;
            this.radioJava.Text = "Java";
            this.radioJava.UseVisualStyleBackColor = true;
            this.radioJava.CheckedChanged += new System.EventHandler(this.radioJava_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCsharp);
            this.groupBox1.Controls.Add(this.radioJava);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(23, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 83);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linguagem";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioSGBD3);
            this.groupBox2.Controls.Add(this.radioSGBD2);
            this.groupBox2.Controls.Add(this.radioSGBD1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(23, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 112);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SGBD";
            // 
            // radioSGBD3
            // 
            this.radioSGBD3.AutoSize = true;
            this.radioSGBD3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD3.Location = new System.Drawing.Point(7, 66);
            this.radioSGBD3.Name = "radioSGBD3";
            this.radioSGBD3.Size = new System.Drawing.Size(52, 17);
            this.radioSGBD3.TabIndex = 2;
            this.radioSGBD3.TabStop = true;
            this.radioSGBD3.Text = "Mysql";
            this.radioSGBD3.UseVisualStyleBackColor = true;
            // 
            // radioSGBD2
            // 
            this.radioSGBD2.AutoSize = true;
            this.radioSGBD2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD2.Location = new System.Drawing.Point(7, 43);
            this.radioSGBD2.Name = "radioSGBD2";
            this.radioSGBD2.Size = new System.Drawing.Size(92, 17);
            this.radioSGBD2.TabIndex = 1;
            this.radioSGBD2.TabStop = true;
            this.radioSGBD2.Text = "Microsoft SQL";
            this.radioSGBD2.UseVisualStyleBackColor = true;
            // 
            // radioSGBD1
            // 
            this.radioSGBD1.AutoSize = true;
            this.radioSGBD1.Checked = true;
            this.radioSGBD1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD1.Location = new System.Drawing.Point(7, 20);
            this.radioSGBD1.Name = "radioSGBD1";
            this.radioSGBD1.Size = new System.Drawing.Size(56, 17);
            this.radioSGBD1.TabIndex = 0;
            this.radioSGBD1.TabStop = true;
            this.radioSGBD1.Text = "Oracle";
            this.radioSGBD1.UseVisualStyleBackColor = true;
            this.radioSGBD1.CheckedChanged += new System.EventHandler(this.radioSGBD_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnJSON);
            this.groupBox3.Controls.Add(this.btnEntidade);
            this.groupBox3.Controls.Add(this.btnChamadaProc);
            this.groupBox3.Controls.Add(this.btnProc);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(430, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 136);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gerar";
            // 
            // btnJSON
            // 
            this.btnJSON.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnJSON.Location = new System.Drawing.Point(4, 104);
            this.btnJSON.Name = "btnJSON";
            this.btnJSON.Size = new System.Drawing.Size(169, 23);
            this.btnJSON.TabIndex = 6;
            this.btnJSON.Text = "JSON";
            this.btnJSON.UseVisualStyleBackColor = true;
            this.btnJSON.Click += new System.EventHandler(this.btnJSON_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnChkTabela);
            this.groupBox4.Controls.Add(this.ddlTabelas);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox4.Location = new System.Drawing.Point(23, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 55);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabela";
            // 
            // btnChkTabela
            // 
            this.btnChkTabela.AutoSize = true;
            this.btnChkTabela.Location = new System.Drawing.Point(519, 21);
            this.btnChkTabela.Name = "btnChkTabela";
            this.btnChkTabela.Size = new System.Drawing.Size(56, 17);
            this.btnChkTabela.TabIndex = 1;
            this.btnChkTabela.Text = "Todas";
            this.btnChkTabela.UseVisualStyleBackColor = true;
            this.btnChkTabela.CheckedChanged += new System.EventHandler(this.btnChkTabela_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnExemplo);
            this.groupBox5.Controls.Add(this.btnConnection);
            this.groupBox5.Controls.Add(this.txtConnectionString);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox5.Location = new System.Drawing.Point(23, 211);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(581, 60);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connection String";
            // 
            // btnExemplo
            // 
            this.btnExemplo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExemplo.Location = new System.Drawing.Point(553, 18);
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Size = new System.Drawing.Size(21, 21);
            this.btnExemplo.TabIndex = 2;
            this.btnExemplo.Text = "?";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnection.Location = new System.Drawing.Point(473, 17);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Conectar";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(9, 19);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(458, 20);
            this.txtConnectionString.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(307, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 18);
            this.progressBar1.TabIndex = 14;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblStatus);
            this.groupBox6.Controls.Add(this.progressBar1);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox6.Location = new System.Drawing.Point(157, 158);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(446, 51);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(6, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(295, 18);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Aguardando Instruções";
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(616, 333);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeus - 0.2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTabelas;
        private System.Windows.Forms.Button btnEntidade;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnChamadaProc;
        private System.Windows.Forms.Button btnProc;
        private System.Windows.Forms.RadioButton radioCsharp;
        private System.Windows.Forms.RadioButton radioJava;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioSGBD1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.CheckBox btnChkTabela;
        private System.Windows.Forms.FolderBrowserDialog salvar;
        private System.Windows.Forms.Button btnJSON;
        private System.Windows.Forms.Button btnExemplo;
        private System.Windows.Forms.RadioButton radioSGBD2;
        private System.Windows.Forms.RadioButton radioSGBD3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblStatus;
    }
}
