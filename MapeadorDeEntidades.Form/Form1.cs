using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapeadorDeEntidades.Form
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public SaveFileDialog Salvar { get { return salvar; } set { salvar = value; } }

        public Form1()
        {
            InitializeComponent();

            var tabelas = InstanciaListaTabelas().OrderBy(x => x);
            foreach (var item in tabelas)
            {
                ddlTabelas.Items.Add(item);
            }

        }

        private List<string> InstanciaListaTabelas() { return new Query().ListaTabelas(); }
       
        /// <summary>
        /// Geração da Entidade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTabelas.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma tabela");
                return;
            }

            var classe = new MapeadorEntidade().GerarBody(ddlTabelas.SelectedItem.ToString()).ToString();
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

            var instancia = new MapeadorProcSharp(ddlTabelas.SelectedItem.ToString());
            var classe = instancia.GerarBodyCSharpProc().ToString();
            salvar.AddExtension = true;
            salvar.FileName = ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower()+"RequestRepository.cs";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, classe);
            }

            var interfacename = instancia.GerarInterfaceSharProc().ToString();
            salvar.FileName = "I"+ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "RequestRepository.cs";


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

            var instancia = new MapeadorProcSQL(ddlTabelas.SelectedItem.ToString());
            var body = instancia.GerarPackageBody().ToString();
            salvar.AddExtension = true;
            salvar.FileName = ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "Body.sql";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, body);
            }

            var interfacename = instancia.GerarPackageHeader().ToString();
            salvar.FileName = "I" + ddlTabelas.SelectedItem.ToString().Replace("MAG_T_PDL", "").Replace("_", "").ToLower() + "Header.sql";


            if (salvar.ShowDialog() == DialogResult.OK)
            {
                var local = salvar.FileName;
                File.WriteAllText(local, interfacename);
            }

        }
    }
}
