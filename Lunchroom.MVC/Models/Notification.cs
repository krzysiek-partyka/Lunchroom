using Lunchroom.MVC.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lunchroom.MVC.Models;

public sealed record Notification(
    [JsonConverter(typeof(StringEnumConverter))]
    NotificationMessageType Type,
    string Message);