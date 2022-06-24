using System.ComponentModel.DataAnnotations;

using Authentication.Models;

namespace Authentication.DTO;

public class AgentCredential : ICredential
{
    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}