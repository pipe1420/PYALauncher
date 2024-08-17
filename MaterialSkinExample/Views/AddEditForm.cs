using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PYALauncherApps.Controllers;
using System.Security.Policy;

namespace PYALauncherApps.Views
{
    public partial class AddEditForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        MaterialSkin.MaterialListBoxItem materialListBoxItem13 = new MaterialSkin.MaterialListBoxItem();

        public AddEditForm()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Red700, Primary.Red900, Primary.Red100, Accent.Red200, TextShade.WHITE);

            colorSchemeIndex = PYALauncherApps.Properties.Settings.Default.codigoTema;

            bool tst = PYALauncherApps.Properties.Settings.Default.estiloTema;
            updateColor();
            if (tst == true)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            
            
        }

        private void updateColor()
        {
            //These are just example color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red700 : Primary.Red700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red900 : Primary.Red900,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Red100 : Primary.Red100,
                        Accent.Red200,
                        TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
                case 3:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Red700,
                        Primary.Red900,
                        Primary.Red100,
                        Accent.Red200,
                        TextShade.WHITE);
                    break;
            }

            PYALauncherApps.Properties.Settings.Default.codigoTema = colorSchemeIndex;
            PYALauncherApps.Properties.Settings.Default.Save();
            Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Esta seguro que desea eliminar la aplicación?", "Eliminar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Aplicacion eliminada!", "Eliminar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Esta seguro que desea guardar los cambios a la aplicación?", "Guardar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Aplicacion guardada!", "Guardar Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
    }
}
