namespace UniversiteDomain.Entities;

public class Note
{
    // Etudiant et UE
    public long EtudiantId { get; set; } = 0;
    public long UeId { get; set; } = 0;
    //OneToMany vers Etudiant
    public virtual Etudiant Etudiant { get; set; } = new();
    //ManyToOne vers UE
    public virtual Ue Ue { get; set; } = new();
    public double Valeur { get; set; } = 0.0;
    public override string ToString()
    {
        return "Note de l'étudiant "+EtudiantId+" en UE "+UeId+" : "+Valeur;
    }
}