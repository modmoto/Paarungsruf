namespace Paarungsruf.Shared.Pairings;

public class Pairing
{
    public Faction OwnPlayer { get; set; }
    public Faction Opponent { get; set; }
    public int Value { get; set; }

    public Pairing(Faction ownPlayer, Faction opponent, int value)
    {
        OwnPlayer = ownPlayer;
        Opponent = opponent;
        Value = value;
    }
}