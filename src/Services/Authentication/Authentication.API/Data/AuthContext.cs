#nullable disable
using Authentication.Models;

namespace Authentication.Context;

public class AuthContext : DbContext
{
    public DbSet<Agent> Agents { get; set; }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    { }
}