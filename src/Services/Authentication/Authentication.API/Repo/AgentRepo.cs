using Authentication.Context;
using Authentication.Extensions;
using Authentication.Models;

namespace Authentication.Repo;

public class AgentRepo : IAgentRepo
{
    public const string DUPLICATEUSERNAME = "Duplicate";

    private readonly AuthContext _context;

    public AgentRepo(AuthContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Agent agent)
    {
        var result = await _context.Agents.SingleOrDefaultAsync(a => a.UserName == agent.UserName);
        if (result is not null) throw new Exception(DUPLICATEUSERNAME);

        agent.Password = Hash.GeneratePassword(agent.Password, out var salt);
        agent.Salt = salt;
        await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
    }

    public async Task<Agent?> FindByUserNameAsync(string userName) => await _context.Agents.SingleOrDefaultAsync(a => a.UserName == userName);
}