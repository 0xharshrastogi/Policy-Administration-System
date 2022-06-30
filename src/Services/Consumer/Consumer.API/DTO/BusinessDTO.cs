using System.ComponentModel.DataAnnotations;

using Consumer.API.Models;

namespace Consumer.API.DTO;

public class BusinessDTO
{
    [Required]
    public Guid CustomerID { get; set; }
    [Required]
    public string BusinessName { get; set; }
    [Required]
    public BusinessType BusinessType { get; set; }
    [Required]
    public int TotalEmployees { get; set; }
    [Required]
    public int AnnualTurnover { get; set; }
    [Required]
    [Range(1, 10)]
    public int BusinessValue { get; set; }
}