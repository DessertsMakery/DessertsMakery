namespace DessertsMakery.Common.Persistence.Mongo;

internal interface IMongoCollectionProvider
{
    IMongoEntityCollection Create(Type entityType);
}
