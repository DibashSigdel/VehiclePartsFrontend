using System.ComponentModel.DataAnnotations;

namespace VehiclePartsFrontend.Models.Staff;

public class StaffRegisterCustomerRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    [Required]
    public string VehicleNumber { get; set; } = string.Empty;

    [Required]
    public string Brand { get; set; } = string.Empty;

    [Required]
    public string Model { get; set; } = string.Empty;

    [Range(1900, 2100)]
    public int Year { get; set; } = DateTime.UtcNow.Year;
}
