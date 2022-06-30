using AutoMapper;

using Policy.Models;

using PolicyMicroservice.DTO;

namespace Policy.Profiles;

public class IssuedPolicyProfile : Profile
{
    public IssuedPolicyProfile()
    {
        CreateMap<IssuePolicyCreateDTO, IssuedPolicy>();
    }
}