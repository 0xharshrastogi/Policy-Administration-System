using Policy.Models;

namespace PolicyMicroservice.Repo;

public interface IPolicyMasterRepo
{
    IQueryable<PolicyMaster> FindByBusinessValue(int businessValue);
}
