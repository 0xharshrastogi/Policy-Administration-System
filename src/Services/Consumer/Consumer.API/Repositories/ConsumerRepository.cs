using Consumer.API.Models;
using Consumer.API.Data;
using Microsoft.EntityFrameworkCore;
using Consumer.API.Repositories;
using Consumer.API.DTO;

namespace Consumer.API.Repository;
public class ConsumerRepository : IConsumerRepository
{
    private readonly ConsumerDbContext _context;

    public ConsumerRepository(ConsumerDbContext context)
    {
        _context = context;
    }

    public Customer CreateConsumer(Customer consumer)
    {
        _context.Customers.Add(consumer);
        _context.SaveChanges();
        return consumer;
    }

    public Customer GetConsumerByID(Guid? id)
    {
        return _context.Customers.Find(id);
    }

    public IEnumerable<Customer> GetAllConsumers()
    {
        return _context.Customers;

    }

    public Customer UpdateConsumer(Customer consumer)
    {
        Customer consumerToBeUpdated = _context.Customers.Find(consumer.CustomerID);
        if (consumerToBeUpdated != null)
        {
            consumerToBeUpdated.CustomerName = consumer.CustomerName;
            consumerToBeUpdated.DateOfBirth = consumer.DateOfBirth;
            consumerToBeUpdated.Email = consumer.Email;
            consumerToBeUpdated.Pan = consumer.Pan;
            consumerToBeUpdated.PhoneNumber = consumer.PhoneNumber;

            _context.SaveChanges();

            return consumerToBeUpdated;
        }
        return null;
    }

    public void DeleteConsumer(Guid consumerId)
    {
        var customer = _context.Customers.Find(consumerId);
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    //Business
    public Business GetBusinessByID(Guid? id)
    {
        return _context.Businesses.Find(id);
    }

    public Business CreateBusiness(Business business)
    {
        _context.Businesses.Add(business);
        _context.SaveChanges();
        return business;
    }

    public IQueryable<Business> GetAllBusiness()
    {
        return _context.Businesses;
    }

    public Business UpdateBusiness(UpdateBusinessDTO business)
    {
        var businessToBeUpdated = _context.Businesses.Find(business.BusinessID);
        if (businessToBeUpdated != null)
        {
            businessToBeUpdated.AnnualTurnover = business.AnnualTurnover;
            businessToBeUpdated.BusinessType = business.BusinessType;
            businessToBeUpdated.BusinessValue = business.BusinessValue;
            businessToBeUpdated.BusinessName = business.BusinessName;

            _context.SaveChanges();
            return businessToBeUpdated;
        }
        return null;
    }

    public void DeleteBusiness(Guid id)
    {
        var business = _context.Businesses.Find(id);
        _context.Businesses.Remove(business);
        _context.SaveChanges();
    }

    public Property GetPropertyByID(Guid propertyId)
    {
        return _context.Properties.Include(p => p.Business)
            .SingleOrDefault(c => c.PropertyID == propertyId);
    }

    public IQueryable<Property> GetAllProperties()
    {
        return _context.Properties;
    }

    public Property CreateProperty(Property property)
    {
        _context.Properties.Add(property);
        _context.SaveChanges();
        return property;
    }

    public Property UpdateProperty(UpdatePropertyDTO property)
    {
        var propertyTobeupdated = _context.Properties.Find(property.PropertyID);

        propertyTobeupdated.Address = property.Address;
        propertyTobeupdated.PropertyType = property.PropertyType;
        propertyTobeupdated.AreaInSqFt = property.AreaInSqFt;
        propertyTobeupdated.BuildingAge = property.BuildingAge;
        propertyTobeupdated.BuildingStorey = property.BuildingStorey;
        property.PropertyValue = property.PropertyValue;
        _context.SaveChanges();
        return propertyTobeupdated;
    }

    public void DeleteProperty(Guid id)
    {
        var propertytobedeleted = _context.Properties.Find(id);
        _context.Properties.Remove(propertytobedeleted);
    }
}
