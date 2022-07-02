using Consumer.API.Models;

using System;

namespace Consumer.UnitTests.Mock;

public class ConsumerMockData
{
    public static List<Customer> GetCustomers()
    {
        return new List<Customer>
        {
            new Customer{
                CustomerID=new Guid("d68b2040-2550-48d6-22d7-08da5ac90082"),
                CustomerName="Harsh Rastogi",
                DateOfBirth=new DateTime(2000-05-16),
                Email="harsh@yahoo.in",
                PhoneNumber="9273828389",
                Pan="KDSKNFKDJE"},
                new Customer{
                CustomerID=new Guid("d68b2040-2550-48d6-22d7-08da5ac90089"),
                CustomerName="INDU",
                DateOfBirth=new DateTime(2000-05-16),
                Email="harsh@yahoo.in",
                PhoneNumber="9273828389",
                Pan="KDSKNFKDJE"}
        };
    }
}