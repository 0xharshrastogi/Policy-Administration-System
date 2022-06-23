
using Consumer.API.Models;
using Consumer.API.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Consumer.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ConsumerController : ControllerBase
{
    public IConsumerRepository Repository { get; }
    public ConsumerController(IConsumerRepository repository)
    {
        this.Repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var consumers=Repository.GetAllConsumers();
        return Ok(consumers);
    }
    [HttpPost]
    public IActionResult Create(Customer consumer)
    {
        Repository.CreateConsumer(consumer);
        return Ok("Consumer added");
    }

}