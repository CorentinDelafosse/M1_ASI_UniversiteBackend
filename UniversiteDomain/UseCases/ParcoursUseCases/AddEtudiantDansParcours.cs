using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;

namespace UniversiteDomain.UseCases.ParcoursUseCases;

public class AddEtudiantDansParcours
{   
    public async Task<Parcours> ExecuteAsync(Parcours parcours, Etudiant etudiant)
    {
        await CheckBusinessRules(parcours, etudiant);
        parcours.Etudiants.Add(etudiant);
        parcoursRepository.SaveChangesAsync().Wait();
        return parcours;
    }
    
    private async Task CheckBusinessRules(Parcours parcours, Etudiant etudiant)
    {
        ArgumentNullException.ThrowIfNull(parcours);
        ArgumentNullException.ThrowIfNull(etudiant);
        ArgumentNullException.ThrowIfNull(parcoursRepository); 
    }
    
    private readonly IParcoursRepository parcoursRepository;
    
    public AddEtudiantDansParcours(IParcoursRepository parcoursRepository)
    {
        this.parcoursRepository = parcoursRepository;
    }
}