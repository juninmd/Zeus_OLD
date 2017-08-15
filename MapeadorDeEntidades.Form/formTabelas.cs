using System;
using System.Collections.Generic;
using Zeus.Core;

namespace Zeus
{
    public partial class formTabelas : System.Windows.Forms.Form
    {
        public formTabelas(List<string> tabelas)
        {
            InitializeComponent();
            ddlTabelas.Items.AddRange(tabelas.ToArray());
        }

        private void btnSelecionar_Click(object sender, System.EventArgs e)
        {
            ParamtersInput.NomeTabelas.Clear();

            if (!ParamtersInput.TodasTabelas)
            {
                foreach (var item in ddlTabelas.SelectedItems)
                {
                    ParamtersInput.NomeTabelas.Add(item.ToString());
                }

            }
            else
            {
                foreach (var item in ddlTabelas.Items)
                {
                    ParamtersInput.NomeTabelas.Add(item.ToString());
                }
            }

            Utilidade.Util.Status(ParamtersInput.NomeTabelas.Count == 0
                ? $"Nenhuma tabela foi selecionada."
                : $"{ParamtersInput.NomeTabelas.Count} tabela(s) selecionadas.");

            Close();
        }

        private void btnChkTabela_CheckedChanged(object sender, EventArgs e)
        {
            ddlTabelas.Enabled = !btnChkTabela.Checked;
            ParamtersInput.TodasTabelas = btnChkTabela.Checked;
        }
    }
}
