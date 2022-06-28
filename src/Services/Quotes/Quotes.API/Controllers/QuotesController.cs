using Microsoft.AspNetCore.Mvc;
namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{


    [HttpGet(Name = "GetQuotes")]
    public IActionResult Get(int BusinessValue, int PropertyValue, int PropertyType)
    {
        if (BusinessValue < 0 || PropertyValue < 0 || BusinessValue > 10 )
        {
            return BadRequest();
        }
        double QuoteValue = 0;

        QuoteValue = PropertyValue-(10-BusinessValue)*(PropertyValue)/10 ;
        //PropertyValue is cost of Property
        //On the scale of 10 we deduct the part of ProprertyValue according to worth of BusinessValue

        return Ok( QuoteValue );
    }
}