using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using Zeus.Core;
using Zeus.Middleware;
using Zeus.Properties;
using Zeus.Utilidade;

namespace Zeus
{
    public partial class formPrincipal : Form
    {
        public List<string> TabelasBD { get; set; }

        public formPrincipal()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            Som();
            InitConfigurations();
            Session.progressBar1 = progressBar1;
            Session.listaStatus = listaStatus;
            TabelasBD = new List<string>();
            ParamtersInput.NomeTabelas = new List<string>();
            txtConnectionString.Text = Settings.Default.ConnectionStringDefault;
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
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }
            var mdMapeamento = new OrquestradorMapeamentoEntidade().Generate();
            Util.Status(mdMapeamento.Message + " - " + mdMapeamento.TechnicalMessage);
        }

        private void btnChamadaProc_Click(object sender, EventArgs e)
        {
            SetParamters();
            var x = MessageBox.Show("Deseja efetuar as chamadas via Procedure?", "Qual forma de acesso?", MessageBoxButtons.YesNoCancel);
            ParamtersInput.Procedure = x == DialogResult.Yes;
            if (x == DialogResult.Cancel)
                return;

            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }

            var chamada = new OrquestradorChamada().Generate();
            Util.Status(chamada.Message + " - " + chamada.TechnicalMessage);
        }

        private void btnProcSql_Click(object sender, EventArgs e)
        {
            SetParamters();
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }
            var mdProc = new OrquestradorProcedures().Generate();
            Util.Status(mdProc.Message + " - " + mdProc.TechnicalMessage);
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            SetParamters();
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }
            var mdProc = new OrquestradorBatch().Generate();
            Util.Status(mdProc.Message);
        }

        #endregion

        private void btnConnection_Click(object sender, EventArgs e)
        {
            SetParamters();
            var connectionDb = new OrquestradorPingSGBD().Connect();
            Util.Barra(100);
            if (!connectionDb.IsError)
            {
                MessageBox.Show($@"{connectionDb.Message}");
                Util.Status(connectionDb.TechnicalMessage ?? connectionDb.Message);
                switch (ParamtersInput.SGBD)
                {
                    case 1:
                    case 2:
                    case 4:
                        TabelasBD.Clear();
                        TabelasBD = connectionDb.Content;
                        lblTabelas.Text = TabelasBD.Count > 0 ? $"{TabelasBD.Count} Tabela(s) disponível(eis)" : "Nenhuma tabela disponível.";
                        ddlDatabase.Items.Clear();
                        return;
                }

                ddlDatabase.Items.Clear();
                ddlDatabase.Items.AddRange(connectionDb.Content.ToArray());
                return;
            }
            Util.Status(connectionDb.TechnicalMessage ?? connectionDb.Message);
            MessageBox.Show(connectionDb.TechnicalMessage ?? connectionDb.Message);
        }



        private void EventSetParamters(object sender, EventArgs e)
        {
            SetParamters();
        }

        private void CleanParamters(object sender, EventArgs e)
        {
            SetParamters();
            TabelasBD.Clear();
            ddlDatabase.Items.Clear();
            ddlDatabase.Text = "";
            ParamtersInput.NomeTabelas = new List<string>();
        }

        private void SetParamters()
        {
            ParamtersInput.ConnectionString = txtConnectionString.Text;
            ParamtersInput.Linguagem = radioCsharp.Checked ? 1 : radioJava.Checked ? 2 : radioNode.Checked ? 3 : 0;
            ParamtersInput.SGBD = radioSGBD1.Checked ? 1 : radioSGBD2.Checked ? 2 : radioSGBD3.Checked ? 3 : radioSGBD4.Checked ? 4 : radioSGBD5.Checked ? 5 : 0;
            ParamtersInput.DataBase = ddlDatabase?.SelectedItem?.ToString();
            ddlDatabase.Enabled = radioSGBD3.Checked || radioSGBD5.Checked;

            ParamtersInput.Prefixos = new Prefixos
            {
                Package = txtPreFixoPackages.Text,
                Procedure = txtPreFixoProcedures.Text,
                Tabela = txtPrefixoTabela.Text
            };
        }


        private void btnExemplo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form fc = Application.OpenForms["formConnectionString"];
            if (fc == null)
                new formConnectionString()
                {
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
                    Oracle = radioSGBD1,
                    Sql = radioSGBD2,
                    Mysql = radioSGBD3,
                    Firebird = radioSGBD4,
                    Postgre = radioSGBD5
                }.ShowDialog();
            }
        }

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Util.Status($"Schema Selecionado: {ddlDatabase.SelectedItem}");

            SetParamters();
            var mdProc = new OrquestradorTabelasSGBD().Connect();
            TabelasBD.Clear();
            if (mdProc.IsError)
            {
                MessageBox.Show(mdProc.Message);
                return;
            }
            TabelasBD = mdProc.Content;
            var status = TabelasBD.Count > 0 ? $"{TabelasBD.Count} Tabela(s) disponível(eis)" : "Nenhuma tabela disponível.";
            lblTabelas.Text = status;
            Util.Status(status);
        }

        private void CheckLanguage(object sender, EventArgs e)
        {
            if (radioCsharp.Checked)
            {
                btnEntidade.Visible = btnChamadaProc.Visible = btnProc.Visible = true;
            }
            else if (radioJava.Checked)
            {
                btnEntidade.Visible = btnChamadaProc.Visible = btnProc.Visible = true;
            }
            else if (radioNode.Checked)
            {
                btnChamadaProc.Visible = btnProc.Visible = true;
                btnEntidade.Visible = false;
            }
        }

        private void btnConfiguracoes_Click_1(object sender, EventArgs e)
        {
            Util.Barra(0);

            Settings.Default.PrefixoPackage = txtPreFixoPackages.Text;
            Settings.Default.PrefixoProcedure = txtPreFixoProcedures.Text;
            Settings.Default.PrefixoTabela = txtPrefixoTabela.Text;
            Settings.Default.ConnectionStringDefault = txtConnectionString.Text;
            Settings.Default.Destino = txtDestino.Text;
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
            ParamtersInput.SelectedPath = txtDestino.Text = Settings.Default.Destino;
            ParamtersInput.UnificarOutput = (string)ddlUnificar.SelectedItem == "SIM";
            txtConnectionString.Focus();
        }

        private void btnDestino_Click(object sender, EventArgs e)
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

        private void btnSelecionarTabelas_Click(object sender, EventArgs e)
        {
            if (TabelasBD.Count == 0)
            {
                MessageBox.Show("Nenhuma tabela disponível");
                return;
            }

            new formTabelas(TabelasBD).ShowDialog();
        }

        private void btnLimparStatus_Click(object sender, EventArgs e)
        {
            listaStatus.Items.Clear();
        }

        private void formPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

