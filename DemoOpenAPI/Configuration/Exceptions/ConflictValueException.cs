namespace DemoOpenAPI.Configuration.Exceptions
{
    public class ConflictValueException : Exception
    {
        public ConflictValueException() { }

        public ConflictValueException(string message) : base(message) { }
    }
}
