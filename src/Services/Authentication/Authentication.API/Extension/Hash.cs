using System.Security.Cryptography;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Authentication.Extensions;

public static class Hash
{
    private static byte[] GenerateSalt()
    {
        var salt = new byte[128 / 8];
        using var rngCsp = new RNGCryptoServiceProvider();
        rngCsp.GetBytes(salt);
        return salt;
    }

    public static byte[] HashPassword(byte[] salt, string password)
    {
        return KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10 ^ 6,
            numBytesRequested: 256 / 8
        );
    }

    public static string GeneratePassword(string rawPassword, out string salt)
    {
        var saltBlob = GenerateSalt();
        var password = HashPassword(saltBlob, rawPassword);

        salt = Convert.ToBase64String(saltBlob);
        return Convert.ToBase64String(password);
    }
}