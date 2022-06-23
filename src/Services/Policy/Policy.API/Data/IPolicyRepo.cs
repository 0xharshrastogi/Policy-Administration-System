using PolicyMicroservice.Models;

namespace PolicyMicroservice.Repo;

public interface IPolicyRepo<TPolicy>
{
    IQueryable<TPolicy> FindAll();

    Task<TPolicy> CreateAsync(TPolicy policy);

    Task<TPolicy> UpdateStatusAsync(Guid id, PolicyStatus status);
}