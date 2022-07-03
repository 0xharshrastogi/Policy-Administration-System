using Consumer.API.Models;
using Consumer.API.DTO;
namespace Consumer.API.Repositories;
public interface IConsumerRepository
{
    /// <summary>
    /// Customer
    /// </summary>
    /// <param name="consumer"></param>
    Customer CreateConsumer(Customer consumer);

    Customer GetConsumerByID(Guid? id);

    IEnumerable<Customer> GetAllConsumers();

    Customer UpdateConsumer(Customer consumer);

    void DeleteConsumer(Guid id);

    Business GetBusinessByID(Guid? id);

    Business CreateBusiness(Business business);

    IQueryable<Business> GetAllBusiness();

    Business UpdateBusiness(UpdateBusinessDTO business);

    void DeleteBusiness(Guid id);

    Property GetPropertyByID(Guid id);

    IQueryable<Property> GetAllProperties();

    Property CreateProperty(Property property);

    Property UpdateProperty(UpdatePropertyDTO updatepropertydto);

    void DeleteProperty(Guid id);
}