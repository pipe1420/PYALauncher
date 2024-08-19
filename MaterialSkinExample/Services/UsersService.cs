using Npgsql;
using PYALauncherApps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PYALauncherApps.Services
{
    public class UsersService
    {
        private readonly DatabaseService _databaseService;

        public UsersService(DatabaseService databaseService)
        {
            _databaseService = databaseService;
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
            return userPermissions;
        }

        

    }

}
