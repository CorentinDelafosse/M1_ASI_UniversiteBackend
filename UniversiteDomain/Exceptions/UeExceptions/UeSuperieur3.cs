namespace UniversiteDomain.Exceptions.UeExceptions;

public class UeSuperieur3: Exception
{
    public UeSuperieur3()
    {
    }
    public UeSuperieur3(string message) : base(message)
    {
    }
    public UeSuperieur3(string message, Exception inner) : base(message, inner)
    {
    }
}