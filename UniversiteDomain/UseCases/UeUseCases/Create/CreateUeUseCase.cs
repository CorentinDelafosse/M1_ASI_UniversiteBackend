using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteDomain.Exceptions.UeExceptions;

namespace UniversiteDomain.UseCases.UeUseCases.Create;

public class CreateUeUseCase(IUeRepository ueRepository)
{   
    public async Task<Ue> ExecuteAsync(Ue ue)
    {
        await CheckBusinessRules(ue);
        Ue ueCree = await ueRepository.CreateAsync(ue);
        ueRepository.SaveChangesAsync().Wait();
        return ueCree;
    }
    
    public async Task<Ue> ExecuteAsync(string numeroUe, string intitule)
    {
        ArgumentNullException.ThrowIfNull(numeroUe);
        ArgumentNullException.ThrowIfNull(intitule);
        var ue = new Ue{NumeroUe = numeroUe, Intitule = intitule};
        return await ExecuteAsync(ue);
    }
    
    public async Task<Ue> ExecuteAsync(string numeroUe, string intitule, List<Parcours> parcours)
    {
        ArgumentNullException.ThrowIfNull(numeroUe);
        ArgumentNullException.ThrowIfNull(intitule);
        ArgumentNullException.ThrowIfNull(parcours);
        var ue = new Ue{NumeroUe = numeroUe, Intitule = intitule, EnseigneeDans = parcours};
        return await ExecuteAsync(ue);
    }
    
    private async Task CheckBusinessRules(Ue ue)
    {
        // Vérification des paramètres
        ArgumentNullException.ThrowIfNull(ue);
        ArgumentNullException.ThrowIfNull(ueRepository);
        
        // Vérifie si Numéro Ue pas supérieur à 3 caractères (avec exception : UeSuperieur3)
        if (ue.NumeroUe.Length > 3) throw new UeSuperieur3(ue.NumeroUe + " - Le numéro d'Ue ne doit pas dépasser 3 caractères");
    }
}