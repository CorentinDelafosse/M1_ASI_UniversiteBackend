using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteDomain.Exceptions.NoteException;

namespace UniversiteDomain.UseCases.NoteUseCases.Create;

public class CreateNoteUseCase(INoteRepository noteRepository)
{
    public async Task<Note> ExecuteAsync(Note note)
    {
        await CheckBusinessRules(note);
        return await noteRepository.CreateAsync(note);
    }
    
    public async Task<Note> ExecuteAsync(Etudiant etudiant, Ue ue, double valeur)
    {
        ArgumentNullException.ThrowIfNull(etudiant);
        ArgumentNullException.ThrowIfNull(ue);
        ArgumentNullException.ThrowIfNull(valeur);
        Note note = new Note { Etudiant = etudiant, Ue = ue, Valeur = valeur };
        return await ExecuteAsync(note);
    }

    private async Task CheckBusinessRules(Note note)
    {
        ArgumentNullException.ThrowIfNull(note);
        ArgumentNullException.ThrowIfNull(note.Etudiant);
        ArgumentNullException.ThrowIfNull(note.Ue);
        ArgumentNullException.ThrowIfNull(note.Valeur);
        
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(note.Valeur);
        
        ArgumentNullException.ThrowIfNull(noteRepository);
        
        // On vérifie que le résultat est compris entre 0 et 20
        if (note.Valeur < 0 || note.Valeur > 20) throw new NoteHorsBornes(note.Valeur.ToString());
        
        // On vérifie que l'étudiant est bien inscrit à l'UE grace au ParcoursSuivi
        if (note.Etudiant.ParcoursSuivi.UesEnseignees is { Count: > 0 })
        {
            if (note.Etudiant.ParcoursSuivi.UesEnseignees.Contains(note.Ue)) return;
            else throw new EtudiantPasInscritDansUE(note.Etudiant.Id.ToString()+" n'est pas inscrit à l'UE : "+note.Ue.Id);
        }
        
        
    }
}