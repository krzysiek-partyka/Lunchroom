using Lunchroom.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Lunchroom.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller, string message, string type)
        {
            var notification = new Notification(type,message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
