using Npgsql;
using PYALauncherApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PYALauncherApps.Services
{
    public class UsersService
    {
        private readonly DatabaseService _databaseService;
        private readonly SupabaseService _supabaseService;

        public UsersService(DatabaseService databaseService, SupabaseService supabaseService)
        {
            _databaseService = databaseService;
            _supabaseService = supabaseService;
        }

        public async Task<bool> CanEditAppsAsync(string userName)
        {
            var userPermissions = await _databaseService.GetUserPermissionsAsync(userName);
            return userPermissions?.CanEditApps ?? false;
        }

        public async Task<bool> CanViewUserTabAsync(string userName)
        {
            var userPermissions = await _databaseService.GetUserPermissionsAsync(userName);
            return userPermissions?.CanViewUserTab ?? false;
        }

        public async Task<List<UserPermissionDisplayItem>> GetAllUserPermissionsAsync()
        {
            var userPermissions = await _databaseService.GetAllUserPermissionsAsync();
            //var userPermissions = await _supabaseService.GetAllUserPermissionsAsync();

            //foreach (var item in userPermissionsSupabase)
            //{
            //    Debug.WriteLine("dataSupabase Item: " + item);
            //}

            //foreach (var item in userPermissions)
            //{
            //    Debug.WriteLine("userPermissions Item: " + item);
            //}

            return userPermissions;
        }

        

    }

}
