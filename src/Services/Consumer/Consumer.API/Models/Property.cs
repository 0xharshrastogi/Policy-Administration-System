namespace Consumer.API.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum PropertyType
{
    Rental,
    Building,
    Land
}
public class Property
{

    [Key]
    public Guid PropertyID { get; set; }
    public Guid BusinessID { get; set; }
    public virtual Business Business { get; set; }

    public PropertyType PropertyType { get; set; }

    public string Address { get; set; }

    /*  [ForeignKey("PropertyTypeID")]
      public virtual PropertyMaster PropertyMaster { get; set; }
  */
    public double Area { get; set; }

    public int BuildingStorey { get; set; }
    public int Age { get; set; }
    public int PropertyValue { get; set; }
}
