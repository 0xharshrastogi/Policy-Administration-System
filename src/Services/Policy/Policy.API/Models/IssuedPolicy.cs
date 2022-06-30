using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using PolicyMicroservice.Models;

namespace Policy.Models;

public class IssuedPolicy
{
    public Guid Id { get; set; }

    [ForeignKey(name: nameof(CustomerPolicy))]
    public Guid PolicyId { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentStatus PaymentStatus { get; set; }

    /// <summary>
    /// Date At Which Policy Was Issued
    /// </summary>
    public DateTime EffectiveDate { get; set; }

    public decimal CoveredSum { get; set; }

    /// <summary>
    /// Duration of policy in Number Of Days
    /// </summary>
    public int Duration { get; set; }
}