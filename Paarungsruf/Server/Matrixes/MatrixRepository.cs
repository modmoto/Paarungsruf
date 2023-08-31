using MongoDB.Bson;
using MongoDB.Driver;
using Paarungsruf.Server.Repositories;
using Paarungsruf.Shared;

namespace Paarungsruf.Server.Matrixes;

public class MatrixRepository : MongoDbRepositoryBase
{
    public MatrixRepository(MongoClient mongoClient) : base(mongoClient)
    {
    }

    public Task<List<Matrix>> Load()
    {
        return LoadAll<Matrix>(); 
    }

    public Task<Matrix> Load(ObjectId objectId)
    {
        return LoadFirst<Matrix>(objectId); 
    }
    
    public Task<bool> Update(Matrix matrix)
    {
        return UpdateVersionsave(matrix); 
    }
    
    public Task Insert(Matrix matrix)
    {
        return base.Insert(matrix); 
    }
}