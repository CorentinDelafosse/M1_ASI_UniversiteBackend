namespace UniversiteDomain.Exceptions.ParcoursExceptions;

public class DuplicateInscriptionException : Exception
{  
    public DuplicateInscriptionException()
    {
    }
    public DuplicateInscriptionException(string message) : base(message)
    {
    }
    public DuplicateInscriptionException(string message, Exception inner) : base(message, inner)
    {
    }
}