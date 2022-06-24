#nullable disable
using System.ComponentModel.DataAnnotations;

using Authentication.Models;

namespace Authentication.DTO;

public class AgentCreateDTO : ICredential
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Password { get; set; }
}