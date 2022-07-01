
using System.ComponentModel.DataAnnotations;

namespace Consumer.API.Models;

public class Property
{
    [Key]
    public Guid PropertyID { get; set; }

    public Guid BusinessID { get; set; }

    public virtual Business Business { get; set; }

    public string PropertyType { get; set; }

    public string Address { get; set; }

    public double AreaInSqFt { get; set; }

    public int BuildingStorey { get; set; }

    public int BuildingAge { get; set; }

    public int PropertyValue { get; set; }
}

// {
//   "customerName": "John Smith",
//   "dateOfBirth": "2022-07-01",
//   "email": "johnsmith@example.com",
//   "phoneNumber": "9012056345",
//   "pan": "FDMA1243AE"
// }

// {
//   "customerID": "4e260a85-4384-40b0-1a89-08da5b08c08c",
//   "businessName": "Smith Industries",
//   "businessType": 1,
//   "totalEmployees": 100,
//   "annualTurnover": 500000,
//   "businessValue": 1
// }