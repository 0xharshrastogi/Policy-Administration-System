using System.ComponentModel.DataAnnotations;

namespace Consumer.API.DTO;

public class CustomerDTO
{
    [Required]
    public string CustomerName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(10), MaxLength(10)]
    public string PhoneNumber { get; set; }

    [Required, RegularExpression("[A-Z]{5}[0-9]{4}[A-Z]{1}")]
    public string Pan { get; set; }
}