using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYALauncherApps.Models
{
    [Table("userpermissions")]
    public class UserPermissions : BaseModel
    {
        [Column("userid")]
        public int UserID { get; set; }

        [Column("caneditapps")]
        public bool CanEditApps { get; set; }

        [Column("canviewusertab")]
        public bool CanViewUserTab { get; set; }

        public User User { get; set; }
    }



    public class UserPermissionDisplayItem
    {
        public string UserName { get; set; }
        public bool CanEditApps { get; set; }
        public bool CanViewUserTab { get; set; }
    }

    [Table("users")]
    public class User : BaseModel
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("username")]
        public string Username { get; set; }
    }
}
