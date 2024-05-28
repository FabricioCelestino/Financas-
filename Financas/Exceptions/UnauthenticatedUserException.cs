namespace Financas.Exceptions
{
    public class UnauthenticatedUserException(string message) : ApplicationException(message)
    {
    }
}
