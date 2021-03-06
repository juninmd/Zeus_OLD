﻿using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Zeus.Core;
using Zeus.Properties;

namespace Zeus
{
    public partial class formWelcome : MaterialForm
    {
        public formWelcome()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitConfigurations();
        }

        private void formWizard_Click(object sender, EventArgs e)
        {
            var fc = Application.OpenForms["formWizard"];
            if (fc == null)
                new formWizard().Show();
            else
                fc.Show();

            Hide();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Settings.Default.PrefixoPackage = txtPreFixoPackages.Text;
            Settings.Default.PrefixoProcedure = txtPreFixoProcedures.Text;
            Settings.Default.PrefixoTabela = txtPrefixoTabela.Text;
            Settings.Default.UnificarOutput = ddlUnificar.Checked;
            Settings.Default.Save();
        }

        private void InitConfigurations()
        {
            chkSkip.Checked = Settings.Default.SkipWelcome;
            txtVersion.Text = Application.ProductVersion;
            txtPreFixoPackages.Text = Settings.Default.PrefixoPackage;
            txtPreFixoProcedures.Text = Settings.Default.PrefixoProcedure;
            txtPrefixoTabela.Text = Settings.Default.PrefixoTabela;
            ddlUnificar.Checked = Settings.Default.UnificarOutput;
            ParamtersInput.UnificarOutput = ddlUnificar.Checked;
        }

        private void chkSkip_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.SkipWelcome = chkSkip.Checked;
            Settings.Default.Save();
        }

        private void formWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}