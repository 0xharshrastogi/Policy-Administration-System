using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;
public class AgentCustomerLookup
{
    [Key]
    public Guid AgentLookUpKey { get; set; }
    public Guid AgentID { get; set; }
    public ConsumersAgent Agent { get; set; }
    public Guid CustomerID { get; set; }
    public Customer Customer { get; set; }
}