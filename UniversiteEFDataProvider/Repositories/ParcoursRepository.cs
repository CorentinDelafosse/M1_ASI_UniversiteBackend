using UniversiteDomain.DataAdapters;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteEFDataProvider.Data;

namespace UniversiteEFDataProvider.Repositories;

public class ParcoursRepository(UniversiteDbContext context) : Repository<Parcours>(context), IParcoursRepository
{
    public async Task<Parcours> AddEtudiantAsync(Parcours parcours, Etudiant etudiant)
    {
        ArgumentNullException.ThrowIfNull(parcours);
        ArgumentNullException.ThrowIfNull(etudiant);
        parcours.Inscrits.Add(etudiant);
        await Context.SaveChangesAsync();
        return parcours;
    }
    public async Task<Parcours> AddEtudiantAsync(long idParcours, long idEtudiant)
    {
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        Etudiant e = (await Context.Etudiants.FindAsync(idEtudiant))!;
        return await AddEtudiantAsync(p, e);
    }
    public async Task<Parcours> AddEtudiantAsync(Parcours? parcours, List<Etudiant> etudiants)
    {
        ArgumentNullException.ThrowIfNull(parcours);
        ArgumentNullException.ThrowIfNull(etudiants);
        foreach (Etudiant e in etudiants)
        {
            parcours.Inscrits.Add(e);
        }
        await Context.SaveChangesAsync();
        return parcours;
    }
    public async Task<Parcours> AddEtudiantAsync(long idParcours, long[] idEtudiants)
    {
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        List<Etudiant> etudiants = new();
        foreach (long id in idEtudiants)
        {
            etudiants.Add((await Context.Etudiants.FindAsync(id))!);
        }
        return await AddEtudiantAsync(p, etudiants);
    }
    public async Task<Parcours> AddUeAsync(long idParcours, long idUe)
    {
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        p.UesEnseignees.Add(ue);
        await Context.SaveChangesAsync();
        return p;
    }
    public async Task<Parcours> AddUeAsync(long idParcours, long[] idUes)
    {
        Parcours p = (await Context.Parcours.FindAsync(idParcours))!;
        List<Ue> ues = new();
        foreach (long id in idUes)
        {
            ues.Add((await Context.Ues.FindAsync(id))!);
        }
        foreach (Ue ue in ues)
        {
            p.UesEnseignees.Add(ue);
        }
        await Context.SaveChangesAsync();
        return p;
    }
}