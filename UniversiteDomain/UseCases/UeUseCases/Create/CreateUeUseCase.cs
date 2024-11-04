using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;

namespace UniversiteDomain.UseCases.UeUseCases.Create;

public class CreateUeUseCase(IUeRepository ueRepository)
{   
    public async Task<Ue> ExecuteAsync(Ue ue)
    {
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
}