using PolicyMicroservice.Context;
using PolicyMicroservice.Models;

namespace PolicyMicroservice.Repo;

public class IssuedPolicyRepo : IIssuedPolicyRepo<IssuedPolicy>
{
    private readonly PolicyContext _context;

    public IssuedPolicyRepo(PolicyContext context)
    {
        _context = context;
    }

    public async Task<IssuedPolicy> CreateAsync(IssuedPolicy issuedPolicy)
    {
        await _context.IssuedPolicies.AddAsync(issuedPolicy);
        await _context.SaveChangesAsync();
        return issuedPolicy;
    }
}
