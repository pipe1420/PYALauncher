using System;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using MaterialSkin;
using MaterialSkin.Controls;


namespace MaterialSkinExample.Database
{
    public class ConexionFirebase
    {
        public static SetResponse response;
        public static IFirebaseClient client;


        readonly static IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "UjA3em72o72cYkEpgxMWPWLXuwRp1NJhrbdLluIJ",
            BasePath = "https://pyalauncher-default-rtdb.firebaseio.com/"
        };

        public static void CargaConexion()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                Debug.WriteLine("****** Conexion con servidor remoto establecida *****");
            }
            else
            {
                Debug.WriteLine("****** Error de conexion a servidor remoto ******");
            }
        }

        public static async Task<string> ObtieneApps()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("software/");

                if (response != null && response.StatusCode == HttpStatusCode.OK) //200
                {
                    Debug.WriteLine("200 OK: " + response);
                    string jsonResponse = response.Body;

                    return jsonResponse;
                }
                else
                {
                    Debug.WriteLine("Error de solicitud: " + response);
                    return "Error";
                }
            }
            catch (SystemException ex)
            {
                Debug.WriteLine("Error al obtener registros : " + ex);
                return "Error";
            }
        }


        public static async Task<string> ObtieneConfig()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("config/");

                if (response.StatusCode == HttpStatusCode.OK) //200
                {
                    string jsonResponse = response.Body;
                    Debug.WriteLine("200 OK: " + response);
                    return jsonResponse;
                }
                else
                {
                    Debug.WriteLine("Error de solicitud: " + response);
                    return "Error";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener registros : " + ex);
                return "Error";
            }
        }


        


    }
}