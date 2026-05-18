namespace VehiclePartsFrontend.Models.Admin;

public class AdminNotificationDto
{
    public int NotificationId { get; set; }
    public string NotificationType { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }
}

public class LowStockAlertDto
{
    public int PartId { get; set; }
    public string PartName { get; set; } = string.Empty;
    public int QuantityOnHand { get; set; }
}

public class SystemMonitoringRunDto
{
    public int LowStockNotificationsCreated { get; set; }
    public int CreditReminderEmailsSent { get; set; }
    public List<LowStockAlertDto> LowStockParts { get; set; } = [];
    public string Message { get; set; } = string.Empty;
}