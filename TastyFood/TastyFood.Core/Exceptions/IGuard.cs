namespace TastyFood.Exceptions
{
    public interface IGuard
    {
        void GuardAgainstDeletedEntity(bool value, string? errorMessage = null);

        void GuardAgainstNull<T>(T value, string? errorMessage = null);
    }
}
