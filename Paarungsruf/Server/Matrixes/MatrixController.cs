using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Paarungsruf.Shared;

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

    [HttpGet]
    public async Task<ActionResult<List<Matrix>>> GetMatrixes()
    {
        return Ok(await _matrixRepository.Load());
    }
    
    [HttpPut("id")]
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
        var matrix = new Matrix(createMatrixDto.OwnPlayers, createMatrixDto.Opponents);
        await _matrixRepository.Insert(matrix);
        return Ok(matrix);
    }
}

public class CreateMatrixDto
{
    public List<Faction> Opponents { get; set; }
    public List<Faction> OwnPlayers { get; set; }
}

public class UpdateMatrixDto
{
    public int ExpectedValue { get; set; }
    public Faction Opponent { get; set; }
    public Faction Player { get; set; }
}