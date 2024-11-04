namespace UniversiteDomain.Exceptions.ParcoursExceptions;

public class ParcoursNotFoundException : Exception
{   
    public ParcoursNotFoundException()
    {
    }
    public ParcoursNotFoundException(string message) : base(message)
    {
    }
    public ParcoursNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}