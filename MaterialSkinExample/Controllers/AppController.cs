using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkinExample;
using MaterialSkinExample.Database;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PYALauncherApps.Models;
using PYALauncherApps.Services;

namespace PYALauncherApps.Controllers
{
    public class AppController
    {
        private static SoftwareService _serviceSoftware = new SoftwareService();
        private static MainForm _formulario = new MainForm();
        private static List<Software> _softwareList = new List<Software>();

        public static void Initialize() {
            GetConfigAsync();
        }
        public static void OpenForm()
        {
            Console.WriteLine("OpenForm() ShowDialog");
            //EjecucionPorLapsosAsync();
            _formulario.ShowDialog(); 
        }

        public static async Task GetConfigAsync()
        {
            _softwareList = _serviceSoftware.GetSoftwareListPSQL();
        }

        public static async Task GetSoftwareAsync()
        {
            _softwareList = _serviceSoftware.GetSoftwareListPSQL();
        }

        public static JArray GetAppsServerAsync()
        {
            Debug.WriteLine("\nGetAppsServer1: ");
            JArray latestRecords = _serviceSoftware.GetSoftwareList();
            Debug.WriteLine("\nGetAppsServer2: ");

            return latestRecords;
        }

        public static async Task EjecucionPorLapsosAsync()
        {
            string intervalo = "";
            try
            {
                Console.WriteLine("Obteniendo configuracion");
                //FirebaseRepository.CargaConexion();
                string result = await FirebaseRepository.ObtieneConfig();

                JObject data = JObject.Parse(result);
                JProperty latestProperty = data.Properties().Last();
                JArray latestRecords = (JArray)latestProperty.Value;

                foreach (JObject record in latestRecords)
                {
                    intervalo = (string)record["intervalo_check_segundos"];
                }
                Console.WriteLine("Configuracion cargada, intervalo: " + intervalo);
            }
            catch (Exception ex)
            {
                //Carga en segundos intervalo de sincronizacion predeterminado
                intervalo = "900";//15 minutos
                Console.WriteLine("Error de configuracion, intervalo default: " + intervalo);
                Console.WriteLine("Error de configuracion: " + ex);
            }

            while (true)
            {
                //MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Sincronizando...", "OK", true);
                //SnackBarMessage.Show(this);

                //var registros = await GetAppsServerAsync();
                
                Console.WriteLine("Configuracion usando intervalo: " + intervalo);
                var registros = await FirebaseRepository.ObtieneApps();

                JObject data = JObject.Parse(registros);
                JProperty latestProperty = data.Properties().Last();
                JArray latestRecords = (JArray)latestProperty.Value;

                Console.WriteLine("\nlatestRecords: ");

                //_serviceSoftware.SetSoftwareList((JArray)registros);
                //var listadoSW = _serviceSoftware.GetSoftwareList();
                //Console.Write(listadoSW);

                // Llamar a tu método async Task aquí
                await _formulario.loadCardAsync(latestRecords);
                await Task.Delay(TimeSpan.FromSeconds(int.Parse(intervalo)));

                try
                {
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError while: " + ex);
                }

            }
        }
        
        


        
    }
}
