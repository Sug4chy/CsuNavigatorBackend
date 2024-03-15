using System.Security.Cryptography;
using System.Text;
using CsuNavigatorBackend.ApplicationServices.Services;

namespace CsuNavigatorBackend.Services.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int KeySize = 64;
    private const int Iterations = 350000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;
    
    public string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(KeySize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            Iterations,
            HashAlgorithm,
            KeySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        byte[] hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, Iterations, HashAlgorithm, KeySize);
        return CryptographicOperations.FixedTimeEquals(
            hashToCompare, Convert.FromHexString(hash));
    }
}