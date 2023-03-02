namespace Schedule.Services
{
    public interface IRandomStringGenerator
    {
        public string GetRandomString(int length, string alphabet);
        public string GetRandomString(int length);
    }
}
