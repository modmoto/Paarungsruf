using Microsoft.AspNetCore.Mvc;
using Paarungsruf.Shared.Tournaments;

namespace Paarungsruf.Server.NewRecruit;

[ApiController]
[Route("[controller]")]
public class TournamentController : ControllerBase
{
    private readonly TournamentRepository _tournamentRepository;

    public TournamentController(TournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tournament>>> GetMatrixes()
    {
        var newRecruitTournamentDtos = await _tournamentRepository.Load(new DateTimeOffset(2024,1,1,0,0,0, TimeSpan.Zero), new DateTimeOffset(2024,2,1,0,0,0, TimeSpan.Zero));
        var tournaments = newRecruitTournamentDtos.Select(t => new Tournament
        {
            Id = t._id,
            Name = t.name
        });
        return Ok(tournaments);
    }
}