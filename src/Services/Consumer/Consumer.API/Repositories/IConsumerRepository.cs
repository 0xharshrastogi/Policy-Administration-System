using Consumer.API.Models;

namespace Consumer.API.Repository;
public interface IConsumerRepository
{
    Customer GetConsumerByID(Guid id);
    
    Customer CreateConsumer(Customer consumer);
    IEnumerable<Customer> GetAllConsumers();
    Customer UpdateConsumer();
    Customer GetConsumerById(Guid id);
    Customer DeleteConsumer();
}