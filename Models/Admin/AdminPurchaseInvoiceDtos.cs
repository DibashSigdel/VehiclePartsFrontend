namespace VehiclePartsFrontend.Models.Admin;

public class AdminPurchaseInvoiceLineRequestDto
{
    public int PartId { get; set; }
    public decimal CostPrice { get; set; }
    public int QuantityBought { get; set; }
}

public class AdminCreatePurchaseInvoiceRequestDto
{
    public int VendorId { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public List<AdminPurchaseInvoiceLineRequestDto> Items { get; set; } = [];
}

public class AdminPurchaseInvoiceResponseDto
{
    public int PurchaseInvoiceId { get; set; }
    public int VendorId { get; set; }
    public string VendorName { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public decimal TotalCost { get; set; }
}

public class AdminPurchaseInvoiceListItemDto
{
    public int PurchaseInvoiceId { get; set; }
    public string VendorName { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public decimal TotalCost { get; set; }
    public int LineCount { get; set; }
}
