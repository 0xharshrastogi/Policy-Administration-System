using Authentication.Context;
using Authentication.Extensions;
using Authentication.Models;

namespace Authentication.Repo;

public class AgentRepo : IAgentRepo
{
    private readonly AuthContext _context;

    public AgentRepo(AuthContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Agent agent)
    {
        agent.Password = Hash.GeneratePassword(agent.Password, out var salt);
        agent.Salt = salt;

        await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
    }

    public async Task<Agent?> FindByUserNameAsync(string userName)
    {
        return await _context.Agents.SingleOrDefaultAsync(a => a.UserName == userName);
    }
}