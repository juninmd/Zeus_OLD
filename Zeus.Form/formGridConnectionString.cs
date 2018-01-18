using System;
using MaterialSkin;
using MaterialSkin.Controls;
using Zeus.Core;
using System.IO;
using System.Collections.Generic;

namespace Zeus
{
    public partial class formGridConnectionString : MaterialForm
    {
        public MaterialSingleLineTextField ConnectionString { get; set; }

        public formGridConnectionString()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            LoadConnections();
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConnectionString.Text.Trim()))
            {
                listConnection.Items.Add(txtConnectionString.Text);
                txtConnectionString.Text = "";
            }

            SaveConnections();
        }

        private void LoadConnections()
        {
            listConnection.Items.Clear();
            if (!File.Exists(Tratamentos.PathConnectionString()))
                return;

            var connections = File.ReadAllLines(Tratamentos.PathConnectionString());
            foreach (var item in connections)
            {
                listConnection.Items.Add(item);
            }

        }

        private void SaveConnections()
        {
            if (File.Exists(Tratamentos.PathConnectionString()))
                File.Delete(Tratamentos.PathConnectionString());

            var listConnections = new List<string>();

            for (int i = 0; i < listConnection.Items.Count; i++)
            {
                listConnections.Add(listConnection.Items[i].Text);
            }

            File.WriteAllLines(Tratamentos.PathConnectionString(), listConnections);

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            for (var i = listConnection.Items.Count - 1; i >= 0; i--)
            {
                if (listConnection.Items[i].Selected)
                {
                    listConnection.Items[i].Remove();
                }
            }

            SaveConnections();
        }

        private void listConnection_DoubleClick(object sender, EventArgs e)
        {
            ConnectionString.Text = listConnection.SelectedItems[0].Text.ToString();
            Close();
        }
    }
}
