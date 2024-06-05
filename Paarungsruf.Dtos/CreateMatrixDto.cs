using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Dtos;

public class CreateMatrixDto
{
    public CreateMatrixDto(List<Faction> ownTeam, List<Faction> opponents)
    {
        OwnTeam = ownTeam;
        Opponents = opponents;
    }
    
    public List<Faction> OwnTeam { get; set; }
    public List<Faction> Opponents { get; set; }
}