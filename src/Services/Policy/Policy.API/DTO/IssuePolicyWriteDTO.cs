#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using PolicyMicroservice.Models;

namespace PolicyMicroservice.DTO;

public class IssuePolicyCreateDTO
{
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PaymentStatus PaymentStatus { get; set; }

    [Required]
    [JsonPropertyName("PaymentEffectiveDate")]
    public DateTime EffectiveDate { get; set; }

    [Required]
    public decimal CoveredSum { get; set; }

    [Required]
    public decimal DurationInDays { get; set; }
}