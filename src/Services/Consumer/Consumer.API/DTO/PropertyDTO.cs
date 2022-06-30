using System.ComponentModel.DataAnnotations;

using Consumer.API.Models;

namespace Consumer.API.DTO;
public class PropertyDTO
{
    public Guid BusinessID { get; set; }
    public PropertyType PropertyType { get; set; }

    public string Address { get; set; }
    public double Area { get; set; }

    public int BuildingStorey { get; set; }
    public int Age { get; set; }
    public int PropertyValue { get; set; }
}