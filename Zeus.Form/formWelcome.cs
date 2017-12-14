using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Properties;

namespace Zeus
{
    public partial class formWelcome : MaterialForm
    {
        public formWelcome()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitConfigurations();
        }

        private void formWizard_Click(object sender, System.EventArgs e)
        {
            Form fc = Application.OpenForms["formWizard"];
            if (fc == null)
                new formWizard().Show();
            else
            {
                fc.Show();
            }

            this.Hide();
        }
        
        private void btnProcurar_Click(object sender, System.EventArgs e)
        {
            var r = salvar.ShowDialog();
            if (r == DialogResult.OK)
            {
                txtDestino.Text = salvar.SelectedPath + "\\";
                ParamtersInput.SelectedPath = txtDestino.Text;
            }
            else
            {
                ParamtersInput.SelectedPath = null;
                txtDestino.Text = "";
            }
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            Settings.Default.PrefixoPackage = txtPreFixoPackages.Text;
            Settings.Default.PrefixoProcedure = txtPreFixoProcedures.Text;
            Settings.Default.PrefixoTabela = txtPrefixoTabela.Text;
            Settings.Default.Destino = txtDestino.Text;
            Settings.Default.UnificarOutput = ddlUnificar.Checked;
            Settings.Default.Save();
        }

        private void InitConfigurations()
        {
            chkSkip.Checked = Settings.Default.SkipWelcome;
            txtVersion.Text = Application.ProductVersion;
            txtPreFixoPackages.Text = Settings.Default.PrefixoPackage;
            txtPreFixoProcedures.Text = Settings.Default.PrefixoProcedure;
            txtPrefixoTabela.Text = Settings.Default.PrefixoTabela;
            ddlUnificar.Checked = Settings.Default.UnificarOutput;
            ParamtersInput.SelectedPath = txtDestino.Text = Settings.Default.Destino;
            ParamtersInput.UnificarOutput = ddlUnificar.Checked;
        }

        private void chkSkip_CheckedChanged(object sender, System.EventArgs e)
        {
            Settings.Default.SkipWelcome = chkSkip.Checked;
            Settings.Default.Save();
        }

        private void formWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
