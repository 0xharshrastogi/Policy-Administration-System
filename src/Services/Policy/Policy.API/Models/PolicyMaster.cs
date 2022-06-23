#nullable disable
namespace PolicyMicroservice.Models;

public class PolicyMaster
{
    public Guid Id { get; set; }

    public string PropertyType { get; set; }

    public CustomerType CustomerType { get; set; }

    public int Tenure { get; set; }

    public decimal BusinessValue { get; set; }

    public decimal PropertyValue { get; set; }

    public string BaseLocation { get; set; }

    public string Type { get; set; }
}