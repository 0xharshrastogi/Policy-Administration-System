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
    }

    public Customer GetConsumerByID(Guid? id)
    {
        Customer customer = context.Customers.Find(id);
        return customer;
    }

    public IEnumerable<Customer> GetAllConsumers()
    {
        return context.Customers;
    }

    public Customer UpdateConsumer(Customer consumer)
    {
        Customer consumerToBeUpdated = context.Customers.Find(consumer.CustomerID);
        consumerToBeUpdated.CustomerName = consumer.CustomerName;
        consumerToBeUpdated.DateOfBirth = consumer.DateOfBirth;
        consumerToBeUpdated.Email = consumer.Email;
        consumerToBeUpdated.Pan = consumer.Pan;
        context.SaveChanges();
        return consumerToBeUpdated;
    }
    public void DeleteConsumer(Guid id)
    {
        var customer = context.Customers.Find(id);
        context.Customers.Remove(customer);
        context.SaveChanges();
    }
    //Business
    public Business GetBusinessByID(Guid? id)
    {
        Business business=context.Businesses.Find(id);
        return business;
    }

    public Business CreateBusiness(Business business)
    {
        context.Businesses.Add(business);
        context.SaveChanges();
        return business;
    }

    public IQueryable<Business> GetAllBusiness()
    {
        return context.Businesses;
    }

    public Business UpdateBusiness(Guid id ,Business business)
    {
        var businessToBeUpdated = context.Businesses.Find(id);
        businessToBeUpdated.AnnualTurnover = business.AnnualTurnover;
        businessToBeUpdated.BusinessTypeID = business.BusinessTypeID;
        businessToBeUpdated.BusinessValue = business.BusinessValue;
        context.SaveChanges();
        return businessToBeUpdated;
    }

    public void DeleteBusiness(Guid id)
    {
        var business = context.Businesses.Find(id);
        context.Businesses.Remove(business);
        context.SaveChanges();
    }
    //property
    public Property GetPropertyByID(Guid? id)
    {
        return context.Properties.Find(id);
    }

    public IEnumerable<Property> GetAllProperties()
    {
        return context.Properties;
    }

    public Property CreateProperty(Property property)
    {
        context.Properties.Add(property);
        context.SaveChanges();
        return property;
    }

    public Property UpdateProperty(Guid id ,Property property)
    {
        var propertyTobeupdated = context.Properties.Find(id);
        
        property.PropertyTypeID = property.PropertyTypeID;
        propertyTobeupdated.Area = property.Area;
        propertyTobeupdated.BuildingAge = property.BuildingAge;
        propertyTobeupdated.BuildingStorey = property.BuildingStorey;
        property.PropertyValue = property.PropertyValue;
        context.SaveChanges();
        return propertyTobeupdated;
        }
   

    public void  DeleteProperty(Guid id)
    {
        var propertytobedeleted=context.Properties.Find(id);
        context.Properties.Remove(propertytobedeleted);
    }
}
