using System.Security.Cryptography;
using System.Text;

namespace Schedule.Utils
{
    public static class Credentials
    {
        public static string EncodePassword(string password) =>
            Convert.ToHexString(
                SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(password))
                );
    }
}
