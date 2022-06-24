using Authentication.Models;

namespace Authentication.Repo;

public interface IAgentRepo
{
    Task CreateAsync(Agent agent);
}