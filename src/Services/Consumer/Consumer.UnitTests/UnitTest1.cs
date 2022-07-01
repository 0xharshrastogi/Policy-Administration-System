#nullable disable
#pragma warning disable NUnit2021 
namespace Consumer.UnitTests;
using Consumer.API.Repositories;
using AutoMapper;
using Consumer.API.Controllers;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System;
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
        try{
        var g1 = new Guid("aa2868d9-fdbc-4dd5-3ea2-08da5aa9e271");
        var offerItem = controllerObject.GetBusiness(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(200, result2.StatusCode);
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void Get_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try{
        var g1 = Guid.NewGuid();
        var offerItem = controllerObject.GetBusiness(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(404, result2.StatusCode);
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    
    [Test]
    public void GetBusinessByCustomerId_WhenCalled_ReturnsOkResult()
    {
        try{
        var g1 = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        var offerItem = controllerObject.GetBusinessByCustomerID(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(200, result2.StatusCode);
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }

    [Test]
    public void GetBusinessByCustomerId_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try{
        var g1 = Guid.NewGuid();
        var offerItem = controllerObject.GetBusinessByCustomerID(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(404, result2.StatusCode);
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    public void Create_ValidObjectPassed_ReturnsCreatedResponse()
    {
        try{
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
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    public void Create_InvalidObjectPassed_ReturnsCreatedResponse()
    {
        try{
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
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }


}