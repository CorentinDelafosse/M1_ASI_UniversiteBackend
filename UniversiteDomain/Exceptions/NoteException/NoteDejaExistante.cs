namespace UniversiteDomain.Exceptions.NoteException;

public class NoteDejaExistante : Exception
{
    public NoteDejaExistante()
    {
    }
    public NoteDejaExistante(string message) : base(message)
    {
    }
    public NoteDejaExistante(string message, Exception innerException) : base(message, innerException)
    {
    }
}