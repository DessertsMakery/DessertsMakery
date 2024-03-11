using DessertsMakery.Persistence.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface ICustomerTables : ITables
{
    DbSet<Customer> Customers { get; }
}
