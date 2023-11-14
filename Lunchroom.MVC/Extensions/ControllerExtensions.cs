using Lunchroom.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Lunchroom.MVC.Extensions;

public enum NotificationMessageType
{
    Success,
    Failure,
}

public static class ControllerExtensions
{
    public static void SetNotification(this Controller controller, NotificationMessageType type, string message)
    {
        var notification = new Notification(type, message);
        controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
    }
}