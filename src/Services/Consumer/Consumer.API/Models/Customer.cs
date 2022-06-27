using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;

public class Customer
{
    [Key]
    public Guid CustomerID { get; set; }
    public string CustomerName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    [MinLength(10), MaxLength(10), Required]
    public string Pan { get; set; }
}