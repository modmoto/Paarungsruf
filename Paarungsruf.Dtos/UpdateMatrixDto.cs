using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Dtos;

public class UpdateMatrixDto
{
    public int ExpectedValue { get; set; }
    public Faction Opponent { get; set; }
    public Faction Player { get; set; }
}