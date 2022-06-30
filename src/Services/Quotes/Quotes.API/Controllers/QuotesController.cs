using Microsoft.AspNetCore.Mvc;

using Quotes.API.Data;

namespace Quotes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QuotesController : ControllerBase
{
    private readonly QuotesContext _context;

    public QuotesController(QuotesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuotesAsync(int businessValue, int propertyValue, string propertyType)
    {
        var quotes = _context
            .QuotesMaster
            .Where(q => businessValue >= q.MinBusinessValue
                && businessValue <= q.MaxBusinessValue
                && propertyValue >= q.MinPropertyValue
                && propertyValue <= q.MaxPropertyValue
                && q.PropertyType == propertyType);

        return await quotes.AnyAsync() ? Ok(quotes) : NotFound(new
        {
            name = "No Matched Found",
            message = "No Quotes, Contact Insurance Provider"
        });
    }
}