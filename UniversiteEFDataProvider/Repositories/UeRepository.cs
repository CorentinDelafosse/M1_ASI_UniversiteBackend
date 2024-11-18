using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteEFDataProvider.Data;

namespace UniversiteEFDataProvider.Repositories;

public class UeRepository(UniversiteDbContext context) : Repository<Ue>(context), IUeRepository
{
    public async Task AddParcoursAsync(long idUe, long idParcours)
    {
        ArgumentNullException.ThrowIfNull(Context.Ues);
        ArgumentNullException.ThrowIfNull(Context.Parcours);
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        ue.EnseigneeDans.Add(p);
        await Context.SaveChangesAsync();
    }

    public async Task AddParcoursAsync(Ue ue, Parcours parcours)
    {
        await AddParcoursAsync(ue.Id, parcours.Id);
    }
    
    public async Task AddParcoursAsync(long idUe, long[] idParcours)
    {
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        List<Parcours> parcours = new();
        foreach (long id in idParcours)
        {
            parcours.Add((await Context.Parcours.FindAsync(id))!);
        }
        foreach (Parcours p in parcours)
        {
            ue.EnseigneeDans.Add(p);
        }
        await Context.SaveChangesAsync();
    }
}