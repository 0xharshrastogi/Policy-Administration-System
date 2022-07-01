using Moq;
using Xunit;
using Consumer.API.Controllers;
using Consumer.API.DTO;
using Consumer.API.Migrations;
using Consumer.API.Repositories;
using Consumer.UnitTests.Mock;
using AutoMapper;
using Consumer.API.Models;

namespace Consumer.UnitTests;

public class UnitTests
{
    [Fact]
    public void getCustomerShouldReturn200StatusCode()
    {
        // Given
        var _service = new Mock<IConsumerRepository>();
        _service.Setup(s => s.GetAllConsumers()).Returns(ConsumerMockData.GetCustomers());
        var _consumerController = new ConsumerController(_service.Object, IMapper mapper);
        // When

        // Then
    }
}