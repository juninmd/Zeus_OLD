using System;
using System.Windows.Forms;

namespace Zeus
{
    public partial class formConnectionString : System.Windows.Forms.Form
    {
        public formConnectionString()
        {
            InitializeComponent();
            OcultaTexto();
        }

        public TextBox FormPrincipal { get; set; }

        public RadioButton Oracle { get; set; }
        public RadioButton Sql { get; set; }
        public RadioButton Mysql { get; set; }
        public RadioButton Firebird { get; set; }
        public RadioButton Postgre { get; set; }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ResetChecked();
            if (String.IsNullOrEmpty(ddlDatabase.Text))
            {
                MessageBox.Show(@"Por favor, selecione algum banco de dados");
                return;
            }
            switch (ddlDatabase.Text)
            {
                case "Oracle":
                    //User Id=USR_BIRL;Data Source=localhost;Password=!USR_BIRL!
                    FormPrincipal.Text = $"User Id={txt1.Text};Data Source={txt2.Text};Password={txt3.Text}";
                    Oracle.Checked = true;
                    break;
                case "SQL Server":
                    //Server=localhost;Database=Aula1;Trusted_Connection=True
                    FormPrincipal.Text = $"Server={txt1.Text};uid={txt2.Text};pwd={txt3.Text};database={txt4.Text}";
                    Sql.Checked = true;
                    break;
                case "MYSQL":
                    //Server=localhost;Uid=mysql;Pwd=;Port=5500
                    FormPrincipal.Text = $"Server={txt1.Text};Uid={txt2.Text};Pwd={txt3.Text};Port={txt4.Text}";
                    Mysql.Checked = true;
                    break;
                case "Firebird":
                    FormPrincipal.Text = $"User={txt1.Text};Password={txt2.Text};Database={txt3.Text};DataSource={txt4.Text};Port={txt5.Text}";
                    Firebird.Checked = true;
                    break;
                case "Postgre":
                    FormPrincipal.Text = $"Host={txt1.Text};Database={txt2.Text};User ID={txt3.Text};Password={txt4.Text};Port={txt5.Text}";
                    Postgre.Checked = true;
                    break;
            }

            this.Close();
        }

        private void ChangeDatabase()
        {
            OcultaTexto();

            switch (ddlDatabase.Text)
            {
                case "Oracle":
                    {
                        lbl1.Text = "User ID";
                        lbl2.Text = "Data Source";
                        lbl3.Text = "Password";
                        lbl3.Visible = lbl2.Visible = lbl1.Visible = true;
                        txt1.Visible = txt2.Visible = txt3.Visible = true;
                        return;
                    }
                case "SQL Server":
                    {
                        lbl1.Text = "Server";
                        lbl2.Text = "Uid";
                        lbl3.Text = "Password";
                        lbl4.Text = "Database";
                        lbl4.Visible = lbl3.Visible = lbl2.Visible = lbl1.Visible = true;
                        txt1.Visible = txt2.Visible = txt3.Visible = txt4.Visible = true;
                        return;
                    }
                case "MYSQL":
                    {
                        lbl1.Text = "Server";
                        lbl2.Text = "Uid";
                        lbl3.Text = "Password";
                        lbl4.Text = "Port";
                        lbl4.Visible = lbl3.Visible = lbl2.Visible = lbl1.Visible = true;
                        txt1.Visible = txt2.Visible = txt3.Visible = txt4.Visible = true;
                        return;
                    }
                case "Firebird":
                    {
                        lbl1.Text = "User";
                        lbl2.Text = "Password";
                        lbl3.Text = "Database";
                        lbl4.Text = "DataSource";
                        lbl5.Text = "Port";
                        lbl5.Visible = lbl4.Visible = lbl3.Visible = lbl2.Visible = lbl1.Visible = true;
                        txt1.Visible = txt2.Visible = txt3.Visible = txt4.Visible = txt5.Visible = true;
                        return;
                    }
                case "Postgre":
                    {
                        lbl1.Text = "Host";
                        lbl2.Text = "Database";
                        lbl3.Text = "User ID";
                        lbl4.Text = "Password";
                        lbl5.Text = "Port";
                        lbl5.Visible = lbl4.Visible = lbl3.Visible = lbl2.Visible = lbl1.Visible = true;
                        txt1.Visible = txt2.Visible = txt3.Visible = txt4.Visible = txt5.Visible = true;
                        return;
                    }

            }
        }

        private void OcultaTexto()
        {
            lbl1.Visible = lbl2.Visible = lbl3.Visible = lbl4.Visible = lbl5.Visible = false;
            txt1.Visible = txt2.Visible = txt3.Visible = txt4.Visible = txt5.Visible = false;
            txt1.Text = txt2.Text = txt3.Text = txt4.Text = txt5.Text = "";
        }

        private void ResetChecked()
        {
            Oracle.Checked = Sql.Checked = Mysql.Checked = Firebird.Checked = Postgre.Checked = false;
        }

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDatabase();
        }
    }
}
