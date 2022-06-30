#nullable disable
using System.Text.Json.Serialization;

using PolicyMicroservice.Models;

namespace Policy.Models;

public class PolicyMaster
{
    public Guid Id { get; set; }

    public string PropertyType { get; set; }

    public CustomerType CustomerType { get; set; }

    public int AssuredSum { get; set; }

    public int Tenure { get; set; }

    public int BusinessValue { get; set; }

    public int PropertyValue { get; set; }

    public string BaseLocation { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PolicyType Type { get; set; }
}