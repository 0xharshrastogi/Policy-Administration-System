#nullable disable
namespace Quotes.Models;
public class Quotes
{
    public Guid Id { get; set; }
    
    public int businessValue { get; set; }
    public int propertyValue { get; set; }
    public string propertyType { get; set; }
    public string quotes { get; set; }

}