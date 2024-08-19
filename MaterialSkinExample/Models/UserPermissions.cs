using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Models
{
    public class UserPermissions
    {
        public bool CanEditApps { get; set; }
        public bool CanViewUserTab { get; set; }
    }

    public class UserPermissionDisplayItem
    {
        public string UserName { get; set; }
        public bool CanEditApps { get; set; }
        public bool CanViewUserTab { get; set; }
    }


}
