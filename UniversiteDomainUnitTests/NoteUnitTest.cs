using System.Linq.Expressions;
using Moq;
using UniversiteDomain.DataAdapters;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.UseCases.NoteUseCases.Create;

namespace UniversiteDomainUnitTests;

public class NoteUnitTest
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public async Task CreateNoteUseCase()
    {
        double valeur = 10;
        Etudiant etudiant = new Etudiant { Id = 1 };
        Ue ue = new Ue { Id = 1 };
        Parcours parcours = new Parcours { Id = 1, Inscrits = new List<Etudiant> { etudiant }, UesEnseignees = new List<Ue> { ue } };
        etudiant.ParcoursSuivi = parcours;
        ue.EnseigneeDans = new List<Parcours> { parcours };
        
        Note noteAvant = new Note { Etudiant = etudiant, Ue = ue, Valeur = valeur };
        
        var mock = new Mock<INoteRepository>();
        
        var reponseFindByCondition = new List<Note>();
        
        mock.Setup(repo=>repo.FindByConditionAsync(It.IsAny<Expression<Func<Note, bool>>>())).ReturnsAsync(reponseFindByCondition);
        
        Note noteCree = new Note { Etudiant = etudiant, Ue = ue, Valeur = valeur };
        mock.Setup(repoNote=>repoNote.CreateAsync(noteAvant)).ReturnsAsync(noteCree);
        
        var fauxNoteRepository = mock.Object;
        
        CreateNoteUseCase useCase = new CreateNoteUseCase(fauxNoteRepository);
        
        var noteTeste = await useCase.ExecuteAsync(noteAvant);
        
        Assert.NotNull(noteTeste);
        Assert.That(noteTeste.Etudiant.Id, Is.EqualTo(noteCree.Etudiant.Id));
        Assert.That(noteTeste.Ue.Id, Is.EqualTo(noteCree.Ue.Id));
        Assert.That(noteTeste.Valeur, Is.EqualTo(noteCree.Valeur));
    }
}