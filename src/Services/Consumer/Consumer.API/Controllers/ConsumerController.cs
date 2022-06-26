
using Consumer.API.Models;
using Consumer.API.Repository;
using Consumer.API.DTO;
using Consumer.API.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ConsumerController : ControllerBase
{
    private readonly IConsumerRepository Repository;
    private readonly IMapper Mapper;
    public ConsumerController(IConsumerRepository repository, IMapper mapper)
    {
        this.Mapper = mapper;
        this.Repository = repository;
    }

    // Consumer Action methods
    [HttpPost]
    public IActionResult Create(CustomerDTO customerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var cons = Repository.CreateConsumer(Mapper.Map<Customer>(customerDTO));
        return Created(nameof(Create), new { Customer = cons, message = "new consumer created" });
    }
    [HttpGet]
    public IActionResult Get(Guid? id)
    {
        if (id == null)
        {
            var consumers = Repository.GetAllConsumers();
            return Ok(consumers);
        }
        return Ok(Repository.GetConsumerByID(id));
    }
    [HttpPut]
    public IActionResult Update(Customer cons)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        Repository.UpdateConsumer(cons);
        return Accepted(nameof(Update));
    }
    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        Repository.DeleteConsumer(id);
        return Ok(nameof(Delete) + " invoked and consumer with id " + id + "deleted.");
    }
    // business Action methods
    [HttpPost("Business")]
    public IActionResult CreateBusiness(BusinessDTO businessDTO)
    {
       if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var business = Repository.CreateBusiness(Mapper.Map<Business>(businessDTO));
        return Created(nameof(CreateBusiness), new { Business = business, message = "new business created for customer "+businessDTO.CustomerID });
    }
    
    [HttpGet("Business")]
    public IActionResult GetBusiness(Guid? id)
    {
        if (id == null)
        {
            var business= Repository.GetAllBusiness();
            return Ok(business);
        }
        return Ok(Repository.GetBusinessByID(id));
    }
    [HttpPut("Business")]
    public IActionResult UpdateBusiness(Guid id,BusinessDTO businessDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        Repository.UpdateBusiness(id,Mapper.Map<Business>(businessDTO));
        return Accepted(nameof(UpdateBusiness));
    }
    [HttpDelete("Business")]
    public IActionResult DeleteBusiness(Guid id)
    {
        Repository.DeleteBusiness(id);
        return Ok(nameof(DeleteBusiness) + "  id " + id + "deleted.");
    }

    //Property action methods
   [HttpPost("Property")]
    public IActionResult CreateProperty(PropertyDTO propertyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var prop = Repository.CreateProperty(Mapper.Map<Property>(propertyDTO));
        return Created(nameof(CreateProperty), new { Property=prop, message = "new property created under business "+propertyDTO.BusinessID});
    }
    [HttpGet("Property")]
    public IActionResult GetProperty(Guid? id)
    {
        if (id == null)
        {
            var props = Repository.GetAllProperties();
            return Ok(props);
        }
        return Ok(Repository.GetPropertyByID(id));
    }
    [HttpPut("Property")]
    public IActionResult UpdateProperty(Guid id, PropertyDTO propertyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        Repository.UpdateProperty(id,Mapper.Map<Property>(propertyDTO));
        return Accepted(nameof(UpdateProperty));
    }
    [HttpDelete("Property")]
    public IActionResult DeleteProperty(Guid id)
    {
        Repository.DeleteProperty(id);
        return Ok(nameof(DeleteProperty) + " invoked Property with id " + id + "deleted.");
    }

}