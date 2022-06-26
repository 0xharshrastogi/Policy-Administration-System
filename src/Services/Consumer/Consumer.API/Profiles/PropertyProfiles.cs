using AutoMapper;
using Consumer.API.DTO;
using Consumer.API.Models;
namespace Consumer.API.Profiles;

public class PropertyProfiles:Profile
{
    public PropertyProfiles()
    {
        CreateMap<PropertyDTO,Property>();
    }
}