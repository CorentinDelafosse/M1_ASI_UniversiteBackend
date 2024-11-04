namespace UniversiteDomain.Exceptions.NoteException;

public class NoteHorsBornes : Exception
{
    public NoteHorsBornes()
    {
    }
    public NoteHorsBornes(string message) : base(message)
    {
    }
    public NoteHorsBornes(string message, Exception inner) : base(message, inner)
    {
    }
}