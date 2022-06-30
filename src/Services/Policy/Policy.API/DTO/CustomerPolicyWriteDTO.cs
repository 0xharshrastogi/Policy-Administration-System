#nullable disable

using System.ComponentModel.DataAnnotations;

using PolicyMicroservice.Attributes;

namespace Policy.DTO;

public class CustomerPolicyWriteDTO
{
    [Required]
    public string PolicyName { get; set; }

    [Required]
    [NotDefaultGuid]
    public Guid CustomerId { get; set; }

    [Required]
    [NotDefaultGuid]
    public Guid BusinessId { get; set; }

    [Required]
    [NotDefaultGuid]
    public Guid AgentId { get; set; }
}
