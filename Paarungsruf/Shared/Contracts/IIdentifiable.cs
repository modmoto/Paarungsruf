using MongoDB.Bson;

namespace Paarungsruf.Shared.Contracts;

public interface IIdentifiable
{
    public ObjectId Id { get; }
}