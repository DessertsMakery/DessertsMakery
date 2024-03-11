namespace DessertsMakery.Persistence.Database.Interfaces;

public interface IDatabase
    : IConsumableTables,
        ICustomerTables,
        IDessertTables,
        IEssentialTables,
        IOrderTables,
        IPurchaseTables,
        IRecipeTables,
        ITelegramTables { }
