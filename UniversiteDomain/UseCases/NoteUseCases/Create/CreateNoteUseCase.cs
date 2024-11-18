using UniversiteDomain.DataAdapters;
using UniversiteDomain.Entities;
using UniversiteDomain.Exceptions.NoteException;

namespace UniversiteDomain.UseCases.NoteUseCases.Create;

public class CreateNoteUseCase(INoteRepository noteRepository)
{
    public async Task<Note> ExecuteAsync(Note note)
    {
        await CheckBusinessRules(note);
        Note noteCree = await noteRepository.CreateAsync(note);
        noteRepository.SaveChangesAsync().Wait();
        return noteCree;
    }
    
    public async Task<Note> ExecuteAsync(long etudiantId, long ueId, double valeur)
    {
        ArgumentNullException.ThrowIfNull(etudiantId);
        ArgumentNullException.ThrowIfNull(ueId);
        ArgumentNullException.ThrowIfNull(valeur);
        Note note = new Note { EtudiantId = etudiantId, UeId = ueId, Valeur = valeur };
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
            if (!note.Etudiant.ParcoursSuivi.UesEnseignees.Contains(note.Ue))
            {
                throw new EtudiantPasInscritDansUE(note.Etudiant.Id.ToString() + " n'est pas inscrit à l'UE : " +
                                                   note.Ue.Id);
            }
        }
        else
            throw new EtudiantPasInscritDansUE(note.Etudiant.Id.ToString() + " n'est pas inscrit à l'UE : " +
                                               note.Ue.Id);

        // On vérifie que l'étudiant n'a pas déjà une note pour cette UE
        if (noteRepository
                .FindByConditionAsync(n => n.Etudiant.Id.Equals(note.Etudiant.Id) && n.Ue.Id.Equals(note.Ue.Id))
                .Result is { Count: > 0 })
        {
            throw new NoteDejaExistante(note.Etudiant.Id.ToString() + " a déjà une note pour l'UE : " + note.Ue.Id);
        }
    }
}