using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Zeus.Core;
using Zeus.Middleware;
using Zeus.Properties;

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
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            ListaTabelas = new List<string>();
            Session.progressBar1 = materialProgressBar1;
            Session.listaStatus = materialListView1;
        }

        public List<string> ListaTabelas { get; set; }

        private void formWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExemplo_Click(object sender, EventArgs e)
        {
            var fc = Application.OpenForms["formConnectionString"];
            if (fc == null)
            {
                new formConnectionString
                {
                    ConnectionString = txtConnectionString,
                    Oracle = radioSGBD1,
                    Sql = radioSGBD2,
                    Mysql = radioSGBD3,
                    Firebird = radioSGBD4,
                    Postgre = radioSGBD5
                }.ShowDialog();
            }
            else
            {
                fc.Close();
                new formConnectionString
                {
                    ConnectionString = txtConnectionString,
                    Oracle = radioSGBD1,
                    Sql = radioSGBD2,
                    Mysql = radioSGBD3,
                    Firebird = radioSGBD4,
                    Postgre = radioSGBD5
                }.Show();
            }
        }

        private void radioSGBD3_CheckedChanged(object sender, EventArgs e)
        {
            picsgbd.Image = Resources.mysql;
        }

        private void radioSGBD1_CheckedChanged(object sender, EventArgs e)
        {
            picsgbd.Image = Resources.oracle;
        }

        private void radioSGBD2_CheckedChanged(object sender, EventArgs e)
        {
            picsgbd.Image = Resources.sqlserver;
        }

        private void radioSGBD4_CheckedChanged(object sender, EventArgs e)
        {
            picsgbd.Image = Resources.firebird;
        }

        private void radioSGBD5_CheckedChanged(object sender, EventArgs e)
        {
            picsgbd.Image = Resources.postgre;
        }

        private void btnconnection_Click(object sender, EventArgs e)
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
            ParamtersInput.DataBase = listSchemas.SelectedItem?.ToString();
            ParamtersInput.ConnectionString = txtConnectionString.Text;
            ParamtersInput.SGBD = radioSGBD1.Checked ? 1 :
                radioSGBD2.Checked ? 2 :
                radioSGBD3.Checked ? 3 :
                radioSGBD4.Checked ? 4 :
                radioSGBD5.Checked ? 5 : 0;
            ParamtersInput.Linguagem = radioCsharp.Checked ? 1 :
                radioJava.Checked ? 2 :
                radioNode.Checked ? 3 : 0;
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            SetParamters();
            var connectionDb = new OrquestradorPingSGBD().Connect();
            if (connectionDb.IsError)
            {
                MessageBox.Show($@"{connectionDb.Message}");
                return;
            }

            listSchemas.Items.Clear();
            listTabelas.Items.Clear();

            switch (ParamtersInput.SGBD)
            {
                case 1:
                case 2:
                case 4:
                    {
                        ListaTabelas = connectionDb.Content;
                        listTabelas.Items.AddRange(ListaTabelas.ToArray());
                        listSchemas.Enabled = false;
                        break;
                    }
                case 3:
                    {
                        ListaTabelas = new List<string>();
                        listSchemas.Items.AddRange(connectionDb.Content.ToArray());
                        listSchemas.SelectedItem = ParamtersInput.DataBase ?? null;
                        listSchemas.Enabled = true;
                        break;
                    }
            }

            lblTabelas.Text = ListaTabelas.Count > 0
                ? $"{ListaTabelas.Count} Tabela(s) disponível(eis)"
                : "Nenhuma tabela disponível.";

            tab.SelectTab(1);
        }

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetParamters();
            var tabelas = new OrquestradorTabelasSGBD().Connect();
            if (tabelas.IsError)
            {
                MessageBox.Show(tabelas.Message);
                return;
            }

            ListaTabelas = tabelas.Content;
            listTabelas.Items.Clear();
            listTabelas.Items.AddRange(ListaTabelas.ToArray());
            lblTabelas.Text = ListaTabelas.Count > 0
                ? $"{ListaTabelas.Count} Tabela(s) disponível(eis)"
                : "Nenhuma tabela disponível.";
        }

        private void btnChkTabela_CheckedChanged(object sender, EventArgs e)
        {
            listTabelas.SelectedItems.Clear();

            listTabelas.Enabled = !btnChkTabela.Checked;
            ParamtersInput.TodasTabelas = btnChkTabela.Checked;

            if (ParamtersInput.TodasTabelas)
                foreach (var item in ListaTabelas)
                    listTabelas.SelectedItems.Add(item);
        }

        private void btnAvancarTabelas_Click(object sender, EventArgs e)
        {
            ParamtersInput.NomeTabelas = new List<string>();

            if (listTabelas.SelectedItems.Count == 0) return;

            if (!ParamtersInput.TodasTabelas)
                foreach (var item in listTabelas.SelectedItems)
                    ParamtersInput.NomeTabelas.Add(item.ToString());
            else
                foreach (var item in listTabelas.Items)
                    ParamtersInput.NomeTabelas.Add(item.ToString());

            tab.SelectTab(2);
        }

        private void checkProcedure_CheckedChanged(object sender, EventArgs e)
        {
            ParamtersInput.Procedure = checkProcedure.Checked;
        }

        private void btnAcesso_Click(object sender, EventArgs e)
        {
            SetParamters();

            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }

            var chamada = new OrquestradorChamada().Generate();
            if (chamada.IsError) MessageBox.Show(chamada.Message);
        }

        private void btnEntidade_Click(object sender, EventArgs e)
        {
            SetParamters();
            var validate = new ValidateBasic().ValidateInput(salvar);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }

            if (ParamtersInput.Linguagem == 3)
            {
                MessageBox.Show("Node JS não possuí mapeamento de Entidade");
                return;
            }

            var mdMapeamento = new OrquestradorMapeamentoEntidade().Generate();
            if (validate.IsError) MessageBox.Show(mdMapeamento.Message);
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            SetParamters();
            var validate = new ValidateBasic().ValidateInput(salvar, true);
            if (validate.IsError)
            {
                MessageBox.Show(validate.Message);
                return;
            }

            var mdProc = new OrquestradorProcedures().Generate();
            if (validate.IsError) MessageBox.Show(mdProc.Message);
        }

        private void radioNode_CheckedChanged(object sender, EventArgs e)
        {
            piclinguagem.Image = Resources.nodejs;
        }

        private void LabelRequisitos_Click(object sender, EventArgs e)
        {
            if (radioNode.Checked)
                Process.Start("https://www.npmjs.com/package/jano-mysql");
        }

        private void radioCsharp_CheckedChanged(object sender, EventArgs e)
        {
            piclinguagem.Image = Resources.csharp;
        }

        private void radioJava_CheckedChanged(object sender, EventArgs e)
        {
            piclinguagem.Image = Resources.java;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            tab.SelectTab(0);
        }

        private void btnVoltarLinguagem_Click(object sender, EventArgs e)
        {
            tab.SelectTab(1);
        }

        private void btnOpcoes_Click(object sender, EventArgs e)
        {
            var fc = Application.OpenForms["formWelcome"];
            if (fc == null)
                new formWelcome().Show();
            else
                fc.Show();

            Hide();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            var fc = Application.OpenForms["formGridConnectionString"];
            if (fc == null)
            {
                new formGridConnectionString
                {
                    ConnectionString = txtConnectionString,

                }.ShowDialog();
            }
            else
            {
                fc.Close();
                new formGridConnectionString
                {
                    ConnectionString = txtConnectionString,

                }.Show();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ParamtersInput.SelectedPath))
            {
                MessageBox.Show("Você ainda não definiu um caminho");
                return;
            }
            Process.Start(ParamtersInput.SelectedPath);
        }
    }
}