#nullable disable
using Microsoft.EntityFrameworkCore;

using PolicyMicroservice.Models;

namespace PolicyMicroservice.Context;

public class PolicyContext : DbContext
{
    public DbSet<PolicyMaster> PolicyMasters { get; set; }

    public DbSet<CustomerPolicy> CustomerPolicies { get; set; }

    public DbSet<IssuedPolicy> IssuedPolicies { get; set; }

    public PolicyContext(DbContextOptions<PolicyContext> options) : base(options)
    { }
}