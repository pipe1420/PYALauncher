using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PYALauncherApps.Models;

namespace PYALauncherApps.Services
{
    //public class SoftwareService
    //{
        //SoftwareList _software = new SoftwareList();

        //public void SetSoftwareList(JArray message)
        //{
        //    _software.ListSoftware = message;
        //    Debug.WriteLine("SetSoftwareList: " + message);
        //}

        //public JArray GetSoftwareList()
        //{
        //    return _software.ListSoftware;
        //}

        //public List<Software> GetSoftwareListPSQL()
        //{
        //    return _software.ListSoftwarePSQL;
        //}
    //}

    public class SoftwareService
    {
        private readonly SoftwareModel _softwareModel;
        private DatabaseService _databaseService;

        public SoftwareService(SoftwareModel softwareModel, DatabaseService databaseService)
        {
            _softwareModel = softwareModel;
            _databaseService = databaseService;
        }

        public List<Software> GetSoftwareList()
        {
            return _softwareModel.SoftwareList;
        }

        public string GetSoftwareName()
        {
            return _softwareModel.SoftwareName;
        }

        public string GetSoftwareDescipcion()
        {
            return _softwareModel.Descripcion;
        }

        public void SetSoftwareList(List<Software> softwareList)
        {
            _softwareModel.SoftwareList = softwareList;
        }

        public void SetSoftwareName(string softwareName)
        {
            _softwareModel.SoftwareName = softwareName;
        }

        public void SetSoftwareDescripcion(string descripcion)
        {
            _softwareModel.Descripcion = descripcion;
        }

        public async Task<Software> FindSoftware(string softwareName)
        {
            return await _databaseService.FindSoftware(softwareName);
        }

        // Método para cargar máquinas de un software específico
        public async Task<List<MachineDisplayItem>> LoadSoftwareMachines(string softwareName)
        {
            var software = await _databaseService.FindSoftware(softwareName);

            if (software != null && software.Machines != null)
            {
                // Carga las máquinas en la interfaz gráfica
                var machines = new List<MachineDisplayItem>();
                machines  = LoadMachines(software.Machines);
                
                return machines;
            }
            else
            {
                // Manejar el caso donde el software no fue encontrado o no tiene máquinas asociadas
                MessageBox.Show("No se encontraron máquinas para este software.");
                return null;
            }
        }

        // Método para cargar las máquinas en el DataGridView
        public List<MachineDisplayItem> LoadMachines(Dictionary<string, Machine> machines)
        {
            var machineList = machines.Select(m => new MachineDisplayItem
            {
                MachineKey = m.Key,
                Name = m.Value.Name,
                User = m.Value.User
            }).ToList();


            return machineList;
        }

        public async Task<bool> UpdateSoftware(Software software)
        {
            try
            {
                // Llama al método de la base de datos para actualizar o insertar el software
                bool result = await _databaseService.InsertUpdateSoftware(software);
                return result;
            }
            catch (Exception ex)
            {
                // Maneja la excepción según sea necesario (puedes loguearla, mostrar un mensaje, etc.)
                Debug.WriteLine($"Error al actualizar el software: {ex.Message}");
                return false;
            }
        }

    }
}
