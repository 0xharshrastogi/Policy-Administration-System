using Authentication.DTO;
using Authentication.Models;

using AutoMapper;

namespace Authentication.Profiles;

internal class AgentAuthProfile : Profile
{
    public AgentAuthProfile()
    {
        CreateMap<AgentCreateDTO, Agent>();
    }
}