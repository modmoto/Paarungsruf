using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Paarungsruf.Dtos;
using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Server.Matrixes;

[ApiController]
[Route("Matrixes")]
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
        var matrices = await _matrixRepository.Load();
        return Ok(matrices);
    }
    
    [HttpGet("id")]
    public async Task<ActionResult<List<Matrix>>> GetMatrix([FromRoute] string id)
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
    public async Task<ActionResult<Matrix>> CreateMatrix([FromBody] CreateMatrixDto createMatrixDto)
    {
        var matrix = new Matrix(createMatrixDto.OwnTeam, createMatrixDto.Opponents);
        await _matrixRepository.Insert(matrix);
        return Ok(matrix);
    }
}