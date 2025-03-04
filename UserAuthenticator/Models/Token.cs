namespace UserAuthenticator.Models
{
    public class Token(string value)
    {
        public string Value { get; } = value;
    }
}
