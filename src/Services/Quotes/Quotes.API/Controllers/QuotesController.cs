using Microsoft.AspNetCore.Mvc;
namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    [HttpGet(Name = "GetQuotes")]
    public IActionResult Get(int businessValue, int propertyValue, int propertyType)
    {
        if (businessValue < 0 || propertyValue < 0 || businessValue > 10)
        {
            return BadRequest();
        }

        double quoteValue = propertyValue - ((10 - businessValue) * propertyValue / 10);
        if (propertyType.Equals("Equipment"))
            quoteValue += propertyValue * 2 / 100;
        else if (propertyType.Equals("Machinery"))
            quoteValue += propertyValue * 5 / 100;
        else if (propertyType.Equals("Building"))
            quoteValue += propertyValue / 10;
        //PropertyValue is cost of Property
        //On the scale of 10 we deduct the part of ProprertyValue according to worth of BusinessValue

        return Ok(quoteValue);
    }
}