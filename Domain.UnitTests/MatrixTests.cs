using Paarungsruf.Shared;
using Paarungsruf.Shared.Pairings;

namespace Domain.UnitTests;

public class MatrixTests
{
    [Test] public void SetPlayer()
    {
        var exampleMatrix = CreateExampleMatrix();
        var player = exampleMatrix.SetPlayer(Faction.BeastHeards);
        Assert.That(player.First.Value, Is.EqualTo(7));
        Assert.That(player.Second.Value, Is.EqualTo(10));
        
        var player2 = exampleMatrix.SetPlayer(Faction.DaemonLegions);
        Assert.That(player2.First.Value, Is.EqualTo(5));
        Assert.That(player2.Second.Value, Is.EqualTo(6));
    }

    [Test] public void SetPlayer_PickMatch()
    {
        var exampleMatrix = CreateExampleMatrix();
        var matchupPick = exampleMatrix.SetPlayer(Faction.BeastHeards);
        
        exampleMatrix.PickMatch(Faction.BeastHeards, matchupPick.First);
        
        Assert.That(exampleMatrix.Matches[0].WasPicked, Is.EqualTo(true));
        Assert.That(exampleMatrix.Matches[1].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[2].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[0].Opponents[2].WasPicked, Is.EqualTo(true));
        Assert.That(exampleMatrix.Matches[1].Opponents[2].WasPicked, Is.EqualTo(true));
        Assert.That(exampleMatrix.Matches[2].Opponents[2].WasPicked, Is.EqualTo(true));
        Assert.That(exampleMatrix.Matches[0].Opponents[1].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[1].Opponents[1].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[2].Opponents[1].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[0].Opponents[0].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[1].Opponents[0].WasPicked, Is.EqualTo(false));
        Assert.That(exampleMatrix.Matches[2].Opponents[0].WasPicked, Is.EqualTo(false));
    }
    
    [Test] public void SetPlayer_ExpectedPoints()
    {
        var exampleMatrix = CreateExampleMatrix();
        var matchupPick = exampleMatrix.SetPlayer(Faction.BeastHeards);
        
        exampleMatrix.PickMatch(Faction.BeastHeards, matchupPick.First);
        Assert.That(exampleMatrix.ExpectedPoints, Is.EqualTo(-3));
    }

    
    [Test] public void SetPlayer_ExpectedPoints_2()
    {
        var exampleMatrix = CreateExampleMatrix();
        var matchupPick = exampleMatrix.SetPlayer(Faction.BeastHeards);
        
        exampleMatrix.PickMatch(Faction.BeastHeards, matchupPick.Second);
        Assert.That(exampleMatrix.ExpectedPoints, Is.EqualTo(0));
    }

    [Test]
    public void CreateAllMutations()
    {
        var exampleMatrix = CreateExampleMatrix();
        var mutator = new Mutator(exampleMatrix);
        var mutations = mutator.Mutate();
        Assert.That(mutations.Count, Is.EqualTo(27));
    }
    
    private Matrix CreateExampleMatrix()
    {
        var matrix = new Matrix(
            new List<Faction> { Faction.BeastHeards, Faction.DaemonLegions, Faction.HighbornElves },
            new List<Faction> { Faction.SaurianAncients, Faction.VerminSwarm, Faction.KingdomOfEquitaine });
        
        matrix.SetRating(Faction.BeastHeards, Faction.SaurianAncients,10);
        matrix.SetRating(Faction.BeastHeards, Faction.VerminSwarm,11);
        matrix.SetRating(Faction.BeastHeards, Faction.KingdomOfEquitaine,7);
        matrix.SetRating(Faction.DaemonLegions, Faction.SaurianAncients,9);
        matrix.SetRating(Faction.DaemonLegions, Faction.VerminSwarm,5);
        matrix.SetRating(Faction.DaemonLegions, Faction.KingdomOfEquitaine,6);
        matrix.SetRating(Faction.HighbornElves, Faction.SaurianAncients,14);
        matrix.SetRating(Faction.HighbornElves, Faction.VerminSwarm, 16);
        matrix.SetRating(Faction.HighbornElves, Faction.KingdomOfEquitaine, 5);
        return matrix;
    }
}