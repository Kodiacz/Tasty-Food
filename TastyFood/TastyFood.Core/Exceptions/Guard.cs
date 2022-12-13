namespace TastyFood.Exceptions
{
    public class Guard : IGuard
    {
        public void GuardAgainstDeletedEntity(bool value, string? errorMessage = null)
        {
            if (value == false)
            {
                var exception = errorMessage == null ?
                    new AlreadyDeletedException() :
                    new AlreadyDeletedException(errorMessage);

                throw exception;
            }
        }

        public void GuardAgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new ArgumentNullException() :
                    new ArgumentNullException(errorMessage);

                throw exception;
            }
        }
    }
}
