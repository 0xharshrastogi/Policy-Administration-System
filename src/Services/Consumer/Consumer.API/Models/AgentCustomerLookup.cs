using System.ComponentModel.DataAnnotations.Schema;

namespace Consumer.API.Models;
public class AgentCustomerLookup
{

    [ForeignKey("AgentID")]
    public Agent Agent_ID{get;set;}
    [ForeignKey("CustomerID")]
    public Customer Customer_ID{get;set;}
}