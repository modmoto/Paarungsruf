namespace Paarungsruf.Shared.Pairings;

public class PlayerRating
{
    public Faction Faction { get; set; }
    public int Value { get; set; }
    public bool WasPicked { get; set; }

    public PlayerRating(Faction faction, int value)
    {
        Faction = faction;
        Value = value;
    }

    public void MarkAsPicked()
    {
        WasPicked = true;
    }
}