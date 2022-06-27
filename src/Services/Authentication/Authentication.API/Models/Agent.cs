#nullable disable

using System.ComponentModel.DataAnnotations;
namespace Authentication.Models;

[Index(nameof(UserName), IsUnique = true)]
public class Agent : ICredential
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string UserName { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 3)]
    public string Password { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 3)]
    public string Salt { get; set; }
}