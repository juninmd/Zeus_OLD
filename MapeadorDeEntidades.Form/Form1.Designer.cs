namespace MapeadorDeEntidades.Form
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
            this.ddlTabelas = new System.Windows.Forms.ComboBox();
            this.btnEntidade = new System.Windows.Forms.Button();
            this.salvar = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnChamadaProc = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.radioCsharp = new System.Windows.Forms.RadioButton();
            this.radioJava = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioSGBD = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnConnection = new System.Windows.Forms.Button();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.btnChkTabela = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlTabelas
            // 
            this.ddlTabelas.FormattingEnabled = true;
            this.ddlTabelas.Location = new System.Drawing.Point(26, 43);
            this.ddlTabelas.Name = "ddlTabelas";
            this.ddlTabelas.Size = new System.Drawing.Size(389, 21);
            this.ddlTabelas.TabIndex = 0;
            // 
            // btnEntidade
            // 
            this.btnEntidade.Location = new System.Drawing.Point(4, 28);
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Size = new System.Drawing.Size(163, 23);
            this.btnEntidade.TabIndex = 1;
            this.btnEntidade.Text = "Mapeamento de Entidade";
            this.btnEntidade.UseVisualStyleBackColor = true;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(715, 516);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnChamadaProc
            // 
            this.btnChamadaProc.Location = new System.Drawing.Point(4, 57);
            this.btnChamadaProc.Name = "btnChamadaProc";
            this.btnChamadaProc.Size = new System.Drawing.Size(163, 23);
            this.btnChamadaProc.TabIndex = 4;
            this.btnChamadaProc.Text = "Chamada Procedure";
            this.btnChamadaProc.UseVisualStyleBackColor = true;
            this.btnChamadaProc.Click += new System.EventHandler(this.btnProcSharp_Click);
            // 
            // btnProc
            // 
            this.btnProc.Location = new System.Drawing.Point(4, 86);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(163, 23);
            this.btnProc.TabIndex = 5;
            this.btnProc.Text = "Procedure";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProcSql_Click);
            // 
            // radioCsharp
            // 
            this.radioCsharp.AutoSize = true;
            this.radioCsharp.Location = new System.Drawing.Point(6, 19);
            this.radioCsharp.Name = "radioCsharp";
            this.radioCsharp.Size = new System.Drawing.Size(42, 17);
            this.radioCsharp.TabIndex = 7;
            this.radioCsharp.TabStop = true;
            this.radioCsharp.Text = "C #";
            this.radioCsharp.UseVisualStyleBackColor = true;
            // 
            // radioJava
            // 
            this.radioJava.AutoSize = true;
            this.radioJava.Location = new System.Drawing.Point(6, 42);
            this.radioJava.Name = "radioJava";
            this.radioJava.Size = new System.Drawing.Size(48, 17);
            this.radioJava.TabIndex = 8;
            this.radioJava.TabStop = true;
            this.radioJava.Text = "Java";
            this.radioJava.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioCsharp);
            this.groupBox1.Controls.Add(this.radioJava);
            this.groupBox1.Location = new System.Drawing.Point(230, 373);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Linguagem";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioSGBD);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 60);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SGBD";
            // 
            // radioSGBD
            // 
            this.radioSGBD.AutoSize = true;
            this.radioSGBD.Location = new System.Drawing.Point(7, 20);
            this.radioSGBD.Name = "radioSGBD";
            this.radioSGBD.Size = new System.Drawing.Size(56, 17);
            this.radioSGBD.TabIndex = 0;
            this.radioSGBD.TabStop = true;
            this.radioSGBD.Text = "Oracle";
            this.radioSGBD.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEntidade);
            this.groupBox3.Controls.Add(this.btnChamadaProc);
            this.groupBox3.Controls.Add(this.btnProc);
            this.groupBox3.Location = new System.Drawing.Point(46, 373);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 134);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gerar";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnChkTabela);
            this.groupBox4.Controls.Add(this.ddlTabelas);
            this.groupBox4.Location = new System.Drawing.Point(46, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(435, 106);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabela";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnConnection);
            this.groupBox5.Controls.Add(this.txtConnectionString);
            this.groupBox5.Location = new System.Drawing.Point(243, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(459, 60);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Connection String";
            // 
            // btnConnection
            // 
            this.btnConnection.Location = new System.Drawing.Point(356, 16);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(75, 23);
            this.btnConnection.TabIndex = 1;
            this.btnConnection.Text = "Conectar";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(6, 19);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(345, 20);
            this.txtConnectionString.TabIndex = 0;
            // 
            // btnChkTabela
            // 
            this.btnChkTabela.AutoSize = true;
            this.btnChkTabela.Location = new System.Drawing.Point(359, 83);
            this.btnChkTabela.Name = "btnChkTabela";
            this.btnChkTabela.Size = new System.Drawing.Size(56, 17);
            this.btnChkTabela.TabIndex = 1;
            this.btnChkTabela.Text = "Todas";
            this.btnChkTabela.UseVisualStyleBackColor = true;
            this.btnChkTabela.CheckedChanged += new System.EventHandler(this.btnChkTabela_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 522);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTabelas;
        private System.Windows.Forms.Button btnEntidade;
        private System.Windows.Forms.SaveFileDialog salvar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnChamadaProc;
        private System.Windows.Forms.Button btnProc;
        private System.Windows.Forms.RadioButton radioCsharp;
        private System.Windows.Forms.RadioButton radioJava;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioSGBD;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.CheckBox btnChkTabela;
    }
}

