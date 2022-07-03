using System.ComponentModel.DataAnnotations;

namespace Consumer.API.DTO;
public class UpdatePropertyDTO
{
    [Required]
    public Guid PropertyID { get; set; }
    [Required]
    public string PropertyType { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public double AreaInSqFt { get; set; }
    [Required]
    public int BuildingStorey { get; set; }
    [Required]
    public int BuildingAge { get; set; }
    [Required]
    public int PropertyValue { get; set; }
}