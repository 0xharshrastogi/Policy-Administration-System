#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Authentication.API.DTO;

public class TokenDTO
{
    [Required]
    public string Token { get; set; }
}