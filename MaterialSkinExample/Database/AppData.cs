using System;
using System.Collections.Generic;

namespace MaterialSkinExample.Database
{
    public class AppData
    {
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Path_Install { get; set; }
        public string Software { get; set; }
        public string Tag { get; set; }
        public string Verifica_App { get; set; }
        public string Version { get; set; }
    }

    public class RootData
    {
        public Dictionary<string, List<AppData>> Data { get; set; }
    }

    
}