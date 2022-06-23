using Microsoft.AspNetCore.Mvc;
namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{


    [HttpGet(Name = "GetQuotes")]
    public IActionResult Get(int BusinessValue, int PropertyValue, string PropertyType)
    {
        if(BusinessValue<0||PropertyValue<0||BusinessValue>10||PropertyValue>10)
        {
            return BadRequest();
        }
        var QuoteValue = 0;
        if (BusinessValue >= 0 && BusinessValue <= 2 && PropertyValue >= 0 && PropertyValue <= 2 && PropertyType == "Equipment")
            QuoteValue = 80000;
        else if (BusinessValue >= 3 && BusinessValue <= 5 && PropertyValue >= 3 && PropertyValue <= 5 && PropertyType == "Equipment")
            QuoteValue = 50000;
        return Ok(new {QuoteValue});
    }
}