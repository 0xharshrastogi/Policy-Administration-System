#nullable disable

namespace Authentication.Models;

public interface ICredential
{
    string UserName { get; set; }

    string Password { get; set; }
}
