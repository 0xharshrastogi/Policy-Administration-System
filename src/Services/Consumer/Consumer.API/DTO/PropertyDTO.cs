using System.ComponentModel.DataAnnotations;
namespace Consumer.API.DTO;
public class PropertyDTO
{
    public Guid BusinessID { get; set; }
    public Guid PropertyTypeID { get; set; }
    public double Area { get; set; }

    public int BuildingStorey { get; set; }
    public int BuildingAge { get; set; }
    public int PropertyValue { get; set; }
}