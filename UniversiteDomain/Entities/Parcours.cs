namespace UniversiteDomain.Entities;

public class Parcours
{
    public long Id { get; set; }
    public string NomParcours { get; set; } = string.Empty;
    public int AnneeFormation { get; set; } = 0;
    public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();
    
    public override string ToString()
    {
        return $"ID {Id} : {NomParcours} {AnneeFormation}";
    }
}