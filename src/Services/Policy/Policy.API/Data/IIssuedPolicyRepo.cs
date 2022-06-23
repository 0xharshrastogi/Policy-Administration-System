namespace PolicyMicroservice.Repo;

public interface IIssuedPolicyRepo<TIsuedPolicy>
{
    Task<TIsuedPolicy> CreateAsync(TIsuedPolicy issuedPolicy);
}
