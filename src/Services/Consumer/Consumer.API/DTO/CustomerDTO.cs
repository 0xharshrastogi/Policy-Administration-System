using System.ComponentModel.DataAnnotations;

namespace Consumer.API.DTO;

public class CustomerDTO
{
    [Required]
    public string CustomerName { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [Required]
    public string Email { get; set; }
    public long PhoneNumber { get; set; }
    [MinLength(10), MaxLength(10), Required]
    public string Pan { get; set; }
}