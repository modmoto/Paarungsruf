using System.Text.Json;

namespace Paarungsruf.Shared;

public class Mutator
{
    private readonly Matrix _exampleMatrix;

    public Mutator(Matrix exampleMatrix)
    {
        _exampleMatrix = exampleMatrix;
    }

    public List<Matrix> Mutate()
    {
        var amount = _exampleMatrix.Matches.Count * _exampleMatrix.Matches.Count;
        var matrices = new List<Matrix>();
        var serializeObject = JsonSerializer.Serialize(_exampleMatrix);
        for (int a = 0; a < amount; a++)
        {
            var deserializeObject = JsonSerializer.Deserialize<Matrix>(serializeObject);
            matrices.Add(deserializeObject);
        }
        return matrices;
    }
}