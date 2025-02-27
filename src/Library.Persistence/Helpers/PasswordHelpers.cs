using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Library.Infrastructure.Helpers
{
    internal static class PasswordHelpers
    {

        public static void PasswordHasher(out byte[] salt, ref string password)
        {
            salt = RandomNumberGenerator.GetBytes(128 / 8);
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            //password = "123456";
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            password = hashed;
        }
        public static string PasswordChecker(string saltStr, string password)
        {

            var salt = saltStr.Split(',').Select(r=>byte.Parse(r)).ToArray();
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");
            //password = "123456";
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}