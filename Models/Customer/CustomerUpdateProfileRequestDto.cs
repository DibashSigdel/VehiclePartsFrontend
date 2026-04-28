using System.ComponentModel.DataAnnotations;

namespace VehiclePartsFrontend.Models.Customer;

public class CustomerUpdateProfileRequestDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;
    public string? NewPassword { get; set; }
}
