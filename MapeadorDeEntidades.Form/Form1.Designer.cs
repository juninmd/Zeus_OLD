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
            this.btnGerar = new System.Windows.Forms.Button();
            this.salvar = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnProcSharp = new System.Windows.Forms.Button();
            this.btnProcSql = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlTabelas
            // 
            this.ddlTabelas.FormattingEnabled = true;
            this.ddlTabelas.Location = new System.Drawing.Point(56, 55);
            this.ddlTabelas.Name = "ddlTabelas";
            this.ddlTabelas.Size = new System.Drawing.Size(389, 21);
            this.ddlTabelas.TabIndex = 0;
            // 
            // btnGerar
            // 
            this.btnGerar.Location = new System.Drawing.Point(80, 115);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(163, 23);
            this.btnGerar.TabIndex = 1;
            this.btnGerar.Text = "Gerar Entidade";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Antique Olive CompactPS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "MAPEADOR DE ENTIDADES ZEUS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 231);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnProcSharp
            // 
            this.btnProcSharp.Location = new System.Drawing.Point(80, 144);
            this.btnProcSharp.Name = "btnProcSharp";
            this.btnProcSharp.Size = new System.Drawing.Size(163, 23);
            this.btnProcSharp.TabIndex = 4;
            this.btnProcSharp.Text = "Gerar Procedure c#";
            this.btnProcSharp.UseVisualStyleBackColor = true;
            this.btnProcSharp.Click += new System.EventHandler(this.btnProcSharp_Click);
            // 
            // btnProcSql
            // 
            this.btnProcSql.Location = new System.Drawing.Point(80, 173);
            this.btnProcSql.Name = "btnProcSql";
            this.btnProcSql.Size = new System.Drawing.Size(163, 23);
            this.btnProcSql.TabIndex = 5;
            this.btnProcSql.Text = "Gerar Procedure SQL";
            this.btnProcSql.UseVisualStyleBackColor = true;
            this.btnProcSql.Click += new System.EventHandler(this.btnProcSql_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 230);
            this.Controls.Add(this.btnProcSql);
            this.Controls.Add(this.btnProcSharp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.ddlTabelas);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlTabelas;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.SaveFileDialog salvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnProcSharp;
        private System.Windows.Forms.Button btnProcSql;
    }
}

