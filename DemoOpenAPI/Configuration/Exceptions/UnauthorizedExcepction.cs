namespace DemoOpenAPI.Configuration.Exceptions
{
    public class UnauthorizedExcepction : Exception
    {
        public UnauthorizedExcepction() { }

        public UnauthorizedExcepction(string message) : base(message) { }
    }
}
