namespace VehiclePartsFrontend.Models.Staff;

public class StaffSalesInvoiceLineRequestDto
{
    public int PartId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public class StaffCreateSalesInvoiceRequestDto
{
    public int CustomerId { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public string PaymentType { get; set; } = "Cash";
    public string PaymentStatus { get; set; } = "Paid";
    public DateTime? CreditDueDate { get; set; }
    public decimal DiscountAmount { get; set; }
    public List<StaffSalesInvoiceLineRequestDto> Items { get; set; } = [];
}

public class StaffSalesInvoiceResponseDto
{
    public int SalesInvoiceId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public decimal SubTotal { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentType { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
    public bool LoyaltyDiscountApplied { get; set; }
    public decimal LoyaltyDiscountAmount { get; set; }
}

public class StaffSalesInvoiceListItemDto
{
    public int SalesInvoiceId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public DateTime InvoiceDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentType { get; set; } = string.Empty;
    public string PaymentStatus { get; set; } = string.Empty;
}

public class StaffSendInvoiceEmailResponseDto
{
    public int SalesInvoiceId { get; set; }
    public bool Sent { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class StaffCustomerOptionDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class StaffPartSaleOptionDto
{
    public int PartId { get; set; }
    public string PartName { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public int QuantityOnHand { get; set; }
}