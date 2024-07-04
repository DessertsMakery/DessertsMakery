using MongoDB.Driver;

namespace DessertsMakery.Common.Persistence.Mongo;

public interface IMongoEntityCollection<T> : IMongoCollection<T>, IMongoEntityCollection
    where T : MongoEntity;

public interface IMongoEntityCollection;
