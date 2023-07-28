namespace Paarungsruf.Shared;

public class PlayerRatingList
{
    public Faction OwnPlayer { get; set; }
    public List<PlayerRating> Opponents { get; set; }
    public bool WasPicked { get; set; }

    public PlayerRatingList(Faction ownPlayer, List<Faction> opponents)
    {
        OwnPlayer = ownPlayer;
        Opponents = opponents.Select(r => new PlayerRating(r, 0)).ToList();
    }

    public void SetValue(Faction opponent, int value)
    {
        GetOppenent(opponent).Value = value;
    }

    private PlayerRating GetOppenent(Faction opponent)
    {
        return Opponents.Single(o => o.Faction == opponent);
    }

    public PlayerRating GetRatingFor(Faction opponent)
    {
        return GetOppenent(opponent);
    }

    public void MarkPlayerAsPicked()
    {
        WasPicked = true;
    }
}