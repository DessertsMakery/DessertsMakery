using DessertsMakery.Persistence.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database.Interfaces;

public interface ICustomerTables
{
    DbSet<Customer> Customers { get; set; }
}
