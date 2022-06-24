#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Authentication.DTO;

public class AgentLoginDTO
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Password { get; set; }
}