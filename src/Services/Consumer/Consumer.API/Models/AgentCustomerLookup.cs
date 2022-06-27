using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;
public class AgentCustomerLookup
{
    [Key]
    public Guid AgentLookUpKey{get;set;}
    public Guid AgentID{get;set;}
    public Agent Agent{get;set;}
    public Guid CustomerID{get;set;}
    public Customer Customer{get;set;}
}