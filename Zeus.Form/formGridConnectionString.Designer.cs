namespace Zeus
{
    partial class formGridConnectionString
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
            this.btnSalvar = new MaterialSkin.Controls.MaterialRaisedButton();
            this.listConnection = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExcluir = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtConnectionString = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.AutoSize = true;
            this.btnSalvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSalvar.Depth = 0;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.btnSalvar.Icon = null;
            this.btnSalvar.Location = new System.Drawing.Point(450, 86);
            this.btnSalvar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Primary = true;
            this.btnSalvar.Size = new System.Drawing.Size(72, 36);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // listConnection
            // 
            this.listConnection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listConnection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listConnection.Depth = 0;
            this.listConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.listConnection.FullRowSelect = true;
            this.listConnection.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listConnection.Location = new System.Drawing.Point(12, 149);
            this.listConnection.MouseLocation = new System.Drawing.Point(-1, -1);
            this.listConnection.MouseState = MaterialSkin.MouseState.OUT;
            this.listConnection.Name = "listConnection";
            this.listConnection.OwnerDraw = true;
            this.listConnection.Size = new System.Drawing.Size(601, 312);
            this.listConnection.TabIndex = 17;
            this.listConnection.UseCompatibleStateImageBehavior = false;
            this.listConnection.View = System.Windows.Forms.View.Details;
            this.listConnection.DoubleClick += new System.EventHandler(this.listConnection_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Adicione sua connection String ;)";
            this.columnHeader1.Width = 570;
            // 
            // btnExcluir
            // 
            this.btnExcluir.AutoSize = true;
            this.btnExcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExcluir.Depth = 0;
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))));
            this.btnExcluir.Icon = null;
            this.btnExcluir.Location = new System.Drawing.Point(528, 86);
            this.btnExcluir.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Primary = true;
            this.btnExcluir.Size = new System.Drawing.Size(75, 36);
            this.btnExcluir.TabIndex = 16;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Depth = 0;
            this.txtConnectionString.Hint = "";
            this.txtConnectionString.Location = new System.Drawing.Point(13, 93);
            this.txtConnectionString.MaxLength = 32767;
            this.txtConnectionString.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.PasswordChar = '\0';
            this.txtConnectionString.ReadOnly = false;
            this.txtConnectionString.SelectedText = "";
            this.txtConnectionString.SelectionLength = 0;
            this.txtConnectionString.SelectionStart = 0;
            this.txtConnectionString.Size = new System.Drawing.Size(432, 23);
            this.txtConnectionString.TabIndex = 18;
            this.txtConnectionString.TabStop = false;
            this.txtConnectionString.UseSystemPasswordChar = false;
            // 
            // formGridConnectionString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 483);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.listConnection);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Name = "formGridConnectionString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Connection Strings Salvas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton btnSalvar;
        private MaterialSkin.Controls.MaterialListView listConnection;
        private MaterialSkin.Controls.MaterialRaisedButton btnExcluir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConnectionString;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}