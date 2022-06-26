#nullable disable
using System.Text;
using System.Security.Cryptography;
namespace Authentication.Repo;

public abstract class AuthModel
{
    public string UserName { get; set; }

    public byte[] Password { get; }

    public byte[] Salt { get; set; }

    protected AuthModel(string userName, string rawPassword)
    {
        UserName = userName;
        using var hmac = new HMACSHA256();
        Salt = hmac.Key;
        Password = hmac.ComputeHash(Encoding.ASCII.GetBytes(rawPassword));
    }

    public bool IsValid(AuthModel credential)
    {
        return credential.UserName == UserName;
    }
}
