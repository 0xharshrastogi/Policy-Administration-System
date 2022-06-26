using AutoMapper;
using Consumer.API.DTO;
using Consumer.API.Models;
namespace Consumer.API.Profiles;

public class BusinessProfiles:Profile
{
    public BusinessProfiles()
    {
        CreateMap<BusinessDTO,Business>();
    }
}