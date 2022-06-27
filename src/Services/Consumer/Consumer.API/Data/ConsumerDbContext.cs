using Microsoft.EntityFrameworkCore;
using Consumer.API.Models;
namespace Consumer.API.Data;

public class ConsumerDbContext:DbContext
{
    public ConsumerDbContext(DbContextOptions<ConsumerDbContext> options):base(options){}
    public DbSet<Agent> Agents{get;set;}
    public DbSet<AgentCustomerLookup> AgentCustomerlookup{get;set;}
    public DbSet<Business> Businesses {get;set;}
    public DbSet<BusinessMaster> BusinessMasters {get;set;}
    public DbSet<Customer> Customers {get;set;}
    public DbSet<Property> Properties{get;set;}
    public DbSet<PropertyMaster> PropertyMasters{get;set;}
}
