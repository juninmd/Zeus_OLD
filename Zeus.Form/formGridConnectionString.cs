using System;
using MaterialSkin;
using MaterialSkin.Controls;

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
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConnectionString.Text.Trim()))
            {
                listConnection.Items.Add(txtConnectionString.Text);
                txtConnectionString.Text = "";
            }
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

        }
    }
}
