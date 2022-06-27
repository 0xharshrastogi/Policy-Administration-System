using Authentication.Models;

namespace Authentication.Extensions;

public static class AgentExtensions
{
    public static bool Compare(this Agent agentCredential, ICredential credential)
    {
        var salt = Convert.FromBase64String(agentCredential.Salt);
        var password = Convert.ToBase64String(Hash.HashPassword(salt, credential.Password));

        return agentCredential.Password == password;
    }
}