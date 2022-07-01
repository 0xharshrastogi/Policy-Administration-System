#nullable disable
namespace Consumer.UnitTests;

using Consumer.API.Controllers;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ConsumerTest

{
    public readonly ConsumerController controllerObject;
    public ConsumerTest()
    {
        var controllerObject = new ConsumerController();
    }
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void GetBusinessById()
    {
        var g1 = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
        var offerItem = controllerObject.GetBusiness(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(200, result2.StatusCode);
    }
    [Test]
    public void GetBusinessByIdFailedTestCase()
    {
        var g1 = Guid.Empty;
        var offerItem = controllerObject.DeleteBusiness(g1);
        ObjectResult result2 = offerItem as ObjectResult;
        Assert.AreEqual(404, result2.StatusCode);
    }
}