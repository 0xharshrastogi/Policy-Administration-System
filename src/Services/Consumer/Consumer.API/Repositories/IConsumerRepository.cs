using Consumer.API.Models;

namespace Consumer.API.Repository;
public interface IConsumerRepository
{
    //Customer 
    Customer CreateConsumer(Customer consumer);
    Customer GetConsumerByID(Guid? id);
    IEnumerable<Customer> GetAllConsumers();
    Customer UpdateConsumer(Customer consumer);

    void DeleteConsumer(Guid id);
    //business
    Business GetBusinessByID(Guid? id);
    Business CreateBusiness(Business business);
    IQueryable<Business> GetAllBusiness();
    Business UpdateBusiness(Guid id, Business business);
    void DeleteBusiness(Guid id);
    //property

    Property GetPropertyByID(Guid? id);
    IQueryable<Property> GetAllProperties();
    Property CreateProperty(Property property);
    Property UpdateProperty(Guid id, Property property);
    void DeleteProperty(Guid id);

}