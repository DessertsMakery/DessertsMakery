using DessertsMakery.Persistence.Database.Interfaces;
using DessertsMakery.Persistence.Models.Consumables;
using DessertsMakery.Persistence.Models.Customers;
using DessertsMakery.Persistence.Models.Desserts;
using DessertsMakery.Persistence.Models.Essentials;
using DessertsMakery.Persistence.Models.Orders;
using DessertsMakery.Persistence.Models.Purchases;
using DessertsMakery.Persistence.Models.Recipes;
using Microsoft.EntityFrameworkCore;

namespace DessertsMakery.Persistence.Database;

internal sealed partial class DatabaseContext : IDatabase
{
#nullable disable
    public DbSet<Consumable> Consumables { get; set; }
    public DbSet<ConsumablePackaging> ConsumablePackagings { get; set; }
    public DbSet<ConsumablePackagingImage> ConsumablePackagingImages { get; set; }
    public DbSet<ConsumablePackagingPrice> ConsumablePackagingPrices { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<DessertFamily> DessertFamilies { get; set; }
    public DbSet<DessertFamilyWeight> DessertFamilyWeights { get; set; }
    public DbSet<DessertPricing> DessertPricings { get; set; }
    public DbSet<DessertTemplate> DessertTemplates { get; set; }
    public DbSet<DessertTemplateRecipe> DessertTemplateRecipes { get; set; }
    public DbSet<DessertWeight> DessertWeights { get; set; }

    public DbSet<Addition> Additions { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<Measuring> Measurings { get; set; }
    public DbSet<PackagingComponent> PackagingComponents { get; set; }

    public DbSet<CustomDiscount> CustomDiscounts { get; set; }
    public DbSet<CustomPrice> CustomPrices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderItemDetailPackagingComponent> OrderItemDetailPackagingComponents { get; set; }
    public DbSet<OrderItemDetails> OrderItemDetails { get; set; }
    public DbSet<OrderItemDetailsAddition> OrderItemDetailsAdditions { get; set; }
    public DbSet<OrderItemDetailsImage> OrderItemDetailsImages { get; set; }

    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseItem> PurchaseItems { get; set; }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeDescriptionItem> RecipeDescriptionItems { get; set; }
    public DbSet<RecipeDescriptionItemType> RecipeDescriptionItemTypes { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
#nullable enable
}
