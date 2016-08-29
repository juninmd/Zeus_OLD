using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form
{
    public partial class formPrincipal : System.Windows.Forms.Form
    {
        public FolderBrowserDialog Salvar { get { return salvar; } set { salvar = value; } }

        public formPrincipal()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Som();
            Session.lblStatus = lblStatus;
            Session.progressBar1 = progressBar1;
            ParamtersInput.NomeTabelas = new List<string>();
        }

        private void Som()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer simpleSound = new SoundPlayer($"{path}\\zeus.wav");
            simpleSound.Play();
        }

        /// <summary>
        /// Geração da Entidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdMapeamento = new OrquestradorMapeamentoEntidade().Generate(salvar);
            MessageBox.Show(mdMapeamento.Message);
        }

        private void btnChamadaProc_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdChamdaProc = new OrquestradorChamadaProcedure().Generate(salvar);
            MessageBox.Show(mdChamdaProc.Message);
        }

        private void btnProcSql_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new OrquestradorProcedures().Generate(salvar);
            MessageBox.Show(mdProc.Message);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            SetParamters();
            var connectionDb = new OrquestradorPingSGBD().Connect();
            MessageBox.Show(connectionDb.Message + "\n" + connectionDb.TechnicalMessage);

            if (!connectionDb.IsError)
            {
                ddlTabelas.Items.Clear();
                ddlTabelas.Items.AddRange(connectionDb.Content.ToArray());
            }
        }

        private void btnChkTabela_CheckedChanged(object sender, EventArgs e)
        {
            ddlTabelas.Enabled = (btnChkTabela.Checked == false);
            SetParamters();

        }

        private void ddlTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParamters();
        }

        private void radioSGBD_CheckedChanged(object sender, EventArgs e)
        {
            SetParamters();
        }

        private void radioCsharp_CheckedChanged(object sender, EventArgs e)
        {
            SetParamters();
        }

        private void radioJava_CheckedChanged(object sender, EventArgs e)
        {
            SetParamters();
        }

        private void SetParamters()
        {
            ParamtersInput.NomeTabelas.Clear();
            ParamtersInput.ConnectionString = txtConnectionString.Text;
            ParamtersInput.Linguagem = radioCsharp.Checked ? 1 : radioJava.Checked ? 2 : radioNode.Checked ? 3 : 0;
            ParamtersInput.SGBD = radioSGBD1.Checked ? 1 : radioSGBD2.Checked ? 2 : radioSGBD3.Checked ? 3 : 0;
            ParamtersInput.TodasTabelas = btnChkTabela.Checked;

            if (ParamtersInput.TodasTabelas)
            {
                foreach (var item in ddlTabelas.Items)
                {
                    ParamtersInput.NomeTabelas.Add(item.ToString());
                }
            }
            else if (ddlTabelas.SelectedItem != null)
            {
                ParamtersInput.NomeTabelas.Add(ddlTabelas.SelectedItem.ToString());
            }
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            SetParamters();

        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form fc = Application.OpenForms["formConnectionString"];
            if (fc == null)
                new formConnectionString().Show();
            else
            {
                fc.Close();
                new formConnectionString().Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
