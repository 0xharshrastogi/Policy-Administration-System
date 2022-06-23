using AutoMapper;

using PolicyMicroservice.DTO;
using PolicyMicroservice.Models;

namespace PolicyMicroservice.Profiles;

public class PolicyProfile : Profile
{
    public PolicyProfile()
    {
        CreateMap<CustomerPolicyWriteDTO, CustomerPolicy>();
    }
}
