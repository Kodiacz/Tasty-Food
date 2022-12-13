namespace TastyFood.Exceptions
{
    public class Guard : IGuard
    {
        public void GuardAgainstDeletedEntities<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exceotion = errorMessage == null ?
                    new AlreadyDeletedException() :
                    new AlreadyDeletedException(errorMessage);
            }
        }
    }
}
