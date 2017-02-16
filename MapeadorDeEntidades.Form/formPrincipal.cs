using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Middleware;
using Zeus.Properties;
using Zeus.Utilidade;

namespace Zeus
{
    public partial class formPrincipal : System.Windows.Forms.Form
    {
        public FolderBrowserDialog Salvar { get { return salvar; } set { salvar = value; } }

        public formPrincipal()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Som();
            Transparent();
            InitConfigurations();
            Session.lblStatus = lblStatus;
            Session.progressBar1 = progressBar1;
            ParamtersInput.NomeTabelas = new List<string>();
            txtConnectionString.Text = Settings.Default.ConnectionStringDefault;
        }

        private void Transparent()
        {
            var lista = new List<Control>() { groupBox1, groupBox2, groupBox3, groupBox4, groupBox5, groupBox6, groupBox7, groupBox8, groupBox9, groupBox10, groupBox11, groupBox12 };
            foreach (var item in lista)
            {
                Just(item);
            }
            label1.Parent = groupBox12;
            label1.Location = new Point(382, 21);
            label1.BackColor = Color.Transparent;
        }

        private void Just(Control a)
        {
            a.Parent = pictureBox1;
            a.Location = pictureBox1.PointToClient(this.PointToScreen(a.Location));
            a.BackColor = Color.Transparent;
        }

        private void Som()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            SoundPlayer simpleSound = new SoundPlayer($"{path}\\zeus.wav");
            simpleSound.Play();
        }

        #region ### GERAR ###

        /// <summary>
        /// Geração da Entidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdMapeamento = new OrquestradorMapeamentoEntidade().Generate(salvar);
            Util.Status(mdMapeamento.Message + " - " + mdMapeamento.TechnicalMessage);
        }

        private void btnChamadaProc_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdChamdaProc = new OrquestradorChamadaProcedure().Generate(salvar);
            Util.Status(mdChamdaProc.Message + " - " + mdChamdaProc.TechnicalMessage);
        }

        private void btnProcSql_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new OrquestradorProcedures().Generate(salvar);
            Util.Status(mdProc.Message + " - " + mdProc.TechnicalMessage);
        }
        private void btnSequence_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new OrquestradorSequences().Generate(salvar);
            Util.Status(mdProc.Message + " - " + mdProc.TechnicalMessage);
        }
        private void btnBatch_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new OrquestradorBatch().Generate(salvar);
            Util.Status(mdProc.Message);
        }

        #endregion

        private void btnConnection_Click(object sender, EventArgs e)
        {
            SetParamters();
            var connectionDb = new OrquestradorPingSGBD().Connect();
            Util.Status(connectionDb.Message + " - " + connectionDb.TechnicalMessage);
            Util.Barra(100);
            if (!connectionDb.IsError)
            {

                if (ParamtersInput.SGBD != 3)
                {
                    ddlTabelas.Items.Clear();
                    ddlTabelas.Items.AddRange(connectionDb.Content.ToArray());
                    ddlDatabase.Items.Clear();
                    return;
                }

                ddlDatabase.Items.Clear();
                ddlDatabase.Items.AddRange(connectionDb.Content.ToArray());

            }
        }

        private void btnChkTabela_CheckedChanged(object sender, EventArgs e)
        {
            ddlTabelas.Enabled = (btnChkTabela.Checked == false);
            SetParamters();
        }

        private void EventSetParamters(object sender, EventArgs e)
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
            ParamtersInput.DataBase = ddlDatabase?.SelectedItem?.ToString();

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

            ddlDatabase.Enabled = radioSGBD3.Checked;
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

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new OrquestradorTabelasSGBD().Connect();
            ddlTabelas.Items.Clear();
            ddlTabelas.Items.AddRange(mdProc?.Content?.ToArray());
        }

        private void btnConfiguracoes_Click_1(object sender, EventArgs e)
        {
            Util.Barra(0);

            Settings.Default.PrefixoPackage = txtPreFixoPackages.Text;
            Settings.Default.PrefixoProcedure = txtPreFixoProcedures.Text;
            Settings.Default.PrefixoTabela = txtPrefixoTabela.Text;
            Settings.Default.ConnectionStringDefault = txtConnectionString.Text;
            Settings.Default.UnificarOutput = ddlUnificar.SelectedItem?.ToString() == "SIM";
            Settings.Default.Save();

            Util.Status("Valores atualizados");
            Util.Barra(100);
        }

        private void InitConfigurations()
        {
            txtPreFixoPackages.Text = Settings.Default.PrefixoPackage;
            txtPreFixoProcedures.Text = Settings.Default.PrefixoProcedure;
            txtPrefixoTabela.Text = Settings.Default.PrefixoTabela;
            txtConnectionString.Text = Settings.Default.ConnectionStringDefault;
            ddlUnificar.SelectedItem = Settings.Default.UnificarOutput ? "SIM" : "NÃO";
        }
    }
}
