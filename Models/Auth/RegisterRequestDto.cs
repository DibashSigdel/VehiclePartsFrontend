using System.ComponentModel.DataAnnotations;

namespace VehiclePartsFrontend.Models.Auth;

public class RegisterRequestDto
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

    [Required]
    public string Role { get; set; } = "Customer";

    public string Address { get; set; } = string.Empty;
}
