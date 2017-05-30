using System.Drawing;
using Zeus.Core;

namespace Zeus
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
            this.btnChamadaProc = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.radioCsharp = new System.Windows.Forms.RadioButton();
            this.radioJava = new System.Windows.Forms.RadioButton();
            this.radioNode = new System.Windows.Forms.RadioButton();
            this.radioSGBD3 = new System.Windows.Forms.RadioButton();
            this.radioSGBD2 = new System.Windows.Forms.RadioButton();
            this.radioSGBD1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBatch = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnChkTabela = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnExemplo = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.salvar = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new Zeus.Core.NewProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioSGBD5 = new System.Windows.Forms.RadioButton();
            this.radioSGBD4 = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ddlDatabase = new System.Windows.Forms.ComboBox();
            this.txtPreFixoProcedures = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtPrefixoTabela = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtPreFixoPackages = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ddlUnificar = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnAngular = new System.Windows.Forms.Button();
            this.listaStatus = new System.Windows.Forms.ListBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlTabelas
            // 
            this.ddlTabelas.BackColor = System.Drawing.SystemColors.InfoText;
            this.ddlTabelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTabelas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.ddlTabelas.FormattingEnabled = true;
            this.ddlTabelas.Location = new System.Drawing.Point(11, 17);
            this.ddlTabelas.Name = "ddlTabelas";
            this.ddlTabelas.Size = new System.Drawing.Size(532, 24);
            this.ddlTabelas.TabIndex = 0;
            this.ddlTabelas.SelectedIndexChanged += new System.EventHandler(this.EventSetParamters);
            // 
            // btnEntidade
            // 
            this.btnEntidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEntidade.Location = new System.Drawing.Point(369, 17);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(89, 30);
            this.btnEntidade.TabIndex = 13;
            this.btnEntidade.Text = "Entidade";
            this.btnEntidade.UseVisualStyleBackColor = true;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // btnChamadaProc
            // 
            this.btnChamadaProc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChamadaProc.Location = new System.Drawing.Point(11, 17);
            this.btnChamadaProc.Name = "btnChamadaProc";
            this.btnChamadaProc.Size = new System.Drawing.Size(216, 30);
            this.btnChamadaProc.TabIndex = 11;
            this.btnChamadaProc.Text = "Classe de acesso ao banco de dados";
            this.btnChamadaProc.UseVisualStyleBackColor = true;
            this.btnChamadaProc.Click += new System.EventHandler(this.btnChamadaProc_Click);
            // 
            // btnProc
            // 
            this.btnProc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProc.Location = new System.Drawing.Point(233, 17);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(130, 30);
            this.btnProc.TabIndex = 12;
            this.btnProc.Text = "Procedure";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProcSql_Click);
            // 
            // radioCsharp
            // 
            this.radioCsharp.AutoSize = true;
            this.radioCsharp.Checked = true;
            this.radioCsharp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioCsharp.Location = new System.Drawing.Point(6, 28);
            this.radioCsharp.Name = "radioCsharp";
            this.radioCsharp.Size = new System.Drawing.Size(43, 20);
            this.radioCsharp.TabIndex = 1;
            this.radioCsharp.TabStop = true;
            this.radioCsharp.Text = "C #";
            this.radioCsharp.UseVisualStyleBackColor = true;
            this.radioCsharp.CheckedChanged += new System.EventHandler(this.EventSetParamters);
            this.radioCsharp.Click += new System.EventHandler(this.CheckLanguage);
            // 
            // radioJava
            // 
            this.radioJava.AutoSize = true;
            this.radioJava.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioJava.Location = new System.Drawing.Point(6, 51);
            this.radioJava.Name = "radioJava";
            this.radioJava.Size = new System.Drawing.Size(48, 20);
            this.radioJava.TabIndex = 1;
            this.radioJava.TabStop = true;
            this.radioJava.Text = "Java";
            this.radioJava.UseVisualStyleBackColor = true;
            this.radioJava.CheckedChanged += new System.EventHandler(this.EventSetParamters);
            this.radioJava.Click += new System.EventHandler(this.CheckLanguage);
            // 
            // radioNode
            // 
            this.radioNode.AutoSize = true;
            this.radioNode.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioNode.Location = new System.Drawing.Point(6, 80);
            this.radioNode.Name = "radioNode";
            this.radioNode.Size = new System.Drawing.Size(68, 20);
            this.radioNode.TabIndex = 1;
            this.radioNode.TabStop = true;
            this.radioNode.Text = "Node JS";
            this.radioNode.UseVisualStyleBackColor = true;
            this.radioNode.CheckedChanged += new System.EventHandler(this.EventSetParamters);
            this.radioNode.Click += new System.EventHandler(this.CheckLanguage);
            // 
            // radioSGBD3
            // 
            this.radioSGBD3.AutoSize = true;
            this.radioSGBD3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD3.Location = new System.Drawing.Point(7, 60);
            this.radioSGBD3.Name = "radioSGBD3";
            this.radioSGBD3.Size = new System.Drawing.Size(58, 20);
            this.radioSGBD3.TabIndex = 2;
            this.radioSGBD3.TabStop = true;
            this.radioSGBD3.Text = "MySql";
            this.radioSGBD3.UseVisualStyleBackColor = true;
            this.radioSGBD3.CheckedChanged += new System.EventHandler(this.CleanParamters);
            // 
            // radioSGBD2
            // 
            this.radioSGBD2.AutoSize = true;
            this.radioSGBD2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD2.Location = new System.Drawing.Point(7, 37);
            this.radioSGBD2.Name = "radioSGBD2";
            this.radioSGBD2.Size = new System.Drawing.Size(88, 20);
            this.radioSGBD2.TabIndex = 2;
            this.radioSGBD2.TabStop = true;
            this.radioSGBD2.Text = "SQL Server";
            this.radioSGBD2.UseVisualStyleBackColor = true;
            this.radioSGBD2.CheckedChanged += new System.EventHandler(this.CleanParamters);
            // 
            // radioSGBD1
            // 
            this.radioSGBD1.AutoSize = true;
            this.radioSGBD1.Checked = true;
            this.radioSGBD1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD1.Location = new System.Drawing.Point(7, 17);
            this.radioSGBD1.Name = "radioSGBD1";
            this.radioSGBD1.Size = new System.Drawing.Size(62, 20);
            this.radioSGBD1.TabIndex = 2;
            this.radioSGBD1.TabStop = true;
            this.radioSGBD1.Text = "Oracle";
            this.radioSGBD1.UseVisualStyleBackColor = true;
            this.radioSGBD1.CheckedChanged += new System.EventHandler(this.CleanParamters);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEntidade);
            this.groupBox3.Controls.Add(this.btnChamadaProc);
            this.groupBox3.Controls.Add(this.btnProc);
            this.groupBox3.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox3.Location = new System.Drawing.Point(21, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 55);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "10 - Gerar";
            // 
            // btnBatch
            // 
            this.btnBatch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBatch.Location = new System.Drawing.Point(11, 19);
            this.btnBatch.Name = "btnBatch";
            this.btnBatch.Size = new System.Drawing.Size(100, 23);
            this.btnBatch.TabIndex = 14;
            this.btnBatch.Text = "Batch Execute";
            this.btnBatch.UseVisualStyleBackColor = true;
            this.btnBatch.Click += new System.EventHandler(this.btnBatch_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnChkTabela);
            this.groupBox4.Controls.Add(this.ddlTabelas);
            this.groupBox4.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox4.Location = new System.Drawing.Point(21, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 60);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "7 - Tabela";
            // 
            // btnChkTabela
            // 
            this.btnChkTabela.AutoSize = true;
            this.btnChkTabela.ForeColor = System.Drawing.Color.White;
            this.btnChkTabela.Location = new System.Drawing.Point(549, 19);
            this.btnChkTabela.Name = "btnChkTabela";
            this.btnChkTabela.Size = new System.Drawing.Size(59, 20);
            this.btnChkTabela.TabIndex = 8;
            this.btnChkTabela.Text = "Todas";
            this.btnChkTabela.UseVisualStyleBackColor = true;
            this.btnChkTabela.CheckedChanged += new System.EventHandler(this.btnChkTabela_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnExemplo);
            this.groupBox5.Controls.Add(this.btnConnection);
            this.groupBox5.Controls.Add(this.txtConnectionString);
            this.groupBox5.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox5.Location = new System.Drawing.Point(240, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(704, 66);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3 - Connection String";
            // 
            // btnExemplo
            // 
            this.btnExemplo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExemplo.Location = new System.Drawing.Point(673, 19);
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Size = new System.Drawing.Size(21, 29);
            this.btnExemplo.TabIndex = 2;
            this.btnExemplo.Text = "?";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnection.Location = new System.Drawing.Point(594, 19);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 29);
            this.btnConnection.TabIndex = 3;
            this.btnConnection.Text = "Conectar";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConnectionString.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.txtConnectionString.Location = new System.Drawing.Point(9, 24);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(579, 20);
            this.txtConnectionString.TabIndex = 3;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listaStatus);
            this.groupBox6.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox6.Location = new System.Drawing.Point(21, 270);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(923, 77);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(21, 353);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(923, 12);
            this.progressBar1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioNode);
            this.groupBox1.Controls.Add(this.radioCsharp);
            this.groupBox1.Controls.Add(this.radioJava);
            this.groupBox1.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 131);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1 - Linguagem";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioSGBD5);
            this.groupBox2.Controls.Add(this.radioSGBD4);
            this.groupBox2.Controls.Add(this.radioSGBD3);
            this.groupBox2.Controls.Add(this.radioSGBD2);
            this.groupBox2.Controls.Add(this.radioSGBD1);
            this.groupBox2.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox2.Location = new System.Drawing.Point(131, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(110, 131);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2 - SGBD";
            // 
            // radioSGBD5
            // 
            this.radioSGBD5.AutoSize = true;
            this.radioSGBD5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD5.Location = new System.Drawing.Point(7, 105);
            this.radioSGBD5.Name = "radioSGBD5";
            this.radioSGBD5.Size = new System.Drawing.Size(66, 20);
            this.radioSGBD5.TabIndex = 2;
            this.radioSGBD5.TabStop = true;
            this.radioSGBD5.Text = "Postgre";
            this.radioSGBD5.UseVisualStyleBackColor = true;
            this.radioSGBD5.CheckedChanged += new System.EventHandler(this.CleanParamters);
            // 
            // radioSGBD4
            // 
            this.radioSGBD4.AutoSize = true;
            this.radioSGBD4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.radioSGBD4.Location = new System.Drawing.Point(7, 82);
            this.radioSGBD4.Name = "radioSGBD4";
            this.radioSGBD4.Size = new System.Drawing.Size(67, 20);
            this.radioSGBD4.TabIndex = 2;
            this.radioSGBD4.TabStop = true;
            this.radioSGBD4.Text = "Firebird";
            this.radioSGBD4.UseVisualStyleBackColor = true;
            this.radioSGBD4.CheckedChanged += new System.EventHandler(this.CleanParamters);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ddlDatabase);
            this.groupBox7.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox7.Location = new System.Drawing.Point(240, 77);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(328, 66);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "4 - Schema";
            // 
            // ddlDatabase
            // 
            this.ddlDatabase.BackColor = System.Drawing.SystemColors.MenuText;
            this.ddlDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabase.Enabled = false;
            this.ddlDatabase.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.ddlDatabase.FormattingEnabled = true;
            this.ddlDatabase.Location = new System.Drawing.Point(6, 20);
            this.ddlDatabase.Name = "ddlDatabase";
            this.ddlDatabase.Size = new System.Drawing.Size(313, 24);
            this.ddlDatabase.TabIndex = 4;
            this.ddlDatabase.SelectedIndexChanged += new System.EventHandler(this.ddlDatabase_SelectedIndexChanged);
            // 
            // txtPreFixoProcedures
            // 
            this.txtPreFixoProcedures.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPreFixoProcedures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreFixoProcedures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.txtPreFixoProcedures.Location = new System.Drawing.Point(9, 26);
            this.txtPreFixoProcedures.Name = "txtPreFixoProcedures";
            this.txtPreFixoProcedures.Size = new System.Drawing.Size(150, 20);
            this.txtPreFixoProcedures.TabIndex = 5;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtPreFixoProcedures);
            this.groupBox8.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox8.Location = new System.Drawing.Point(565, 77);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(175, 66);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "5 - Pré-Fixo Procedures";
            // 
            // txtPrefixoTabela
            // 
            this.txtPrefixoTabela.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPrefixoTabela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrefixoTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.txtPrefixoTabela.Location = new System.Drawing.Point(6, 26);
            this.txtPrefixoTabela.Name = "txtPrefixoTabela";
            this.txtPrefixoTabela.Size = new System.Drawing.Size(155, 20);
            this.txtPrefixoTabela.TabIndex = 9;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtPrefixoTabela);
            this.groupBox9.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox9.Location = new System.Drawing.Point(635, 143);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(167, 60);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "7 - Pré-Fixo Tabelas";
            // 
            // txtPreFixoPackages
            // 
            this.txtPreFixoPackages.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPreFixoPackages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreFixoPackages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.txtPreFixoPackages.Location = new System.Drawing.Point(6, 26);
            this.txtPreFixoPackages.Name = "txtPreFixoPackages";
            this.txtPreFixoPackages.Size = new System.Drawing.Size(188, 20);
            this.txtPreFixoPackages.TabIndex = 6;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtPreFixoPackages);
            this.groupBox10.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox10.Location = new System.Drawing.Point(740, 77);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(204, 66);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "6 - Pré-Fixo Packages (Oracle)";
            // 
            // ddlUnificar
            // 
            this.ddlUnificar.BackColor = System.Drawing.SystemColors.MenuText;
            this.ddlUnificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUnificar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlUnificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.ddlUnificar.FormattingEnabled = true;
            this.ddlUnificar.Items.AddRange(new object[] {
            "SIM",
            "NÃO"});
            this.ddlUnificar.Location = new System.Drawing.Point(6, 22);
            this.ddlUnificar.Name = "ddlUnificar";
            this.ddlUnificar.Size = new System.Drawing.Size(124, 24);
            this.ddlUnificar.TabIndex = 10;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ddlUnificar);
            this.groupBox11.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox11.Location = new System.Drawing.Point(802, 143);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(142, 60);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "8 - Unificar Output";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnConfiguracoes);
            this.groupBox12.Controls.Add(this.btnBatch);
            this.groupBox12.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox12.Location = new System.Drawing.Point(504, 209);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(270, 55);
            this.groupBox12.TabIndex = 18;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "11 - Extras";
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConfiguracoes.Location = new System.Drawing.Point(117, 19);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(131, 23);
            this.btnConfiguracoes.TabIndex = 15;
            this.btnConfiguracoes.Text = "Salvar Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click_1);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btnAngular);
            this.groupBox13.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.groupBox13.Location = new System.Drawing.Point(774, 209);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(170, 55);
            this.groupBox13.TabIndex = 20;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "12 - Frontend";
            // 
            // btnAngular
            // 
            this.btnAngular.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAngular.Location = new System.Drawing.Point(12, 21);
            this.btnAngular.Name = "btnAngular";
            this.btnAngular.Size = new System.Drawing.Size(142, 23);
            this.btnAngular.TabIndex = 16;
            this.btnAngular.Text = "Service Angular";
            this.btnAngular.UseVisualStyleBackColor = true;
            this.btnAngular.Click += new System.EventHandler(this.btnAngular_Click);
            // 
            // listaStatus
            // 
            this.listaStatus.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listaStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaStatus.Font = new System.Drawing.Font("Gill Sans MT", 8.25F, System.Drawing.FontStyle.Bold);
            this.listaStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.listaStatus.FormattingEnabled = true;
            this.listaStatus.ItemHeight = 16;
            this.listaStatus.Location = new System.Drawing.Point(6, 17);
            this.listaStatus.Name = "listaStatus";
            this.listaStatus.Size = new System.Drawing.Size(907, 48);
            this.listaStatus.TabIndex = 17;
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(956, 374);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zeus - 0.9";
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTabelas;
        private System.Windows.Forms.Button btnEntidade;
        private System.Windows.Forms.Button btnChamadaProc;
        private System.Windows.Forms.Button btnProc;
        private System.Windows.Forms.RadioButton radioCsharp;
        private System.Windows.Forms.RadioButton radioJava;
        private System.Windows.Forms.RadioButton radioSGBD1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.CheckBox btnChkTabela;
        private System.Windows.Forms.FolderBrowserDialog salvar;
        private System.Windows.Forms.Button btnExemplo;
        private System.Windows.Forms.RadioButton radioSGBD2;
        private System.Windows.Forms.RadioButton radioSGBD3;
        private NewProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioNode;
        private System.Windows.Forms.Button btnBatch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox ddlDatabase;
        private System.Windows.Forms.TextBox txtPreFixoProcedures;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtPrefixoTabela;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtPreFixoPackages;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox ddlUnificar;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.RadioButton radioSGBD4;
        private System.Windows.Forms.RadioButton radioSGBD5;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button btnAngular;
        private System.Windows.Forms.ListBox listaStatus;
    }
}

