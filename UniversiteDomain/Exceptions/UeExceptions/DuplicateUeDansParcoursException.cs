namespace UniversiteDomain.Exceptions.UeExceptions;

public class DuplicateUeDansParcoursException : Exception
{
    public DuplicateUeDansParcoursException()
    {
    }
    public DuplicateUeDansParcoursException(string message) : base(message)
    {
    }
    public DuplicateUeDansParcoursException(string message, Exception inner) : base(message, inner)
    {
    }
}