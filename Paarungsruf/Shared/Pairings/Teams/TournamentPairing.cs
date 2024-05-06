using MongoDB.Bson;
using Paarungsruf.Shared.Contracts;

namespace Paarungsruf.Server.Matrixes;

public class TournamentPairing : IIdentifiable
{
    public List<TeamAndMatrix> Matrices { get; set; }
    public ObjectId Id { get; }
}