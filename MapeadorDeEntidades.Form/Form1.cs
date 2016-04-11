using MapeadorDeEntidades.Form.Core;
using MapeadorDeEntidades.Form.Middleware;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public SaveFileDialog Salvar { get { return salvar; } set { salvar = value; } }

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Geração da Entidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEntidade_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTabelas.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma tabela");
                return;
            }

            var classe = new CSharpEntity().GerarBody(ddlTabelas.SelectedItem.ToString()).ToString();
            salvar.AddExtension = true;
            salvar.FileName = ddlTabelas.SelectedItem.ToString() + ".cs";
            salvar.DefaultExt = "cs";

            var funcao = salvar.ShowDialog();

            if (funcao == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, classe);
            }
        }



        private void btnProcSharp_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTabelas.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma tabela");
                return;
            }

            var instancia = new CSharpADO(ddlTabelas.SelectedItem.ToString());
            var classe = instancia.GerarBodyCSharpProc().ToString();
            salvar.AddExtension = true;
            salvar.FileName = ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "RequestRepository.cs";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, classe);
            }

            var interfacename = instancia.GerarInterfaceSharProc().ToString();
            salvar.FileName = "I" + ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "RequestRepository.cs";


            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, interfacename);
            }



        }

        private void btnProcSql_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTabelas.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma tabela");
                return;
            }
            var instancia = new ProcOracle(ddlTabelas.SelectedItem.ToString(), new OracleTables().ListarAtributos(ddlTabelas.SelectedItem.ToString()));

            var interfacename = instancia.GerarPackageHeader().ToString();
            salvar.FileName = "I" + ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "Header.sql";


            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, interfacename);
            }

            var body = instancia.GerarPackageBody().ToString();
            salvar.AddExtension = true;
            salvar.FileName = ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "Body.sql";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, body);
            }
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
        }
        private void SetParamters()
        {
            ParamtersInput.ConnectionString = txtConnectionString.Text;
            ParamtersInput.Linguagem = radioCsharp.Checked ? 1 : 2;
            ParamtersInput.NomeTabela = ddlTabelas.SelectedItem?.ToString();
            ParamtersInput.SGBD = 1;
        }

    }
}
