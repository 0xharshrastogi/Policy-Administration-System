using Consumer.API.Models;
using Consumer.API.Data;

namespace Consumer.API.Repository;
public class ConsumerRepository : IConsumerRepository
{
    public ConsumerDbContext context { get; }
    public ConsumerRepository(ConsumerDbContext _context)
    {
        this.context = _context;
    }
     public Customer CreateConsumer(Customer consumer)
    {
        this.context.Customers.Add(consumer);
        this.context.SaveChanges();
        return consumer;
       // throw new NotImplementedException();
    }

    public Customer GetConsumerByID(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Customer> GetAllConsumers()
    {
       return context.Customers;
    }

    public Customer UpdateConsumer()
    {
        throw new NotImplementedException();
    }

    public Customer GetConsumerById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Customer DeleteConsumer()
    {
        throw new NotImplementedException();
    }

   
}