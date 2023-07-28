using System.Text.Json.Serialization;

namespace Paarungsruf.Shared;

public class Matrix
{
    [JsonConstructor]
    public Matrix()
    {
    }
    
    public Matrix(List<Faction> ownPlayers, List<Faction> opponents)
    {
        foreach (var ownPlayer in ownPlayers)
        {
            var playerRating = new PlayerRatingList(ownPlayer, opponents);
            Matches.Add(playerRating);
        }
    }

    public List<PlayerRatingList> Matches { get; set; } = new();

    public void SetRating(Faction player, Faction opponent, int value)
    {
        GetPlayerMatches(player).SetValue(opponent, value);
    }

    private PlayerRatingList GetPlayerMatches(Faction player)
    {
        return Matches.Single(f => f.OwnPlayer == player);
    }

    public PlayerRating GetRating(Faction ownPlayer, Faction opponent)
    {
        return GetPlayerMatches(ownPlayer).GetRatingFor(opponent);
    }

    public Opponent SetPlayer(Faction faction)
    {
        var playerRatingList = GetPlayerMatches(faction);
        var orderedEnumerable = playerRatingList.Opponents.OrderBy(m => m.Value);
        return new Opponent(orderedEnumerable.First(), orderedEnumerable.Skip(1).First());
    }

    public void PickMatch(Faction ownPlayer, PlayerRating matchupPick)
    {
        Pairings.Add(new Pairing(ownPlayer, matchupPick.Faction, matchupPick.Value));
        GetPlayerMatches(ownPlayer).MarkPlayerAsPicked();
        foreach (var ratingList in Matches)
        {
            ratingList.GetRatingFor(matchupPick.Faction).MarkAsPicked();
        }
    }

    public List<Pairing> Pairings { get; set; } = new();

    public int ExpectedPoints => Pairings.Sum(p => p.Value) - Pairings.Count * 10;
}