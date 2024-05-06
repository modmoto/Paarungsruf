using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Server.Matrixes;

public class TeamAndMatrix
{
    public Matrix Matrix { get; set; }
    public TournamentTeam Opponent { get; set; }
}