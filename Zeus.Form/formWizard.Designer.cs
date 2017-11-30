namespace Zeus
{
    partial class formWizard
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
            this.tab = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.picsgbd = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnAvancar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnconnection = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtConnectionString = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioSGBD3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD5 = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnExemplo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.listTabelas = new System.Windows.Forms.ListBox();
            this.btnChkTabela = new MaterialSkin.Controls.MaterialCheckBox();
            this.btnAvancarTabelas = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listSchemas = new System.Windows.Forms.ListBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.lblTabelas = new MaterialSkin.Controls.MaterialLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton5 = new MaterialSkin.Controls.MaterialRadioButton();
            this.piclinguagem = new System.Windows.Forms.PictureBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.tab.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picsgbd)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclinguagem)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Depth = 0;
            this.tab.Location = new System.Drawing.Point(2, 62);
            this.tab.MouseState = MaterialSkin.MouseState.HOVER;
            this.tab.Name = "tab";
            this.tab.Padding = new System.Drawing.Point(2, 2);
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(667, 369);
            this.tab.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblTabelas);
            this.tabPage2.Controls.Add(this.materialLabel5);
            this.tabPage2.Controls.Add(this.materialLabel2);
            this.tabPage2.Controls.Add(this.listSchemas);
            this.tabPage2.Controls.Add(this.btnAvancarTabelas);
            this.tabPage2.Controls.Add(this.btnChkTabela);
            this.tabPage2.Controls.Add(this.listTabelas);
            this.tabPage2.Location = new System.Drawing.Point(4, 20);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tabelas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.materialLabel3);
            this.tabPage3.Controls.Add(this.piclinguagem);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 20);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(659, 345);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Linguagens";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // picsgbd
            // 
            this.picsgbd.Location = new System.Drawing.Point(503, 57);
            this.picsgbd.Name = "picsgbd";
            this.picsgbd.Size = new System.Drawing.Size(109, 60);
            this.picsgbd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picsgbd.TabIndex = 8;
            this.picsgbd.TabStop = false;
            this.picsgbd.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(20, 19);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(213, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Selecione seu banco de dados";
            // 
            // btnAvancar
            // 
            this.btnAvancar.Depth = 0;
            this.btnAvancar.Location = new System.Drawing.Point(566, 316);
            this.btnAvancar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Primary = true;
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 12;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnconnection
            // 
            this.btnconnection.Depth = 0;
            this.btnconnection.Location = new System.Drawing.Point(503, 230);
            this.btnconnection.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnconnection.Name = "btnconnection";
            this.btnconnection.Primary = true;
            this.btnconnection.Size = new System.Drawing.Size(138, 23);
            this.btnconnection.TabIndex = 13;
            this.btnconnection.Text = "Testar Conexão";
            this.btnconnection.Click += new System.EventHandler(this.btnconnection_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Depth = 0;
            this.txtConnectionString.Hint = "";
            this.txtConnectionString.Location = new System.Drawing.Point(24, 201);
            this.txtConnectionString.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.PasswordChar = '\0';
            this.txtConnectionString.SelectedText = "";
            this.txtConnectionString.SelectionLength = 0;
            this.txtConnectionString.SelectionStart = 0;
            this.txtConnectionString.Size = new System.Drawing.Size(627, 23);
            this.txtConnectionString.TabIndex = 6;
            this.txtConnectionString.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(27, 179);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(195, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Informe a conecction String";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioSGBD5);
            this.panel1.Controls.Add(this.radioSGBD4);
            this.panel1.Controls.Add(this.radioSGBD2);
            this.panel1.Controls.Add(this.radioSGBD1);
            this.panel1.Controls.Add(this.radioSGBD3);
            this.panel1.Location = new System.Drawing.Point(31, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 76);
            this.panel1.TabIndex = 15;
            // 
            // radioSGBD3
            // 
            this.radioSGBD3.AutoSize = true;
            this.radioSGBD3.Depth = 0;
            this.radioSGBD3.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioSGBD3.Location = new System.Drawing.Point(0, 0);
            this.radioSGBD3.Margin = new System.Windows.Forms.Padding(0);
            this.radioSGBD3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioSGBD3.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioSGBD3.Name = "radioSGBD3";
            this.radioSGBD3.Ripple = true;
            this.radioSGBD3.Size = new System.Drawing.Size(67, 30);
            this.radioSGBD3.TabIndex = 0;
            this.radioSGBD3.TabStop = true;
            this.radioSGBD3.Text = "MySql";
            this.radioSGBD3.UseVisualStyleBackColor = true;
            this.radioSGBD3.CheckedChanged += new System.EventHandler(this.radioSGBD3_CheckedChanged);
            // 
            // radioSGBD1
            // 
            this.radioSGBD1.AutoSize = true;
            this.radioSGBD1.Depth = 0;
            this.radioSGBD1.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioSGBD1.Location = new System.Drawing.Point(0, 30);
            this.radioSGBD1.Margin = new System.Windows.Forms.Padding(0);
            this.radioSGBD1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioSGBD1.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioSGBD1.Name = "radioSGBD1";
            this.radioSGBD1.Ripple = true;
            this.radioSGBD1.Size = new System.Drawing.Size(69, 30);
            this.radioSGBD1.TabIndex = 1;
            this.radioSGBD1.TabStop = true;
            this.radioSGBD1.Text = "Oracle";
            this.radioSGBD1.UseVisualStyleBackColor = true;
            this.radioSGBD1.CheckedChanged += new System.EventHandler(this.radioSGBD1_CheckedChanged);
            // 
            // radioSGBD2
            // 
            this.radioSGBD2.AutoSize = true;
            this.radioSGBD2.Depth = 0;
            this.radioSGBD2.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioSGBD2.Location = new System.Drawing.Point(114, 0);
            this.radioSGBD2.Margin = new System.Windows.Forms.Padding(0);
            this.radioSGBD2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioSGBD2.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioSGBD2.Name = "radioSGBD2";
            this.radioSGBD2.Ripple = true;
            this.radioSGBD2.Size = new System.Drawing.Size(97, 30);
            this.radioSGBD2.TabIndex = 2;
            this.radioSGBD2.TabStop = true;
            this.radioSGBD2.Text = "SQL Server";
            this.radioSGBD2.UseVisualStyleBackColor = true;
            this.radioSGBD2.CheckedChanged += new System.EventHandler(this.radioSGBD2_CheckedChanged);
            // 
            // radioSGBD4
            // 
            this.radioSGBD4.AutoSize = true;
            this.radioSGBD4.Depth = 0;
            this.radioSGBD4.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioSGBD4.Location = new System.Drawing.Point(114, 30);
            this.radioSGBD4.Margin = new System.Windows.Forms.Padding(0);
            this.radioSGBD4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioSGBD4.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioSGBD4.Name = "radioSGBD4";
            this.radioSGBD4.Ripple = true;
            this.radioSGBD4.Size = new System.Drawing.Size(76, 30);
            this.radioSGBD4.TabIndex = 3;
            this.radioSGBD4.TabStop = true;
            this.radioSGBD4.Text = "Firebird";
            this.radioSGBD4.UseVisualStyleBackColor = true;
            this.radioSGBD4.CheckedChanged += new System.EventHandler(this.radioSGBD4_CheckedChanged);
            // 
            // radioSGBD5
            // 
            this.radioSGBD5.AutoSize = true;
            this.radioSGBD5.Depth = 0;
            this.radioSGBD5.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioSGBD5.Location = new System.Drawing.Point(245, 0);
            this.radioSGBD5.Margin = new System.Windows.Forms.Padding(0);
            this.radioSGBD5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioSGBD5.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioSGBD5.Name = "radioSGBD5";
            this.radioSGBD5.Ripple = true;
            this.radioSGBD5.Size = new System.Drawing.Size(77, 30);
            this.radioSGBD5.TabIndex = 4;
            this.radioSGBD5.TabStop = true;
            this.radioSGBD5.Text = "Postgre";
            this.radioSGBD5.UseVisualStyleBackColor = true;
            this.radioSGBD5.CheckedChanged += new System.EventHandler(this.radioSGBD5_CheckedChanged);
            // 
            // btnExemplo
            // 
            this.btnExemplo.Depth = 0;
            this.btnExemplo.Location = new System.Drawing.Point(451, 230);
            this.btnExemplo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Primary = true;
            this.btnExemplo.Size = new System.Drawing.Size(46, 23);
            this.btnExemplo.TabIndex = 16;
            this.btnExemplo.Text = "?";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnExemplo);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.materialLabel4);
            this.tabPage1.Controls.Add(this.txtConnectionString);
            this.tabPage1.Controls.Add(this.btnconnection);
            this.tabPage1.Controls.Add(this.btnAvancar);
            this.tabPage1.Controls.Add(this.materialLabel1);
            this.tabPage1.Controls.Add(this.picsgbd);
            this.tabPage1.Location = new System.Drawing.Point(4, 20);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Banco";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.tab;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(2, 437);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(667, 49);
            this.materialTabSelector1.TabIndex = 5;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // listTabelas
            // 
            this.listTabelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTabelas.FormattingEnabled = true;
            this.listTabelas.Location = new System.Drawing.Point(269, 51);
            this.listTabelas.Name = "listTabelas";
            this.listTabelas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listTabelas.Size = new System.Drawing.Size(370, 260);
            this.listTabelas.TabIndex = 13;
            // 
            // btnChkTabela
            // 
            this.btnChkTabela.AutoSize = true;
            this.btnChkTabela.Depth = 0;
            this.btnChkTabela.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnChkTabela.Location = new System.Drawing.Point(416, 20);
            this.btnChkTabela.Margin = new System.Windows.Forms.Padding(0);
            this.btnChkTabela.MouseLocation = new System.Drawing.Point(-1, -1);
            this.btnChkTabela.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnChkTabela.Name = "btnChkTabela";
            this.btnChkTabela.Ripple = true;
            this.btnChkTabela.Size = new System.Drawing.Size(133, 30);
            this.btnChkTabela.TabIndex = 15;
            this.btnChkTabela.Text = "Selecionar todas";
            this.btnChkTabela.UseVisualStyleBackColor = true;
            this.btnChkTabela.CheckedChanged += new System.EventHandler(this.btnChkTabela_CheckedChanged);
            // 
            // btnAvancarTabelas
            // 
            this.btnAvancarTabelas.Depth = 0;
            this.btnAvancarTabelas.Location = new System.Drawing.Point(541, 316);
            this.btnAvancarTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAvancarTabelas.Name = "btnAvancarTabelas";
            this.btnAvancarTabelas.Primary = true;
            this.btnAvancarTabelas.Size = new System.Drawing.Size(98, 27);
            this.btnAvancarTabelas.TabIndex = 16;
            this.btnAvancarTabelas.Text = "Avançar";
            this.btnAvancarTabelas.UseVisualStyleBackColor = true;
            this.btnAvancarTabelas.Click += new System.EventHandler(this.btnAvancarTabelas_Click);
            // 
            // listSchemas
            // 
            this.listSchemas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSchemas.FormattingEnabled = true;
            this.listSchemas.Location = new System.Drawing.Point(6, 51);
            this.listSchemas.Name = "listSchemas";
            this.listSchemas.Size = new System.Drawing.Size(241, 260);
            this.listSchemas.TabIndex = 17;
            this.listSchemas.SelectedIndexChanged += new System.EventHandler(this.ddlDatabase_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(6, 20);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(63, 19);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Schema";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(265, 20);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(62, 19);
            this.materialLabel5.TabIndex = 19;
            this.materialLabel5.Text = "Tabelas";
            // 
            // lblTabelas
            // 
            this.lblTabelas.AutoSize = true;
            this.lblTabelas.Depth = 0;
            this.lblTabelas.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTabelas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTabelas.Location = new System.Drawing.Point(265, 316);
            this.lblTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTabelas.Name = "lblTabelas";
            this.lblTabelas.Size = new System.Drawing.Size(94, 19);
            this.lblTabelas.TabIndex = 20;
            this.lblTabelas.Text = "Carregando..";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.materialRadioButton1);
            this.panel2.Controls.Add(this.materialRadioButton2);
            this.panel2.Controls.Add(this.materialRadioButton3);
            this.panel2.Controls.Add(this.materialRadioButton4);
            this.panel2.Controls.Add(this.materialRadioButton5);
            this.panel2.Location = new System.Drawing.Point(24, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(356, 76);
            this.panel2.TabIndex = 16;
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton1.Location = new System.Drawing.Point(245, 0);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(77, 30);
            this.materialRadioButton1.TabIndex = 4;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "Postgre";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton2.Location = new System.Drawing.Point(114, 30);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(76, 30);
            this.materialRadioButton2.TabIndex = 3;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "Firebird";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton3.Location = new System.Drawing.Point(114, 0);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(97, 30);
            this.materialRadioButton3.TabIndex = 2;
            this.materialRadioButton3.TabStop = true;
            this.materialRadioButton3.Text = "SQL Server";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton4
            // 
            this.materialRadioButton4.AutoSize = true;
            this.materialRadioButton4.Depth = 0;
            this.materialRadioButton4.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton4.Location = new System.Drawing.Point(0, 30);
            this.materialRadioButton4.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton4.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton4.Name = "materialRadioButton4";
            this.materialRadioButton4.Ripple = true;
            this.materialRadioButton4.Size = new System.Drawing.Size(69, 30);
            this.materialRadioButton4.TabIndex = 1;
            this.materialRadioButton4.TabStop = true;
            this.materialRadioButton4.Text = "Oracle";
            this.materialRadioButton4.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton5
            // 
            this.materialRadioButton5.AutoSize = true;
            this.materialRadioButton5.Depth = 0;
            this.materialRadioButton5.Font = new System.Drawing.Font("Roboto", 10F);
            this.materialRadioButton5.Location = new System.Drawing.Point(0, 0);
            this.materialRadioButton5.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton5.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton5.Name = "materialRadioButton5";
            this.materialRadioButton5.Ripple = true;
            this.materialRadioButton5.Size = new System.Drawing.Size(67, 30);
            this.materialRadioButton5.TabIndex = 0;
            this.materialRadioButton5.TabStop = true;
            this.materialRadioButton5.Text = "MySql";
            this.materialRadioButton5.UseVisualStyleBackColor = true;
            // 
            // piclinguagem
            // 
            this.piclinguagem.Location = new System.Drawing.Point(481, 40);
            this.piclinguagem.Name = "piclinguagem";
            this.piclinguagem.Size = new System.Drawing.Size(109, 60);
            this.piclinguagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclinguagem.TabIndex = 17;
            this.piclinguagem.TabStop = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(20, 18);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(160, 19);
            this.materialLabel3.TabIndex = 18;
            this.materialLabel3.Text = "Selecione a linguagem";
            // 
            // formWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 486);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.tab);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formWizard";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wizard - Passo a passo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formWizard_FormClosed);
            this.tab.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picsgbd)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclinguagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl tab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialRaisedButton btnExemplo;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRadioButton radioSGBD5;
        private MaterialSkin.Controls.MaterialRadioButton radioSGBD4;
        private MaterialSkin.Controls.MaterialRadioButton radioSGBD2;
        private MaterialSkin.Controls.MaterialRadioButton radioSGBD1;
        private MaterialSkin.Controls.MaterialRadioButton radioSGBD3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConnectionString;
        private MaterialSkin.Controls.MaterialRaisedButton btnconnection;
        private MaterialSkin.Controls.MaterialRaisedButton btnAvancar;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.PictureBox picsgbd;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialCheckBox btnChkTabela;
        private System.Windows.Forms.ListBox listTabelas;
        private MaterialSkin.Controls.MaterialRaisedButton btnAvancarTabelas;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ListBox listSchemas;
        private MaterialSkin.Controls.MaterialLabel lblTabelas;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton4;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton5;
        private System.Windows.Forms.PictureBox piclinguagem;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
    }
}