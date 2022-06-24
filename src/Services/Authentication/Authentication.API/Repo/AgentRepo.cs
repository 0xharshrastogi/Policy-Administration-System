using System.Text;
using System.Security.Cryptography;

using Authentication.Context;
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
        using var hmac = new HMACSHA512();
        agent.Salt = Convert.ToBase64String(hmac.Key);
        agent.Password = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(agent.Password)));
        await _context.Agents.AddAsync(agent);
        Console.WriteLine(agent.Password);
        Console.WriteLine("\n\n");
        Console.WriteLine(agent.Salt);
        await _context.SaveChangesAsync();
    }

    public bool IsValid(AuthModel credential)
    {

    }
}