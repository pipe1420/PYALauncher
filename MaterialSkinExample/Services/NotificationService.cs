using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PYALauncherApps.Models;

namespace PYALauncherApps.Services
{
    public class NotificationService
    {
        Notification _noti = new Notification();

        public void SetNotificacion(string message)
        {
            _noti.messageToShow = message;

        }
    }
}
