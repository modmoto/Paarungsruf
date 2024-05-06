using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Server.Matrixes;

[ApiController]
[Route("[controller]")]
public class MatrixController : ControllerBase
{
    private readonly MatrixRepository _matrixRepository;

    public MatrixController(MatrixRepository matrixRepository)
    {
        _matrixRepository = matrixRepository;
    }

    [HttpGet("id")]
    public async Task<ActionResult<List<Matrix>>> GetMatrixes([FromRoute] string id)
    {
        return Ok(await _matrixRepository.Load(new ObjectId(id)));
    }
    
    [HttpPut("matrixId")]
    public async Task<ActionResult<Matrix>> UpdateMatrix([FromRoute] string matrixId, [FromBody] UpdateMatrixDto updateMatrixDto)
    {
        var matrix = await _matrixRepository.Load(new ObjectId(matrixId));
        matrix.SetRating(updateMatrixDto.Player, updateMatrixDto.Opponent, updateMatrixDto.ExpectedValue);
        var worked = await _matrixRepository.Update(matrix);
        return worked ? Ok(matrix) : Conflict();
    }
    
    [HttpPost]
    public async Task<ActionResult<Matrix>> UpdateMatrix([FromBody] CreateMatrixDto createMatrixDto)
    {
        var matrix1 = new Matrix(new List<Faction>(), new List<Faction>());
        var matrix2 = new Matrix(new List<Faction>(), new List<Faction>());
        await _matrixRepository.Insert(matrix1);
        await _matrixRepository.Insert(matrix2);
        return Ok(new CreateMatrixDto { TournamentId = Guid.NewGuid().ToString() });
    }
}

public class CreateMatrixDto
{
    public string TournamentId { get; set; }
}

public class UpdateMatrixDto
{
    public int ExpectedValue { get; set; }
    public Faction Opponent { get; set; }
    public Faction Player { get; set; }
}