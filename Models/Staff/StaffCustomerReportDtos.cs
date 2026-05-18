namespace VehiclePartsFrontend.Models.Staff;

public class StaffCustomerReportsDto
{
    public List<StaffCustomerReportRowDto> TopSpenders { get; set; } = [];
    public List<StaffCustomerReportRowDto> RegularCustomers { get; set; } = [];
    public List<StaffOverdueCreditRowDto> OverdueCredits { get; set; } = [];
}

public class StaffCustomerReportRowDto
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int InvoiceCount { get; set; }
    public decimal TotalSpent { get; set; }
    public DateTime? LastPurchaseDate { get; set; }
}

public class StaffOverdueCreditRowDto
{
    public int SalesInvoiceId { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime? CreditDueDate { get; set; }
    public int DaysOverdue { get; set; }
}