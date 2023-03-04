namespace Schedule.Services
{
    public class RandomStringGenerator : IRandomStringGenerator
    {
        public string GetRandomString(int length, string alphabet)
        {
            Random random = new Random();
            string randomString = string.Empty;

            while (randomString.Length < length)
            {
                randomString += alphabet[random.Next(alphabet.Length)];
            }

            return randomString;
        }

        public string GetRandomString(int length)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
            return GetRandomString(length, alphabet);
        }
    }
}
