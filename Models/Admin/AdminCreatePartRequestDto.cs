using System.ComponentModel.DataAnnotations;

namespace VehiclePartsFrontend.Models.Admin;

public class AdminCreatePartRequestDto
{
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string PartName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public decimal SellingPrice { get; set; }
    public int ReorderLevel { get; set; } = 10;
    public bool IsActive { get; set; } = true;
    public int QuantityOnHand { get; set; }
}
