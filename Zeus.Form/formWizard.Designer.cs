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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOpcoes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExemplo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioSGBD5 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD4 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioSGBD3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtConnectionString = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnconnection = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAvancar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.picsgbd = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVoltarTabelas = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblTabelas = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.listSchemas = new System.Windows.Forms.ListBox();
            this.btnAvancarTabelas = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnChkTabela = new MaterialSkin.Controls.MaterialCheckBox();
            this.listTabelas = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.materialListView1 = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.btnVoltarLinguagem = new MaterialSkin.Controls.MaterialRaisedButton();
            this.labelRequisitos = new MaterialSkin.Controls.MaterialLabel();
            this.btnEntidade = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAcesso = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnProc = new MaterialSkin.Controls.MaterialRaisedButton();
            this.checkProcedure = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.piclinguagem = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioJava = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioCsharp = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioNode = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.salvar = new System.Windows.Forms.FolderBrowserDialog();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picsgbd)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclinguagem)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Depth = 0;
            this.tab.Location = new System.Drawing.Point(-1, 119);
            this.tab.MouseState = MaterialSkin.MouseState.HOVER;
            this.tab.Name = "tab";
            this.tab.Padding = new System.Drawing.Point(2, 2);
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(668, 368);
            this.tab.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOpcoes);
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
            this.tabPage1.Size = new System.Drawing.Size(660, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Banco";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOpcoes
            // 
            this.btnOpcoes.AutoSize = true;
            this.btnOpcoes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpcoes.Depth = 0;
            this.btnOpcoes.Icon = null;
            this.btnOpcoes.Location = new System.Drawing.Point(3, 305);
            this.btnOpcoes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpcoes.Name = "btnOpcoes";
            this.btnOpcoes.Primary = true;
            this.btnOpcoes.Size = new System.Drawing.Size(104, 36);
            this.btnOpcoes.TabIndex = 17;
            this.btnOpcoes.Text = "Tela Inicial";
            this.btnOpcoes.UseVisualStyleBackColor = true;
            this.btnOpcoes.Click += new System.EventHandler(this.btnOpcoes_Click);
            // 
            // btnExemplo
            // 
            this.btnExemplo.AutoSize = true;
            this.btnExemplo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExemplo.Depth = 0;
            this.btnExemplo.Icon = null;
            this.btnExemplo.Location = new System.Drawing.Point(482, 230);
            this.btnExemplo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExemplo.Name = "btnExemplo";
            this.btnExemplo.Primary = true;
            this.btnExemplo.Size = new System.Drawing.Size(28, 36);
            this.btnExemplo.TabIndex = 16;
            this.btnExemplo.Text = "?";
            this.btnExemplo.UseVisualStyleBackColor = true;
            this.btnExemplo.Click += new System.EventHandler(this.btnExemplo_Click);
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
            // txtConnectionString
            // 
            this.txtConnectionString.Depth = 0;
            this.txtConnectionString.Hint = "";
            this.txtConnectionString.Location = new System.Drawing.Point(24, 201);
            this.txtConnectionString.MaxLength = 32767;
            this.txtConnectionString.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.PasswordChar = '\0';
            this.txtConnectionString.ReadOnly = false;
            this.txtConnectionString.SelectedText = "";
            this.txtConnectionString.SelectionLength = 0;
            this.txtConnectionString.SelectionStart = 0;
            this.txtConnectionString.Size = new System.Drawing.Size(627, 23);
            this.txtConnectionString.TabIndex = 6;
            this.txtConnectionString.TabStop = false;
            this.txtConnectionString.UseSystemPasswordChar = false;
            // 
            // btnconnection
            // 
            this.btnconnection.AutoSize = true;
            this.btnconnection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnconnection.Depth = 0;
            this.btnconnection.Icon = null;
            this.btnconnection.Location = new System.Drawing.Point(513, 230);
            this.btnconnection.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnconnection.Name = "btnconnection";
            this.btnconnection.Primary = true;
            this.btnconnection.Size = new System.Drawing.Size(138, 36);
            this.btnconnection.TabIndex = 13;
            this.btnconnection.Text = "Testar Conexão";
            this.btnconnection.Click += new System.EventHandler(this.btnconnection_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.AutoSize = true;
            this.btnAvancar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAvancar.Depth = 0;
            this.btnAvancar.Icon = null;
            this.btnAvancar.Location = new System.Drawing.Point(572, 305);
            this.btnAvancar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Primary = true;
            this.btnAvancar.Size = new System.Drawing.Size(85, 36);
            this.btnAvancar.TabIndex = 12;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
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
            this.materialLabel1.Size = new System.Drawing.Size(198, 19);
            this.materialLabel1.TabIndex = 9;
            this.materialLabel1.Text = "Selecione o banco de dados";
            // 
            // picsgbd
            // 
            this.picsgbd.Location = new System.Drawing.Point(503, 57);
            this.picsgbd.Name = "picsgbd";
            this.picsgbd.Size = new System.Drawing.Size(109, 60);
            this.picsgbd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picsgbd.TabIndex = 8;
            this.picsgbd.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnVoltarTabelas);
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
            this.tabPage2.Size = new System.Drawing.Size(660, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tabelas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnVoltarTabelas
            // 
            this.btnVoltarTabelas.AutoSize = true;
            this.btnVoltarTabelas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoltarTabelas.Depth = 0;
            this.btnVoltarTabelas.Icon = null;
            this.btnVoltarTabelas.Location = new System.Drawing.Point(3, 305);
            this.btnVoltarTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoltarTabelas.Name = "btnVoltarTabelas";
            this.btnVoltarTabelas.Primary = true;
            this.btnVoltarTabelas.Size = new System.Drawing.Size(73, 36);
            this.btnVoltarTabelas.TabIndex = 27;
            this.btnVoltarTabelas.Text = "Voltar";
            this.btnVoltarTabelas.UseVisualStyleBackColor = true;
            this.btnVoltarTabelas.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // lblTabelas
            // 
            this.lblTabelas.AutoSize = true;
            this.lblTabelas.Depth = 0;
            this.lblTabelas.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTabelas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTabelas.Location = new System.Drawing.Point(368, 3);
            this.lblTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTabelas.Name = "lblTabelas";
            this.lblTabelas.Size = new System.Drawing.Size(94, 19);
            this.lblTabelas.TabIndex = 20;
            this.lblTabelas.Text = "Carregando..";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(268, 3);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(62, 19);
            this.materialLabel5.TabIndex = 19;
            this.materialLabel5.Text = "Tabelas";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(3, 3);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(63, 19);
            this.materialLabel2.TabIndex = 18;
            this.materialLabel2.Text = "Schema";
            // 
            // listSchemas
            // 
            this.listSchemas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listSchemas.FormattingEnabled = true;
            this.listSchemas.Location = new System.Drawing.Point(3, 34);
            this.listSchemas.Name = "listSchemas";
            this.listSchemas.Size = new System.Drawing.Size(257, 260);
            this.listSchemas.TabIndex = 17;
            this.listSchemas.SelectedIndexChanged += new System.EventHandler(this.ddlDatabase_SelectedIndexChanged);
            // 
            // btnAvancarTabelas
            // 
            this.btnAvancarTabelas.AutoSize = true;
            this.btnAvancarTabelas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAvancarTabelas.Depth = 0;
            this.btnAvancarTabelas.Icon = null;
            this.btnAvancarTabelas.Location = new System.Drawing.Point(572, 305);
            this.btnAvancarTabelas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAvancarTabelas.Name = "btnAvancarTabelas";
            this.btnAvancarTabelas.Primary = true;
            this.btnAvancarTabelas.Size = new System.Drawing.Size(85, 36);
            this.btnAvancarTabelas.TabIndex = 16;
            this.btnAvancarTabelas.Text = "Avançar";
            this.btnAvancarTabelas.UseVisualStyleBackColor = true;
            this.btnAvancarTabelas.Click += new System.EventHandler(this.btnAvancarTabelas_Click);
            // 
            // btnChkTabela
            // 
            this.btnChkTabela.AutoSize = true;
            this.btnChkTabela.Depth = 0;
            this.btnChkTabela.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnChkTabela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnChkTabela.Location = new System.Drawing.Point(427, 309);
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
            // listTabelas
            // 
            this.listTabelas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listTabelas.FormattingEnabled = true;
            this.listTabelas.Location = new System.Drawing.Point(266, 34);
            this.listTabelas.Name = "listTabelas";
            this.listTabelas.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listTabelas.Size = new System.Drawing.Size(370, 260);
            this.listTabelas.TabIndex = 13;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.materialListView1);
            this.tabPage3.Controls.Add(this.materialLabel6);
            this.tabPage3.Controls.Add(this.btnVoltarLinguagem);
            this.tabPage3.Controls.Add(this.labelRequisitos);
            this.tabPage3.Controls.Add(this.btnEntidade);
            this.tabPage3.Controls.Add(this.btnAcesso);
            this.tabPage3.Controls.Add(this.btnProc);
            this.tabPage3.Controls.Add(this.checkProcedure);
            this.tabPage3.Controls.Add(this.materialLabel3);
            this.tabPage3.Controls.Add(this.piclinguagem);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 20);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(660, 344);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Linguagens";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // materialListView1
            // 
            this.materialListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialListView1.CausesValidation = false;
            this.materialListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.materialListView1.Depth = 0;
            this.materialListView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.materialListView1.ForeColor = System.Drawing.Color.Maroon;
            this.materialListView1.FullRowSelect = true;
            this.materialListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.materialListView1.Location = new System.Drawing.Point(3, 261);
            this.materialListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialListView1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialListView1.MultiSelect = false;
            this.materialListView1.Name = "materialListView1";
            this.materialListView1.OwnerDraw = true;
            this.materialListView1.Scrollable = false;
            this.materialListView1.ShowGroups = false;
            this.materialListView1.Size = new System.Drawing.Size(654, 80);
            this.materialListView1.TabIndex = 29;
            this.materialListView1.UseCompatibleStateImageBehavior = false;
            this.materialListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Log";
            this.columnHeader1.Width = 654;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(23, 186);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(36, 19);
            this.materialLabel6.TabIndex = 21;
            this.materialLabel6.Text = "SQL";
            // 
            // btnVoltarLinguagem
            // 
            this.btnVoltarLinguagem.AutoSize = true;
            this.btnVoltarLinguagem.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnVoltarLinguagem.Depth = 0;
            this.btnVoltarLinguagem.Icon = null;
            this.btnVoltarLinguagem.Location = new System.Drawing.Point(584, 219);
            this.btnVoltarLinguagem.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnVoltarLinguagem.Name = "btnVoltarLinguagem";
            this.btnVoltarLinguagem.Primary = true;
            this.btnVoltarLinguagem.Size = new System.Drawing.Size(73, 36);
            this.btnVoltarLinguagem.TabIndex = 26;
            this.btnVoltarLinguagem.Text = "Voltar";
            this.btnVoltarLinguagem.UseVisualStyleBackColor = true;
            this.btnVoltarLinguagem.Click += new System.EventHandler(this.btnVoltarLinguagem_Click);
            // 
            // labelRequisitos
            // 
            this.labelRequisitos.AutoSize = true;
            this.labelRequisitos.Depth = 0;
            this.labelRequisitos.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelRequisitos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRequisitos.Location = new System.Drawing.Point(108, 142);
            this.labelRequisitos.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRequisitos.Name = "labelRequisitos";
            this.labelRequisitos.Size = new System.Drawing.Size(467, 19);
            this.labelRequisitos.TabIndex = 24;
            this.labelRequisitos.Text = "Obs: Consulte os requisitos de cada linguagem ou framework (Aqui)";
            this.labelRequisitos.Click += new System.EventHandler(this.LabelRequisitos_Click);
            // 
            // btnEntidade
            // 
            this.btnEntidade.AutoSize = true;
            this.btnEntidade.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEntidade.Depth = 0;
            this.btnEntidade.Icon = null;
            this.btnEntidade.Location = new System.Drawing.Point(519, 90);
            this.btnEntidade.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEntidade.Name = "btnEntidade";
            this.btnEntidade.Primary = true;
            this.btnEntidade.Size = new System.Drawing.Size(132, 36);
            this.btnEntidade.TabIndex = 23;
            this.btnEntidade.Text = "Gerar Entidade";
            this.btnEntidade.UseVisualStyleBackColor = true;
            this.btnEntidade.Click += new System.EventHandler(this.btnEntidade_Click);
            // 
            // btnAcesso
            // 
            this.btnAcesso.AutoSize = true;
            this.btnAcesso.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAcesso.Depth = 0;
            this.btnAcesso.Icon = null;
            this.btnAcesso.Location = new System.Drawing.Point(393, 90);
            this.btnAcesso.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAcesso.Name = "btnAcesso";
            this.btnAcesso.Primary = true;
            this.btnAcesso.Size = new System.Drawing.Size(120, 36);
            this.btnAcesso.TabIndex = 22;
            this.btnAcesso.Text = "Gerar Acesso";
            this.btnAcesso.UseVisualStyleBackColor = true;
            this.btnAcesso.Click += new System.EventHandler(this.btnAcesso_Click);
            // 
            // btnProc
            // 
            this.btnProc.AutoSize = true;
            this.btnProc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnProc.Depth = 0;
            this.btnProc.Icon = null;
            this.btnProc.Location = new System.Drawing.Point(24, 208);
            this.btnProc.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnProc.Name = "btnProc";
            this.btnProc.Primary = true;
            this.btnProc.Size = new System.Drawing.Size(213, 36);
            this.btnProc.TabIndex = 20;
            this.btnProc.Text = "Gerar Crud de Procedures";
            this.btnProc.UseVisualStyleBackColor = true;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // checkProcedure
            // 
            this.checkProcedure.AutoSize = true;
            this.checkProcedure.Depth = 0;
            this.checkProcedure.Font = new System.Drawing.Font("Roboto", 10F);
            this.checkProcedure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkProcedure.Location = new System.Drawing.Point(24, 77);
            this.checkProcedure.Margin = new System.Windows.Forms.Padding(0);
            this.checkProcedure.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkProcedure.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkProcedure.Name = "checkProcedure";
            this.checkProcedure.Ripple = true;
            this.checkProcedure.Size = new System.Drawing.Size(235, 30);
            this.checkProcedure.TabIndex = 19;
            this.checkProcedure.Text = "Realizar chamadas via Procedure";
            this.checkProcedure.UseVisualStyleBackColor = true;
            this.checkProcedure.CheckedChanged += new System.EventHandler(this.checkProcedure_CheckedChanged);
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
            // piclinguagem
            // 
            this.piclinguagem.Location = new System.Drawing.Point(439, 10);
            this.piclinguagem.Name = "piclinguagem";
            this.piclinguagem.Size = new System.Drawing.Size(136, 74);
            this.piclinguagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piclinguagem.TabIndex = 17;
            this.piclinguagem.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioJava);
            this.panel2.Controls.Add(this.radioCsharp);
            this.panel2.Controls.Add(this.radioNode);
            this.panel2.Location = new System.Drawing.Point(24, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 34);
            this.panel2.TabIndex = 16;
            // 
            // radioJava
            // 
            this.radioJava.AutoSize = true;
            this.radioJava.Depth = 0;
            this.radioJava.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioJava.Location = new System.Drawing.Point(238, 0);
            this.radioJava.Margin = new System.Windows.Forms.Padding(0);
            this.radioJava.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioJava.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioJava.Name = "radioJava";
            this.radioJava.Ripple = true;
            this.radioJava.Size = new System.Drawing.Size(58, 30);
            this.radioJava.TabIndex = 4;
            this.radioJava.TabStop = true;
            this.radioJava.Text = "Java";
            this.radioJava.UseVisualStyleBackColor = true;
            this.radioJava.CheckedChanged += new System.EventHandler(this.radioJava_CheckedChanged);
            // 
            // radioCsharp
            // 
            this.radioCsharp.AutoSize = true;
            this.radioCsharp.Depth = 0;
            this.radioCsharp.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioCsharp.Location = new System.Drawing.Point(177, 0);
            this.radioCsharp.Margin = new System.Windows.Forms.Padding(0);
            this.radioCsharp.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioCsharp.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioCsharp.Name = "radioCsharp";
            this.radioCsharp.Ripple = true;
            this.radioCsharp.Size = new System.Drawing.Size(46, 30);
            this.radioCsharp.TabIndex = 2;
            this.radioCsharp.TabStop = true;
            this.radioCsharp.Text = "C#";
            this.radioCsharp.UseVisualStyleBackColor = true;
            this.radioCsharp.CheckedChanged += new System.EventHandler(this.radioCsharp_CheckedChanged);
            // 
            // radioNode
            // 
            this.radioNode.AutoSize = true;
            this.radioNode.Depth = 0;
            this.radioNode.Font = new System.Drawing.Font("Roboto", 10F);
            this.radioNode.Location = new System.Drawing.Point(0, 0);
            this.radioNode.Margin = new System.Windows.Forms.Padding(0);
            this.radioNode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioNode.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioNode.Name = "radioNode";
            this.radioNode.Ripple = true;
            this.radioNode.Size = new System.Drawing.Size(158, 30);
            this.radioNode.TabIndex = 0;
            this.radioNode.TabStop = true;
            this.radioNode.Text = "Javascript (Node JS)";
            this.radioNode.UseVisualStyleBackColor = true;
            this.radioNode.CheckedChanged += new System.EventHandler(this.radioNode_CheckedChanged);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.tab;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Enabled = false;
            this.materialTabSelector1.Location = new System.Drawing.Point(-1, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(670, 49);
            this.materialTabSelector1.TabIndex = 5;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(12, 59);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(642, 5);
            this.materialProgressBar1.TabIndex = 6;
            // 
            // formWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 486);
            this.Controls.Add(this.materialProgressBar1);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picsgbd)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.piclinguagem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialTabControl tab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialCheckBox btnChkTabela;
        private System.Windows.Forms.ListBox listTabelas;
        private MaterialSkin.Controls.MaterialRaisedButton btnAvancarTabelas;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.ListBox listSchemas;
        private MaterialSkin.Controls.MaterialLabel lblTabelas;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialRadioButton radioJava;
        private MaterialSkin.Controls.MaterialRadioButton radioCsharp;
        private MaterialSkin.Controls.MaterialRadioButton radioNode;
        private System.Windows.Forms.PictureBox piclinguagem;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialCheckBox checkProcedure;
        private MaterialSkin.Controls.MaterialRaisedButton btnProc;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialRaisedButton btnAcesso;
        private MaterialSkin.Controls.MaterialRaisedButton btnEntidade;
        private MaterialSkin.Controls.MaterialLabel labelRequisitos;
        private System.Windows.Forms.FolderBrowserDialog salvar;
        private MaterialSkin.Controls.MaterialRaisedButton btnVoltarLinguagem;
        private MaterialSkin.Controls.MaterialRaisedButton btnVoltarTabelas;
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
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private MaterialSkin.Controls.MaterialRaisedButton btnOpcoes;
    }
}