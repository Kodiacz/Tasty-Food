namespace TastyFood.Exceptions
{
    public class AlreadyDeletedException : Exception
    {
        public AlreadyDeletedException() { }

        public AlreadyDeletedException(string message) : base(message) { }
    }
}
