namespace Paarungsruf.Shared;

public class Opponent
{
    public PlayerRating First { get; }
    public PlayerRating Second { get; }

    public Opponent(PlayerRating first, PlayerRating second)
    {
        First = first;
        Second = second;
    }
}