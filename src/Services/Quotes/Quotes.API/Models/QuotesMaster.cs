#nullable disable
using System.ComponentModel.DataAnnotations;

using Quotes.Models;

namespace Quotes.API.Models;
public class QuotesMaster
{
    [Required]
    public Guid Id { get; set; }
    [Key]
    [Required]
    public int QuotesId { get; set; }

    public int MinBusinessValue { get; set; }

    public int MaxBusinessValue { get; set; }

    [Required]
    public int BusinessValue { get; set; }

    public int MinPropertyValue { get; set; }

    public int MaxPropertyValue { get; set; }

    [Required]
    public int PropertyValue { get; set; }

    [Required]
    public PropertyType PropertyType { get; set; }

    [Required]
    public string QuoteValue { get; set; }
}