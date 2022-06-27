using System.Security.Cryptography;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Authentication.Extensions;

public static class Hash
{
    private static byte[] GenerateSalt() => RandomNumberGenerator.GetBytes(10);

    public static byte[] HashPassword(byte[] salt, string password) => KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10 ^ 6,
            numBytesRequested: 256 / 8
        );

    public static string GeneratePassword(string rawPassword, out string salt)
    {
        var saltBlob = GenerateSalt();
        var password = HashPassword(saltBlob, rawPassword);

        salt = Convert.ToBase64String(saltBlob);
        return Convert.ToBase64String(password);
    }
}