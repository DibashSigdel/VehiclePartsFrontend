using System.ComponentModel.DataAnnotations;

namespace VehiclePartsFrontend.Models.Admin;

public class AdminCreatePartCategoryRequestDto
{
    [Required]
    public string CategoryName { get; set; } = string.Empty;
}
