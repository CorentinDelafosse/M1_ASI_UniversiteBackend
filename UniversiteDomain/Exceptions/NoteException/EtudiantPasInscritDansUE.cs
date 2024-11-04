namespace UniversiteDomain.Exceptions.NoteException;

public class EtudiantPasInscritDansUE : Exception
{
    public EtudiantPasInscritDansUE()
    {
    }
    public EtudiantPasInscritDansUE(string message) : base(message)
    {
    }
    public EtudiantPasInscritDansUE(string message, Exception inner) : base(message, inner)
    {
    }
}