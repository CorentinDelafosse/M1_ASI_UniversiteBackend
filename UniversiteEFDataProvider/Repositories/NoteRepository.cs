using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteEFDataProvider.Data;

namespace UniversiteEFDataProvider.Repositories;

public class NoteRepository(UniversiteDbContext context) : Repository<Note>(context), INoteRepository
{
    public async Task AddNoteAsync(long idEtudiant, long idUe, double valeur)
    {
        Etudiant e = (await Context.Etudiants.FindAsync(idEtudiant))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        Note n = new()
        {
            Etudiant = e,
            Ue = ue,
            Valeur = valeur
        };
        Context.Notes.Add(n);
        await Context.SaveChangesAsync();
    }
    
    public async Task AddNoteAsync(Etudiant etudiant, Ue ue, double valeur)
    {
        await AddNoteAsync(etudiant.Id, ue.Id, valeur);
    }
    
    public async Task AddNoteAsync(long idEtudiant, long idUe, double[] valeurs)
    {
        Etudiant e = (await Context.Etudiants.FindAsync(idEtudiant))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        foreach (double valeur in valeurs)
        {
            Note n = new()
            {
                Etudiant = e,
                Ue = ue,
                Valeur = valeur
            };
            Context.Notes.Add(n);
        }
        await Context.SaveChangesAsync();
    }
    
    public async Task AddNoteAsync(Etudiant etudiant, Ue ue, double[] valeurs)
    {
        await AddNoteAsync(etudiant.Id, ue.Id, valeurs);
    }
    
    public async Task AddNoteAsync(long idEtudiant, long idUe, List<double> valeurs)
    {
        Etudiant e = (await Context.Etudiants.FindAsync(idEtudiant))!;
        Ue ue = (await Context.Ues.FindAsync(idUe))!;
        foreach (double valeur in valeurs)
        {
            Note n = new()
            {
                Etudiant = e,
                Ue = ue,
                Valeur = valeur
            };
            Context.Notes.Add(n);
        }
        await Context.SaveChangesAsync();
    }
    
    public async Task AddNoteAsync(Etudiant etudiant, Ue ue, List<double> valeurs)
    {
        await AddNoteAsync(etudiant.Id, ue.Id, valeurs);
    }
}