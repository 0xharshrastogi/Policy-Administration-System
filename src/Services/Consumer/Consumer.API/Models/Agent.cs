//#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class ConsumersAgent
{
    [Key]
    public Guid AgentID { get; set; }
    [Required]
    public String UserName { get; set; }

    [Required]
    public String Password { get; set; }
}