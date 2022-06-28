#nullable disable
using System.ComponentModel.DataAnnotations;
namespace Quotes.Models;
public partial class QuotesMaster
{
    [Required]
    public Guid Id { get; set; }
    [Key]
    [Required]
    public int QuotesId { get; set; }

    public int MinBusinessValue { get; set; }
    public int MaxBusinessValue { get; set; }
    [Required]
    public int BusinessValue
    {
        get
        { return this.BusinessValue; }
        set
        {
            if (value > MinBusinessValue && value < MaxBusinessValue)
            {
                this.BusinessValue = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid value.");
            }
        }
    }
    public int MinPropertyValue { get; set; }
    public int MaxPropertyValue { get; set; }
    [Required]
    public int PropertyValue
    {
        get
        { return this.PropertyValue; }
        set
        {
            if (value > MinPropertyValue && value < MaxPropertyValue)
            {
                this.PropertyValue = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid value.");
            }
        }
    }
    [Required]

    public PropertyType PropertyType { get; set; }
    [Required]
    public string QuoteValue { get; set; }

}