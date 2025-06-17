using NUnit.Framework;
using ProceduralDungeon.UseCases;
using ProceduralDungeon.Infrastructure;

public class GenerateDungeonUseCaseTests
{
    [Test]
    public void SameSeed_ShouldGenerateIdenticalLayout()
    {
        var gen = new DungeonGenerator();
        var useCase = new GenerateDungeonUseCase(gen);
        var seed = 42;

        var roomsA = useCase.Execute(seed);
        var roomsB = useCase.Execute(seed);

        Assert.AreEqual(roomsA.Count, roomsB.Count);
        for (int i = 0; i < roomsA.Count; i++)
            Assert.AreEqual(roomsA[i].rect, roomsB[i].rect);
    }
}