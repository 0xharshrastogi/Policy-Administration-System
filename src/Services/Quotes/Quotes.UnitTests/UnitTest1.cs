#nullable disable
using Quotes.API.Controllers;
using Quotes.API.Models;

namespace Quotes.UnitTests;

public class Tests
{
    //private QuotesController _quotesController;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    /*[Test]
    public void Get_WhenCalled_ReturnsOkResult()
    {
        try
        {
                int businessValue=5;
                string PropertyType="Equipment";
                int PropertyValue=3;
            var offerItem = -_quotesController.GetQuotesAsync(businessValue,propertyValue,propertyType);
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
            
            Assert.AreEqual(404, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }*/


}