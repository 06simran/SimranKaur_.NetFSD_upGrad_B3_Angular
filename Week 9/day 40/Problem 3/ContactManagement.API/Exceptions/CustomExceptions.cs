namespace ContactManagement.API.Exceptions;

public class ContactNotFoundException : Exception
{
    public ContactNotFoundException(int id)
        : base($"Contact with ID {id} was not found.") { }
}

public class ValidationException : Exception
{
    public ValidationException(string message)
        : base(message) { }
}

public class DatabaseException : Exception
{
    public DatabaseException(string message, Exception inner)
        : base(message, inner) { }
}
