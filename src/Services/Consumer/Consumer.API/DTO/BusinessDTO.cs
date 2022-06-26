using System.ComponentModel.DataAnnotations;

namespace Consumer.API.DTO;

public class BusinessDTO
{
    [Required]
    public Guid CustomerID { get; set; }
    [Required]
    public Guid BusinessTypeID { get; set; }
    [Required]
    public int TotalEmployees { get; set; }
    [Required]
    public int AnnualTurnover { get; set; }
    [Required]
    public int BusinessValue { get; set; }
}