namespace UniversiteDomain.Entities;

public class Note
{
    // Etudiant et UE
    public Etudiant Etudiant { get; set; } = new Etudiant();
    public Ue Ue { get; set; } = new Ue();
    public double Valeur { get; set; } = 0.0;
    public override string ToString()
    {
        return "Note de l'étudiant "+Etudiant.Nom+" "+Etudiant.Prenom+" en "+Ue.Intitule+" : "+Valeur;
    }
}