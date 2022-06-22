#nullable disable
namespace PolicyMicroservice.Models;

public class PolicyMaster
{
    public Guid Id { get; set; }

    public string PropertyType { get; set; }

    public string CustomerType { get; set; }

    public TimeSpan Tenure { get; set; }

    public decimal BusinessValue { get; set; }

    public decimal PropertyValue { get; set; }

    public string BaseLocation { get; set; }

    public PolicyMasterType Type { get; set; }
}