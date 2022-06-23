using PolicyMicroservice.Context;
using PolicyMicroservice.Helper;
using PolicyMicroservice.Models;

namespace PolicyMicroservice.Repo;

public class PolicyRepo : IPolicyRepo<CustomerPolicy>
{
    private readonly PolicyContext _context;

    public PolicyRepo(PolicyContext context)
    {
        _context = context;
    }

    public async Task<CustomerPolicy> CreateAsync(CustomerPolicy policy)
    {
        _context.CustomerPolicies.Add(policy);
        await _context.SaveChangesAsync();
        return policy;
    }

    public IQueryable<CustomerPolicy> FindAll()
    {
        return _context.CustomerPolicies;
    }

    /// <summary>
    /// Asyncronously update the status of policy with passed policy id with new status
    /// </summary>
    /// <param name="id"></param>
    /// <param name="status"></param>
    /// <exception cref="PolicyNotFoundExpection"></exception>
    public async Task<CustomerPolicy> UpdateStatusAsync(Guid id, PolicyStatus status)
    {
        var policy = await _context.CustomerPolicies.FindAsync(id);
        if (policy is null) throw new PolicyNotFoundExpection(id);

        policy.Status = status;
        await _context.SaveChangesAsync();

        return policy;
    }
}