namespace TastyFood.Exceptions
{
    public class Guard : IGuard
    {
        public void GuardAgainstDeletedEntity(bool value, string? errorMessage = null)
        {
            if (value == false)
            {
                var exceotion = errorMessage == null ?
                    new AlreadyDeletedException() :
                    new AlreadyDeletedException(errorMessage);
            }
        }

        public void GuardAgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exceotion = errorMessage == null ?
                    new ArgumentNullException() :
                    new ArgumentNullException(errorMessage);
            }
        }
    }
}
