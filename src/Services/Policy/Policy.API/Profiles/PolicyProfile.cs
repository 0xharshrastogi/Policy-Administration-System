using AutoMapper;

using Policy.DTO;
using Policy.Models;

namespace Policy.Profiles;

public class PolicyProfile : Profile
{
    public PolicyProfile()
    {
        CreateMap<CustomerPolicyWriteDTO, CustomerPolicy>();
    }
}
