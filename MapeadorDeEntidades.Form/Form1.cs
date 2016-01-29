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

        private List<EntidadeTabela> InstanciaAtributos(string nomeTabela)
        {
            return new Query().ListarAtributos(nomeTabela);
        }

        private string GetTypeAtribute(string tipoOracle)
        {
            switch (tipoOracle)
            {
                case "DATE":
                    return "DateTime";
                case "VARCHAR2":
                    return "string";
                case "NUMBER":
                    return "long";
                default:
                    return "String";
            }
        }
        private string IsNullabe(string tipo, string aceitaNull)
        {
            return tipo != "VARCHAR2" && aceitaNull == "Y" ? "?" : "";
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ddlTabelas.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma tabela");
                return;
            }

            var classe = GerarBody(ddlTabelas.SelectedItem.ToString()).ToString();
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

        public StringBuilder GerarBody(string nomeTabela)
        {
            var classe = new StringBuilder();
            classe.Append("using System;" + Environment.NewLine + Environment.NewLine);
            classe.Append("namespace MapeadorDeEntidades.Form" + Environment.NewLine);
            classe.Append("{" + Environment.NewLine);
            classe.Append($"    public class {nomeTabela}" + Environment.NewLine);
            classe.Append("    {" + Environment.NewLine + Environment.NewLine);

            var atributos = InstanciaAtributos(nomeTabela);
            foreach (var item in atributos)
            {

                var corpo = new StringBuilder();
                corpo.Append("         /// <summary>" + Environment.NewLine);
                corpo.Append($"         /// {item.COMMENTS}" + Environment.NewLine);
                corpo.Append("         /// </summary>" + Environment.NewLine);
                corpo.Append($"         public {GetTypeAtribute(item.DATA_TYPE)+ IsNullabe(item.DATA_TYPE,item.NULLABLE)} {item.COLUMN_NAME} {{ get; set; }}" + Environment.NewLine);
                corpo.Append(Environment.NewLine);
                classe.Append(corpo);
            }
            classe.Append("    }" + Environment.NewLine);
            classe.Append("}" + Environment.NewLine);

            return classe;
        }
    }
}
