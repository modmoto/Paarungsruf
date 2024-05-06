using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Paarungsruf.Shared.Pairings;

namespace Paarungsruf.Server.Pairing;

[ApiController]
[Route("[controller]")]
public class PairingController : ControllerBase
{
    private readonly PairingRepository _matrixRepository;

    public PairingController(PairingRepository matrixRepository)
    {
        _matrixRepository = matrixRepository;
    }

    [HttpGet("id")]
    public async Task<ActionResult<List<Matrix>>> GetMatrixes([FromRoute] string id)
    {
        return Ok(await _matrixRepository.Load(new ObjectId(id)));
    }
    
    [HttpPost]
    public async Task<ActionResult<Matrix>> UpdateMatrix([FromBody] CreatePairingDto createPairingDto)
    {
        return Ok(new CreatePairingDto { TournamentId = Guid.NewGuid().ToString() });
    }
}

public class CreatePairingDto
{
    public string TournamentId { get; set; }
}