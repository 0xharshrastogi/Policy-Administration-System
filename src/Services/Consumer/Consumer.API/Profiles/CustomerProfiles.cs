using AutoMapper;
using Consumer.API.DTO;
using Consumer.API.Models;
namespace Consumer.API.Profiles;

public class CustomerProfiles:Profile
{
    public CustomerProfiles()
    {
        CreateMap<CustomerDTO,Customer>();
    }
}
