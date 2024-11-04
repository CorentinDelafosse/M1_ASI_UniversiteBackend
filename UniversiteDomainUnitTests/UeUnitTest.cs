using System.Linq.Expressions;
using Moq;
using UniversiteDomain.DataAdapters;
using UniversiteDomain.DataAdapters.DataAdaptersFactory;
using UniversiteDomain.Entities;
using UniversiteDomain.UseCases.UeUseCases.Create;

namespace UniversiteDomainUnitTests;

public class UeUnitTest
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public async Task CreateUeUseCase()
    {
        long id = 1;
        string numeroUe = "UE1";
        string intitule = "UE 1";
        
        Ue ueAvant = new Ue{NumeroUe = numeroUe, Intitule = intitule};
        
        var mock = new Mock<IUeRepository>();
        
        var reponseFindByCondition = new List<Ue>();
        
        mock.Setup(repo=>repo.FindByConditionAsync(It.IsAny<Expression<Func<Ue, bool>>>())).ReturnsAsync(reponseFindByCondition);
        
        Ue ueCree =new Ue{Id=id,NumeroUe=numeroUe, Intitule = intitule};
        mock.Setup(repoUe=>repoUe.CreateAsync(ueAvant)).ReturnsAsync(ueCree);
        
        var fauxUeRepository = mock.Object;
        
        CreateUeUseCase useCase=new CreateUeUseCase(fauxUeRepository);
        
        var ueTeste=await useCase.ExecuteAsync(ueAvant);
        
        Assert.NotNull(ueTeste);
        Assert.That(ueTeste.Id, Is.EqualTo(ueCree.Id));
        Assert.That(ueTeste.NumeroUe, Is.EqualTo(ueCree.NumeroUe));
        Assert.That(ueTeste.Intitule, Is.EqualTo(ueCree.Intitule));
    }
}