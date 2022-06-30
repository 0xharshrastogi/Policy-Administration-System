using Policy.Data;
using Policy.Models;

namespace PolicyMicroservice.Repo;

public class PolicyMasterRepo : IPolicyMasterRepo
{
    private readonly PolicyContext _context;

    public PolicyMasterRepo(PolicyContext context)
    {
        _context = context;
    }

    public IQueryable<PolicyMaster> FindByBusinessValue(int businessValue) => _context
        .PolicyMasters
        .Where(p => p.BusinessValue == businessValue);
}