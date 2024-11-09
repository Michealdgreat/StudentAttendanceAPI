using System.Security.Cryptography;
using System.Text;

namespace Common.Application.SecurityUtil
{/// <summary>
/// Password encoding and verification
/// </summary>
    public class Sha256Hasher
    {/// <summary>
     /// Generate hash-value of user's raw password.
     /// </summary>
     /// <param name="inputValue">User password</param>
     /// <returns></returns>
        public static string Hash(string inputValue)
        {
            using var sha256 = SHA256.Create();
            var originalBytes = Encoding.Default.GetBytes(inputValue);
            var encodedBytes = sha256.ComputeHash(originalBytes);
            return Convert.ToBase64String(encodedBytes);
        }

        /// <summary>
        /// During login, This method compares the Hash-value of the user's claim password with the hashValue(provided during signUp) in the database.
        /// </summary>
        /// <param name="hashText">Database Hash</param>
        /// <param name="rawText">Hash-Value of pass provided by the user</param>
        /// <returns></returns>
        public static bool IsCompare(string hashText, string rawText)
        {
            var hash = Hash(rawText);
            return hashText == hash;
        }
    }
}