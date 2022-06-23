using AutoMapper;

using PolicyMicroservice.DTO;
using PolicyMicroservice.Models;

namespace PolicyMicroservice.Profiles;

public class IssuedPolicyProfile : Profile
{
    public IssuedPolicyProfile()
    {
        CreateMap<IssuePolicyCreateDTO, IssuedPolicy>();
    }
}