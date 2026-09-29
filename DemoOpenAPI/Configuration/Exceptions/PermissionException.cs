namespace DemoOpenAPI.Configuration.Exceptions
{
    public class PermissionException : Exception
    {
        public PermissionException() { }

        public PermissionException(string message) : base(message) { }
    }
}
