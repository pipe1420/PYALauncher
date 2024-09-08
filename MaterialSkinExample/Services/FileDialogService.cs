using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PYALauncherApps.Services
{
    public class FileDialogService
    {
        public string CapturarRutaMsi()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos MSI (*.msi)|*.msi",
                Title = "Seleccione el archivo MSI"
            };

            // Mostrar el diálogo y capturar la ruta si el usuario selecciona un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return null; // Retornar null si no se seleccionó ningún archivo
        }
    }
}
