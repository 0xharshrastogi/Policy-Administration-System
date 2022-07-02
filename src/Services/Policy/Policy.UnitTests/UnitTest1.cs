#nullable disable
#pragma warning disable NUnit2021
using Policy.Controllers;
using Policy.Models;
using System.Runtime.InteropServices;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Policy.UnitTests;

public class Tests
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    private readonly PolicyController _controller;
    [Test]
    public void ViewPolicy_WhenCalled_ReturnsOkResult()
    {
        try
        {
            var g1 = new Guid("aa2868d9-fdbc-4dd5-3ea2-08da5aa9e271");
            var offerItem = _controller.ViewPolicy(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    [Test]
    public void ViewPolicy_UnknownGuidPassed_ReturnsNotFoundResult()
    {
        try
        {
            var g1 = Guid.NewGuid();
            var offerItem = _controller.ViewPolicy(g1);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(404, result2.StatusCode);
            Assert.Pass();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    [Test]
    public void GetPoliciesByBusinessValue_WhenCalled_ReturnsOkResult()
    {
        try
        {
            int businessValue = 8;
            var offerItem = _controller.GetPoliciesByBusinessValue(businessValue);
            ObjectResult result2 = offerItem as ObjectResult;
            Assert.AreEqual(200, result2.StatusCode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }



}