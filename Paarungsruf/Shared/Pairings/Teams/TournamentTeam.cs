using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Server.Matrixes;

public class TournamentTeam
{
    public string TeamName { get; set; }
    public string TeamId { get; set; }
    public Matrix Matrix { get; set; }
    public List<TeamMember> Members { get; set; }
}