using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using Zeus.Middleware;
using Zeus.Utilidade;
using System;
using Zeus.Core;

namespace Zeus
{
    public partial class formWizard : MaterialForm
    {
        public formWizard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnIniciar_Click(object sender, System.EventArgs e)
        {
            new formPrincipal().Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, System.EventArgs e)
        {
            tab.SelectTab(2);
        }

        private void formWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExemplo_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Form fc = Application.OpenForms["formConnectionString"];
            if (fc == null)
                new formConnectionString()
                {
                    ConnectionString = txtConnectionString,
                    Oracle = radioSGBD1,
                    Sql = radioSGBD2,
                    Mysql = radioSGBD3,
                    Firebird = radioSGBD4,
                    Postgre = radioSGBD5
                }.ShowDialog();
            else
            {
                fc.Close();
                new formConnectionString()
                {
                    ConnectionString = txtConnectionString,
                    Oracle = radioSGBD1,
                    Sql = radioSGBD2,
                    Mysql = radioSGBD3,
                    Firebird = radioSGBD4,
                    Postgre = radioSGBD5
                }.ShowDialog();
            }
        }

        private void radioSGBD3_CheckedChanged(object sender, System.EventArgs e)
        {
            this.picsgbd.Image = Properties.Resources.mysql;
        }

        private void radioSGBD1_CheckedChanged(object sender, System.EventArgs e)
        {
            this.picsgbd.Image = Properties.Resources.oracle;
        }

        private void radioSGBD2_CheckedChanged(object sender, System.EventArgs e)
        {
            this.picsgbd.Image = Properties.Resources.sqlserver;
        }

        private void radioSGBD4_CheckedChanged(object sender, System.EventArgs e)
        {
            this.picsgbd.Image = Properties.Resources.firebird;
        }

        private void radioSGBD5_CheckedChanged(object sender, System.EventArgs e)
        {
            this.picsgbd.Image = Properties.Resources.postgre;

        }

        private void btnconnection_Click(object sender, System.EventArgs e)
        {
            SetParamters();
            var connectionDb = new OrquestradorPingSGBD().Connect();
            if (!connectionDb.IsError)
            {
                MessageBox.Show($@"{connectionDb.Message}");
                return;
            }
            MessageBox.Show(connectionDb.TechnicalMessage ?? connectionDb.Message);
        }

        private void SetParamters()
        {
            ParamtersInput.ConnectionString = txtConnectionString.Text;
            ParamtersInput.SGBD = radioSGBD1.Checked ? 1 : radioSGBD2.Checked ? 2 : radioSGBD3.Checked ? 3 : radioSGBD4.Checked ? 4 : radioSGBD5.Checked ? 5 : 0;
        }
    }
}
