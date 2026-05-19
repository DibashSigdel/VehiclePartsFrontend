namespace VehiclePartsFrontend.Models.Customer;

public class CustomerVehicleOptionDto
{
    public int VehicleId { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
}

public class CustomerSaveVehicleRequestDto
{
    public string VehicleNumber { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = DateTime.UtcNow.Year;
}

public class CustomerAppointmentDto
{
    public int AppointmentId { get; set; }
    public int VehicleId { get; set; }
    public string VehicleLabel { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ServiceNote { get; set; } = string.Empty;
}

public class CustomerBookAppointmentRequestDto
{
    public int VehicleId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string ServiceNote { get; set; } = string.Empty;
}

public class CustomerPartRequestDto
{
    public int PartRequestId { get; set; }
    public string RequestedPartName { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public DateTime RequestDate { get; set; }
    public string RequestStatus { get; set; } = string.Empty;
}

public class CustomerCreatePartRequestDto
{
    public string RequestedPartName { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class CustomerReviewableAppointmentDto
{
    public int AppointmentId { get; set; }
    public string VehicleLabel { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class CustomerReviewDto
{
    public int ReviewId { get; set; }
    public int AppointmentId { get; set; }
    public string VehicleLabel { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
}

public class CustomerSubmitReviewRequestDto
{
    public int AppointmentId { get; set; }
    public int Rating { get; set; } = 5;
    public string Comment { get; set; } = string.Empty;
}

public class CustomerPurchaseHistoryItemDto
{
    public int SalesInvoiceId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentType { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
    public List<CustomerPurchaseHistoryLineDto> Lines { get; set; } = [];
}

public class CustomerPurchaseHistoryLineDto
{
    public string PartName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }
}