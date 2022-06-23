#nullable disable
using System.ComponentModel.DataAnnotations;
namespace Quotes.Models;
public class QuotesMaster
{
    public Guid Id { get; set; }

    public int MinBusinessValue { get; set; }
    public int MaxBusinessValue { get; set; }
    public int BusinessValue { get
    {return this.BusinessValue;}
     set{
        if(value>MinBusinessValue && value<MaxBusinessValue)
        this.BusinessValue=value;
    } }
    public int MinPropertyValue { get; set; }
    public int MaxPropertyValue { get; set; }
    public int PropertyValue { get
    {return this.PropertyValue;}
     set{
        if(value>MinPropertyValue && value<MaxPropertyValue)
        this.PropertyValue=value;
    } } 
    public string PropertyType { get; set; }
    public string quoteValue { get; set; }

}