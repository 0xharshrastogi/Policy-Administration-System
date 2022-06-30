
using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;
public enum PropertyType
{
    Rental = 0,
    Building = 1,
    Land = 2
}
public class Property
{
    [Key]
    public Guid PropertyID { get; set; }

    public Guid BusinessID { get; set; }

    public virtual Business Business { get; set; }

    public PropertyType PropertyType { get; set; }

    public string Address { get; set; }

    public double AreaInSqFt { get; set; }

    public int BuildingStorey { get; set; }

    public int BuildingAge { get; set; }

    public int PropertyValue { get; set; }
}
