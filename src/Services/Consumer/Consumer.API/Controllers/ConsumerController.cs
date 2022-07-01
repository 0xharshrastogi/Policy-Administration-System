
using Consumer.API.Models;
using Consumer.API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Consumer.API.Repositories;

namespace Consumer.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class ConsumerController : ControllerBase
{
    private readonly IConsumerRepository _repository;
    private readonly IMapper _mapper;
    public ConsumerController(IConsumerRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    /// Consumer Action methods
    /// </summary>
    /// <param name="customerDTO"></param>
    /// <returns></returns>
    [HttpPost("Customer")]
    public IActionResult Create(CustomerDTO customerDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var cons = _repository.CreateConsumer(_mapper.Map<Customer>(customerDTO));

        return Created(nameof(Create), new
        {
            Customer = cons,
            message = "new consumer created"
        });
    }

    [HttpGet("Customer")]
    public IActionResult Get(Guid? id)
    {
        if (id == null)
        {
            var consumers = _repository.GetAllConsumers();
            return Ok(consumers);
        }
        return Ok(_repository.GetConsumerByID(id));
    }

    [HttpPut("Customer")]
    public IActionResult Update(Customer cons)
    {
        if (!ModelState.IsValid) return BadRequest();

        _repository.UpdateConsumer(cons);

        return Accepted(nameof(Update));
    }

    [HttpDelete("Customer")]
    public IActionResult Delete(Guid id)
    {
        _repository.DeleteConsumer(id);
        return Ok(nameof(Delete) + " invoked and consumer with id " + id + "deleted.");
    }

    [HttpPost("Business")]
    public IActionResult CreateBusiness(BusinessDTO businessDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var business = _repository.CreateBusiness(_mapper.Map<Business>(businessDTO));
        return Created(nameof(CreateBusiness), new
        {
            Business = business,
            message = "new business created for customer " + businessDTO.CustomerID
        });
    }

    [HttpGet("Business")]
    public IActionResult GetBusiness(Guid? id)
    {
        if (id == null)
        {
            var business = _repository.GetAllBusiness();
            return Ok(business);
        }

        var getbusinessbyid = _repository.GetBusinessByID(id);

        return getbusinessbyid == null
            ? NotFound(new { message = "business not found" })
            : Ok(getbusinessbyid);
    }

    [HttpPut("Business")]
    public IActionResult UpdateBusiness(Guid id, BusinessDTO businessDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        _repository.UpdateBusiness(id, _mapper.Map<Business>(businessDTO));

        return Accepted(nameof(UpdateBusiness));
    }

    [HttpDelete("Business")]
    public IActionResult DeleteBusiness(Guid id)
    {
        _repository.DeleteBusiness(id);
        return Ok(nameof(DeleteBusiness) + "  id " + id + "deleted.");
    }

    [HttpGet(nameof(GetBusinessByCustomerID))]
    public IActionResult GetBusinessByCustomerID(Guid customerID)
    {
        var business = _repository.GetAllBusiness()
            .Include(b => b.Customer)
            .SingleOrDefault(b => b.CustomerID == customerID);

        return business is null ? NotFound(new
        {
            message = "no business found"
        }) : Ok(business);
    }

    /// <summary>
    /// Property action methods
    /// </summary>
    /// <param name="propertyDTO"></param>
    /// <returns></returns>
    [HttpPost("Property")]
    public IActionResult CreateProperty(PropertyDTO propertyDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var prop = _repository.CreateProperty(_mapper.Map<Property>(propertyDTO));
        return Created(nameof(CreateProperty), new { Property = prop, message = "new property created under business " + propertyDTO.BusinessID });
    }

    [HttpGet("Property")]
    public IActionResult GetProperty(Guid? propertyId)
    {
        if (propertyId == null)
        {
            var props = _repository.GetAllProperties().Include(p => p.Business);
            return Ok(props);
        }

        var property = _repository.GetPropertyByID((Guid)propertyId);
        return property is null ? NotFound() : Ok(property);
    }

    [HttpPut("Property")]
    public IActionResult UpdateProperty(Guid id, PropertyDTO propertyDTO)
    {
        if (!ModelState.IsValid) return BadRequest();

        _repository.UpdateProperty(id, _mapper.Map<Property>(propertyDTO));

        return Accepted(nameof(UpdateProperty));
    }

    [HttpDelete("Property")]
    public IActionResult DeleteProperty(Guid id)
    {
        _repository.DeleteProperty(id);
        return Ok(nameof(DeleteProperty) + " invoked Property with id " + id + "deleted.");
    }

    [HttpGet(nameof(GetPropertyByCustomerID))]
    public ActionResult GetPropertyByCustomerID(Guid customerID)
    {
        var business = _repository.GetAllBusiness()
           .Include(b => b.Customer)
           .SingleOrDefault(b => b.CustomerID == customerID);
        Property property = new Property();
        if (business != null)
        {
            property = _repository.GetAllProperties().SingleOrDefault(p => p.BusinessID == business.BusinessID);
        }
        return property is null || business is null ? NotFound() : Ok(property);
    }
}