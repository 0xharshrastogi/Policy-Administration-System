#nullable disable
using Quotes.API.Models;

namespace Quotes.API.Data;

public class QuotesContext : DbContext
{
    public DbSet<QuotesMaster> QuotesMaster { get; set; }

    public QuotesContext(DbContextOptions<QuotesContext> options) : base(options)
    { }
}