using System.ComponentModel.DataAnnotations;

using PolicyMicroservice.Attributes;

namespace PolicyMicroservice.DTO;

public class CustomerPolicyWriteDTO
{
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
