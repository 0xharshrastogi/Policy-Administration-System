#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Quotes.API.Models;

public class QuotesMaster
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public int MinBusinessValue { get; set; }

    [Required]
    public int MaxBusinessValue { get; set; }

    [Required]
    public int MinPropertyValue { get; set; }

    [Required]
    public int MaxPropertyValue { get; set; }

    [Required]
    public string PropertyType { get; set; }

    [Required]
    public string QuoteValue { get; set; }
}