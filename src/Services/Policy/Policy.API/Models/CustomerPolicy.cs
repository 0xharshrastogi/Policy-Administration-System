#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PolicyMicroservice.Models;

public class CustomerPolicy
{
    [Key]
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid BusinessId { get; set; }

    public Guid AgentId { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PolicyStatus Status { get; set; } = PolicyStatus.Initiated;
}