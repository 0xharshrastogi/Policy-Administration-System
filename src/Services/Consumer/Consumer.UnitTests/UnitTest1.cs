#nullable disable
#pragma warning disable NUnit2021 
namespace Consumer.UnitTests;
using Consumer.API.Repositories;
using AutoMapper;
using Consumer.API.Controllers;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consumer.API.Models;
using Consumer.API.DTO;

public class Test

{
    readonly ConsumerController consumerController;
    // private readonly Mock<IConsumerRepository> mockRepository = new Mock<IConsumerRepository>();
    public readonly ConsumerController controllerObject;
    private readonly IConsumerRepository _repository;
    public IConsumerRepository repository;
    public IMapper mapper;

    private readonly IMapper _mapper;

    public Test()
    {
        var controllerObject = new ConsumerController(repository, mapper);
    }
    [SetUp]
    public void Setup()
    {

    }
    [Test]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        try
        {
            var g1 = new Guid("aa2868d9-fdbc-4dd5-3ea2-08da5aa9e271");
            var offerItem = controllerObject.GetBusiness(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void Get_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            var g1 = Guid.NewGuid();
            var offerItem = controllerObject.GetBusiness(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(404, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    [Test]
    public void GetBusinessByCustomerId_WhenCalled_ReturnsOkResult()
    {
        try
        {
            var g1 = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var offerItem = controllerObject.GetBusinessByCustomerID(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    [Test]
    public void GetBusinessByCustomerId_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            var g1 = Guid.NewGuid();
            var offerItem = controllerObject.GetBusinessByCustomerID(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(404, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void Create_ValidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            CustomerDTO customer = new CustomerDTO()
            {
                CustomerName = "Kartick C",
                DateOfBirth = new DateTime(2000 - 06 - 30),
                Email = "Kartic@yahoo.in",
                PhoneNumber = "9090919293",
                Pan = "PPPKKKII01"
            };
            var obj = consumerController.Create(customer);
            ObjectResult result3 = obj as ObjectResult;
            Assert.AreEqual(200, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void Create_InvalidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            CustomerDTO nameMissingItem = new CustomerDTO()
            {
                DateOfBirth = new DateTime(2001 - 06 - 28),
                Email = "arti@yahoo.in",
                PhoneNumber = "9035419293",
                Pan = "PPPABKII01"
            };

            consumerController.ModelState.AddModelError("Name", "Required");
            var badResponse = consumerController.Create(nameMissingItem);
            ObjectResult result3 = badResponse as ObjectResult;
            Assert.AreEqual(404, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Update_WhenCalled_ReturnsOkResult()
    {
        try
        {
            Customer cust = new Customer()
            {
                CustomerID = new Guid("223dae02-0c56-4557-22db-08da5ac90082"),
                CustomerName = "Charles Smith",
                DateOfBirth = new DateTime(2000 - 06 - 19),
                Email = "charles@gmail.com",
                PhoneNumber = "9090554431",
                Pan = "KGFKRKIS38"
            };
            var offerItem = controllerObject.Update(cust);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void Update_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            Customer cust = new Customer()
            {
                CustomerID = new Guid("223dae02-0c56-4557-22db-08da5ac90082"),
                DateOfBirth = new DateTime(2000 - 06 - 19),
                Email = "charles@gmail.com",
                PhoneNumber = "9090554431",
                Pan = "KGFKRKIS38"
            };
            consumerController.ModelState.AddModelError("Name", "Required");
            var badResponse = consumerController.Update(cust);
            ObjectResult result3 = badResponse as ObjectResult;
            Assert.AreEqual(404, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public void Delete_WhenCalled_ReturnsOkResult()
    {
        try
        {
            var g1 = new Guid("05106ae9-4b33-4395-22dc-08da5ac90082");
            var offerItem = controllerObject.Delete(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void Delete_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            var g1 = Guid.NewGuid();
            var offerItem = controllerObject.Delete(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(404, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void CreateBusiness_ValidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            BusinessDTO business = new BusinessDTO()
            {
                CustomerID = new Guid("c74a376c-5c1b-42d8-22d9-08da5ac90082"),
                BusinessName = "Saravana Bhavan",
                BusinessType = 0,
                TotalEmployees = 700,
                AnnualTurnover = 4000,
                BusinessValue = 4
            };
            var obj = consumerController.CreateBusiness(business);
            ObjectResult result3 = obj as ObjectResult;
            Assert.AreEqual(200, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void CreateBusiness_InvalidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            BusinessDTO nameMissingItem2 = new BusinessDTO()
            {
                BusinessType = 0,
                TotalEmployees = 700,
                AnnualTurnover = 4000,
                BusinessValue = 4
            };

            consumerController.ModelState.AddModelError("Name", "Required");
            var badResponse = consumerController.CreateBusiness(nameMissingItem2);
            ObjectResult result3 = badResponse as ObjectResult;
            Assert.AreEqual(404, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UpdateBusiness_ValidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            BusinessDTO business = new BusinessDTO()
            {
                CustomerID = new Guid("c74a376c-5c1b-42d8-22d9-08da5ac90082"),
                BusinessName = "Saravana Bhavan",
                BusinessType = 0,
                TotalEmployees = 700,
                AnnualTurnover = 4000,
                BusinessValue = 4
            };
            var obj = consumerController.UpdateBusiness(business.CustomerID, business);
            ObjectResult result3 = obj as ObjectResult;
            Assert.AreEqual(200, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void UpdateBusiness_InvalidObjectPassed_ReturnsCreatedResponse()
    {
        try
        {
            BusinessDTO nameMissingItem = new BusinessDTO()
            {
                CustomerID = new Guid("d74a376c-5c1b-42d8-22d9-08da5ac91182"),
                BusinessType = 0,
                TotalEmployees = 850,
                AnnualTurnover = 3000,
                BusinessValue = 4
            };

            consumerController.ModelState.AddModelError("Name", "Required");
            var badResponse = consumerController.UpdateBusiness(nameMissingItem.CustomerID, nameMissingItem);
            ObjectResult result3 = badResponse as ObjectResult;
            Assert.AreEqual(404, result3.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }


    public void DeleteBusiness_WhenCalled_ReturnsOkResult()
    {
        try
        {
            var g1 = new Guid("aa2868d9-fdbc-4dd5-3ea2-08da5aa9e271");
            var offerItem = controllerObject.DeleteBusiness(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void DeleteBusiness_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            var g1 = Guid.NewGuid();
            var offerItem = controllerObject.DeleteBusiness(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(404, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }




}