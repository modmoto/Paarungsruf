using MongoDB.Bson;
using MongoDB.Driver;
using Paarungsruf.Server.Matrixes;
using Paarungsruf.Server.Repositories;

namespace Paarungsruf.Server.Pairing;

public class PairingRepository : MongoDbRepositoryBase
{
    public PairingRepository(MongoClient mongoClient) : base(mongoClient)
    {
    }

    public Task<TournamentPairing> Load(ObjectId objectId)
    {
        return LoadFirst<TournamentPairing>(objectId); 
    }
    
    public Task Insert(TournamentPairing matrix)
    {
        return base.Insert(matrix); 
    }
}