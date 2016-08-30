using System.Windows.Forms;
using MapeadorDeEntidades.Form.Properties;

namespace MapeadorDeEntidades.Form
{
    public partial class formConfiguracoes : System.Windows.Forms.Form
    {
        public formConfiguracoes()
        {
            InitializeComponent();
            txtPreFixoPackages.Text = Settings.Default.PrefixoPackage;
            txtPreFixoProcedures.Text = Settings.Default.PrefixoProcedure;
            txtConnectionString.Text = Settings.Default.ConnectionStringDefault;
        }

        private void btnAplicar_Click(object sender, System.EventArgs e)
        {
            Settings.Default.PrefixoPackage = txtPreFixoPackages.Text;
            Settings.Default.PrefixoProcedure = txtPreFixoProcedures.Text;
            Settings.Default.ConnectionStringDefault = txtConnectionString.Text;
            Settings.Default.Save();

            MessageBox.Show("Valores atualizados", "Sucesso", MessageBoxButtons.OK); 
            this.Close();
        }

    }
}
