using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public FolderBrowserDialog Salvar { get { return salvar; } set { salvar = value; } }

        public Form1()
        {
            InitializeComponent();
            ParamtersInput.NomeTabelas = new List<string>();
        }

        /// <summary>
        /// Geração da Entidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdMapeamento = new MD_MapeamentoEntidade().Generate(salvar);
            MessageBox.Show(mdMapeamento.Message);
        }

        private void btnChamadaProc_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdChamdaProc = new MD_ChamadaProc().Generate(salvar);
            MessageBox.Show(mdChamdaProc.Message);
        }

        private void btnProcSql_Click(object sender, EventArgs e)
        {
            SetParamters();
            var mdProc = new MD_Procedure().Generate(salvar);
            MessageBox.Show(mdProc.Message);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            SetParamters();
            var md_connection = new MD_ConnectionString().Connect();
            MessageBox.Show(md_connection.Message);

            if (!md_connection.IsError)
            {
                ddlTabelas.Items.Clear();
                ddlTabelas.Items.AddRange(md_connection.Content.ToArray());
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
            ParamtersInput.Linguagem = radioCsharp.Checked ? 1 : 2;
            ParamtersInput.SGBD = 1;
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


    }
}
