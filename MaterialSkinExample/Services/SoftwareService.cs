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
    public class SoftwareService
    {
        private readonly SoftwareModel _softwareModel;
        private DatabaseService _databaseService;
        private SupabaseService _supabaseService;

        public SoftwareService(SoftwareModel softwareModel, DatabaseService databaseService, SupabaseService supabaseService)
        {
            _softwareModel = softwareModel;
            _databaseService = databaseService;
            _supabaseService = supabaseService;
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

        public async Task<bool> DeleteSoftware(int id)
        {
            bool result = await _databaseService.DeleteSoftware(id);

            if (result)
            {
                // Opcional: Remover el software eliminado de la lista en memoria, si es que la estás usando
                var softwareToRemove = _softwareModel.SoftwareList.FirstOrDefault(s => s.Id == id);
                if (softwareToRemove != null)
                {
                    _softwareModel.SoftwareList.Remove(softwareToRemove);
                }
            }

            return result;
        }

        internal async Task<bool> SaveUserPermissions(BindingList<UserPermissionDisplayItem> permissionsList)
        {
            try
            {
                if (permissionsList != null)
                {
                    foreach (var permission in permissionsList)
                    {
                        bool res = await _databaseService.SaveUserPermissionAsync(permission);
                        if (res)
                        {
                            Console.WriteLine($"Permiso de {permission.UserName} guardardado correctamente.");
                        }
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("No hay permisos para guardar.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar permisos: {ex.Message}");
                return false;
            }
        }
    }
}
