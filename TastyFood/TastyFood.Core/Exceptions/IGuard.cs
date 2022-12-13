namespace TastyFood.Exceptions
{
    public interface IGuard
    {
        void GuardAgainstDeletedEnteties<T>(T value, string? message = null);
    }
}
