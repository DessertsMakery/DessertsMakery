using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DessertsMakery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomDiscounts",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDiscounts", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "CustomPrices",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomPrices", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertFamilies",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertFamilies", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertFamilies_DessertFamilies_ParentId",
                        column: x => x.ParentId,
                        principalTable: "DessertFamilies",
                        principalColumn: "InternalId"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Measurings",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurings", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "RecipeDescriptionItemTypes",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDescriptionItemTypes", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "TelegramModeratorStates",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuState = table.Column<string>(type: "TEXT", nullable: true),
                    OperationState = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramModeratorStates", x => x.InternalId);
                }
            );

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReceivingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<long>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItemDetails",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    CustomPriceId = table.Column<long>(type: "INTEGER", nullable: true),
                    CustomDiscountId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDetails", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_OrderItemDetails_CustomDiscounts_CustomDiscountId",
                        column: x => x.CustomDiscountId,
                        principalTable: "CustomDiscounts",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetails_CustomPrices_CustomPriceId",
                        column: x => x.CustomPriceId,
                        principalTable: "CustomPrices",
                        principalColumn: "InternalId"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MeasuringId = table.Column<long>(type: "INTEGER", nullable: false),
                    Proportion = table.Column<decimal>(type: "TEXT", nullable: true),
                    ParentId = table.Column<long>(type: "INTEGER", nullable: true),
                    ComponentType = table.Column<string>(type: "TEXT", maxLength: 21, nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_Components_Components_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_Components_Measurings_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "Measurings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertWeights",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MeasuringValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeasuringId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertWeights", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertWeights_Measurings_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "Measurings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "RecipeDescriptionItems",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeId = table.Column<long>(type: "INTEGER", nullable: false),
                    RecipeDescriptionItemTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDescriptionItems", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_RecipeDescriptionItems_RecipeDescriptionItemTypes_RecipeDescriptionItemTypeId",
                        column: x => x.RecipeDescriptionItemTypeId,
                        principalTable: "RecipeDescriptionItemTypes",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_RecipeDescriptionItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "TelegramModerators",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TelegramModeratorStateId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramModerators", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_TelegramModerators_TelegramModeratorStates_TelegramModeratorStateId",
                        column: x => x.TelegramModeratorStateId,
                        principalTable: "TelegramModeratorStates",
                        principalColumn: "InternalId"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItemDetailsImages",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    OrderItemDetailsId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDetailsImages", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_OrderItemDetailsImages_OrderItemDetails_OrderItemDetailsId",
                        column: x => x.OrderItemDetailsId,
                        principalTable: "OrderItemDetails",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ComponentMeasuringConversion",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComponentId = table.Column<long>(type: "INTEGER", nullable: false),
                    MeasuringId = table.Column<long>(type: "INTEGER", nullable: false),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentMeasuringConversion", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_ComponentMeasuringConversion_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ComponentMeasuringConversion_Measurings_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "Measurings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Firm = table.Column<string>(type: "TEXT", nullable: true),
                    ComponentId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_Consumables_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItemDetailPackagingComponents",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderItemDetailsId = table.Column<long>(type: "INTEGER", nullable: false),
                    PackagingComponentId = table.Column<long>(type: "INTEGER", nullable: false),
                    AdditionInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    IngredientInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDetailPackagingComponents", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_OrderItemDetailPackagingComponents_Components_AdditionInternalId",
                        column: x => x.AdditionInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailPackagingComponents_Components_IngredientInternalId",
                        column: x => x.IngredientInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailPackagingComponents_Components_PackagingComponentId",
                        column: x => x.PackagingComponentId,
                        principalTable: "Components",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailPackagingComponents_OrderItemDetails_OrderItemDetailsId",
                        column: x => x.OrderItemDetailsId,
                        principalTable: "OrderItemDetails",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItemDetailsAdditions",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderItemDetailsId = table.Column<long>(type: "INTEGER", nullable: false),
                    AdditionId = table.Column<long>(type: "INTEGER", nullable: false),
                    IngredientInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    PackagingComponentInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDetailsAdditions", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_OrderItemDetailsAdditions_Components_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Components",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailsAdditions_Components_IngredientInternalId",
                        column: x => x.IngredientInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailsAdditions_Components_PackagingComponentInternalId",
                        column: x => x.PackagingComponentInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_OrderItemDetailsAdditions_OrderItemDetails_OrderItemDetailsId",
                        column: x => x.OrderItemDetailsId,
                        principalTable: "OrderItemDetails",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    RecipeId = table.Column<long>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<long>(type: "INTEGER", nullable: false),
                    MeasuringValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeasuringId = table.Column<long>(type: "INTEGER", nullable: false),
                    AdditionInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    PackagingComponentInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Components_AdditionInternalId",
                        column: x => x.AdditionInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Components_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Components",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Components_PackagingComponentInternalId",
                        column: x => x.PackagingComponentInternalId,
                        principalTable: "Components",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Measurings_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "Measurings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertFamilyWeights",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DessertFamilyId = table.Column<long>(type: "INTEGER", nullable: false),
                    DessertWeightId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertFamilyWeights", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertFamilyWeights_DessertFamilies_DessertFamilyId",
                        column: x => x.DessertFamilyId,
                        principalTable: "DessertFamilies",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_DessertFamilyWeights_DessertWeights_DessertWeightId",
                        column: x => x.DessertWeightId,
                        principalTable: "DessertWeights",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ConsumablePackagings",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConsumableId = table.Column<long>(type: "INTEGER", nullable: false),
                    MeasuringValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MeasuringId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablePackagings", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_ConsumablePackagings_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_ConsumablePackagings_Measurings_MeasuringId",
                        column: x => x.MeasuringId,
                        principalTable: "Measurings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertPricings",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DessertFamilyWeightId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertPricings", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertPricings_DessertFamilyWeights_DessertFamilyWeightId",
                        column: x => x.DessertFamilyWeightId,
                        principalTable: "DessertFamilyWeights",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertTemplates",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DessertFamilyWeightId = table.Column<long>(type: "INTEGER", nullable: false),
                    DessertFamilyInternalId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertTemplates", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertTemplates_DessertFamilies_DessertFamilyInternalId",
                        column: x => x.DessertFamilyInternalId,
                        principalTable: "DessertFamilies",
                        principalColumn: "InternalId"
                    );
                    table.ForeignKey(
                        name: "FK_DessertTemplates_DessertFamilyWeights_DessertFamilyWeightId",
                        column: x => x.DessertFamilyWeightId,
                        principalTable: "DessertFamilyWeights",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ConsumablePackagingImages",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ConsumablePackagingId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablePackagingImages", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_ConsumablePackagingImages_ConsumablePackagings_ConsumablePackagingId",
                        column: x => x.ConsumablePackagingId,
                        principalTable: "ConsumablePackagings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "ConsumablePackagingPrices",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ConsumablePackagingId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumablePackagingPrices", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_ConsumablePackagingPrices_ConsumablePackagings_ConsumablePackagingId",
                        column: x => x.ConsumablePackagingId,
                        principalTable: "ConsumablePackagings",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "DessertTemplateRecipes",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DessertTemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    RecipeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DessertTemplateRecipes", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_DessertTemplateRecipes_DessertTemplates_DessertTemplateId",
                        column: x => x.DessertTemplateId,
                        principalTable: "DessertTemplates",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_DessertTemplateRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    DessertTemplateId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrderItemDetailsId = table.Column<long>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_OrderItems_DessertTemplates_DessertTemplateId",
                        column: x => x.DessertTemplateId,
                        principalTable: "DessertTemplates",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderItemDetails_OrderItemDetailsId",
                        column: x => x.OrderItemDetailsId,
                        principalTable: "OrderItemDetails",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "PurchaseItems",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseId = table.Column<long>(type: "INTEGER", nullable: false),
                    ConsumablePackagingPriceId = table.Column<long>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItems", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_PurchaseItems_ConsumablePackagingPrices_ConsumablePackagingPriceId",
                        column: x => x.ConsumablePackagingPriceId,
                        principalTable: "ConsumablePackagingPrices",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_PurchaseItems_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "InternalId",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.InsertData(
                table: "Measurings",
                columns: new[] { "InternalId", "CreatedAt", "ExternalId", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    {
                        1L,
                        new DateTime(2024, 3, 19, 8, 19, 28, 625, DateTimeKind.Utc).AddTicks(2241),
                        new Guid("44e20708-937f-4b3a-9a30-9bd0e14314e0"),
                        false,
                        new DateTime(2024, 3, 19, 8, 19, 28, 625, DateTimeKind.Utc).AddTicks(2241),
                        "Quantity"
                    },
                    {
                        2L,
                        new DateTime(2024, 3, 19, 8, 19, 28, 625, DateTimeKind.Utc).AddTicks(2236),
                        new Guid("59f56050-6ad6-4319-ab48-f754bd595bdc"),
                        false,
                        new DateTime(2024, 3, 19, 8, 19, 28, 625, DateTimeKind.Utc).AddTicks(2236),
                        "Mass"
                    }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_ComponentMeasuringConversion_ComponentId",
                table: "ComponentMeasuringConversion",
                column: "ComponentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ComponentMeasuringConversion_ExternalId",
                table: "ComponentMeasuringConversion",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ComponentMeasuringConversion_MeasuringId",
                table: "ComponentMeasuringConversion",
                column: "MeasuringId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Components_ExternalId",
                table: "Components",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(name: "IX_Components_MeasuringId", table: "Components", column: "MeasuringId");

            migrationBuilder.CreateIndex(name: "IX_Components_ParentId", table: "Components", column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagingImages_ConsumablePackagingId",
                table: "ConsumablePackagingImages",
                column: "ConsumablePackagingId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagingImages_ExternalId",
                table: "ConsumablePackagingImages",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagingPrices_ConsumablePackagingId",
                table: "ConsumablePackagingPrices",
                column: "ConsumablePackagingId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagingPrices_ExternalId",
                table: "ConsumablePackagingPrices",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagings_ConsumableId",
                table: "ConsumablePackagings",
                column: "ConsumableId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagings_ExternalId",
                table: "ConsumablePackagings",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_ConsumablePackagings_MeasuringId",
                table: "ConsumablePackagings",
                column: "MeasuringId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ComponentId",
                table: "Consumables",
                column: "ComponentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_ExternalId",
                table: "Consumables",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CustomDiscounts_ExternalId",
                table: "CustomDiscounts",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ExternalId",
                table: "Customers",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_CustomPrices_ExternalId",
                table: "CustomPrices",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertFamilies_ExternalId",
                table: "DessertFamilies",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertFamilies_ParentId",
                table: "DessertFamilies",
                column: "ParentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertFamilyWeights_DessertFamilyId",
                table: "DessertFamilyWeights",
                column: "DessertFamilyId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertFamilyWeights_DessertWeightId",
                table: "DessertFamilyWeights",
                column: "DessertWeightId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertFamilyWeights_ExternalId",
                table: "DessertFamilyWeights",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertPricings_DessertFamilyWeightId",
                table: "DessertPricings",
                column: "DessertFamilyWeightId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertPricings_ExternalId",
                table: "DessertPricings",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplateRecipes_DessertTemplateId",
                table: "DessertTemplateRecipes",
                column: "DessertTemplateId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplateRecipes_ExternalId",
                table: "DessertTemplateRecipes",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplateRecipes_RecipeId",
                table: "DessertTemplateRecipes",
                column: "RecipeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplates_DessertFamilyInternalId",
                table: "DessertTemplates",
                column: "DessertFamilyInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplates_DessertFamilyWeightId",
                table: "DessertTemplates",
                column: "DessertFamilyWeightId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertTemplates_ExternalId",
                table: "DessertTemplates",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertWeights_ExternalId",
                table: "DessertWeights",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_DessertWeights_MeasuringId",
                table: "DessertWeights",
                column: "MeasuringId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Measurings_ExternalId",
                table: "Measurings",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailPackagingComponents_AdditionInternalId",
                table: "OrderItemDetailPackagingComponents",
                column: "AdditionInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailPackagingComponents_ExternalId",
                table: "OrderItemDetailPackagingComponents",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailPackagingComponents_IngredientInternalId",
                table: "OrderItemDetailPackagingComponents",
                column: "IngredientInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailPackagingComponents_OrderItemDetailsId",
                table: "OrderItemDetailPackagingComponents",
                column: "OrderItemDetailsId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailPackagingComponents_PackagingComponentId",
                table: "OrderItemDetailPackagingComponents",
                column: "PackagingComponentId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetails_CustomDiscountId",
                table: "OrderItemDetails",
                column: "CustomDiscountId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetails_CustomPriceId",
                table: "OrderItemDetails",
                column: "CustomPriceId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetails_ExternalId",
                table: "OrderItemDetails",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsAdditions_AdditionId",
                table: "OrderItemDetailsAdditions",
                column: "AdditionId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsAdditions_ExternalId",
                table: "OrderItemDetailsAdditions",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsAdditions_IngredientInternalId",
                table: "OrderItemDetailsAdditions",
                column: "IngredientInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsAdditions_OrderItemDetailsId",
                table: "OrderItemDetailsAdditions",
                column: "OrderItemDetailsId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsAdditions_PackagingComponentInternalId",
                table: "OrderItemDetailsAdditions",
                column: "PackagingComponentInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsImages_ExternalId",
                table: "OrderItemDetailsImages",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetailsImages_OrderItemDetailsId",
                table: "OrderItemDetailsImages",
                column: "OrderItemDetailsId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DessertTemplateId",
                table: "OrderItems",
                column: "DessertTemplateId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ExternalId",
                table: "OrderItems",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(name: "IX_OrderItems_OrderId", table: "OrderItems", column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderItemDetailsId",
                table: "OrderItems",
                column: "OrderItemDetailsId",
                unique: true
            );

            migrationBuilder.CreateIndex(name: "IX_Orders_CustomerId", table: "Orders", column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExternalId",
                table: "Orders",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ConsumablePackagingPriceId",
                table: "PurchaseItems",
                column: "ConsumablePackagingPriceId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ExternalId",
                table: "PurchaseItems",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ExternalId",
                table: "Purchases",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDescriptionItems_ExternalId",
                table: "RecipeDescriptionItems",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDescriptionItems_RecipeDescriptionItemTypeId",
                table: "RecipeDescriptionItems",
                column: "RecipeDescriptionItemTypeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDescriptionItems_RecipeId_Order",
                table: "RecipeDescriptionItems",
                columns: new[] { "RecipeId", "Order" },
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDescriptionItemTypes_ExternalId",
                table: "RecipeDescriptionItemTypes",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_AdditionInternalId",
                table: "RecipeIngredients",
                column: "AdditionInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ExternalId",
                table: "RecipeIngredients",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_MeasuringId",
                table: "RecipeIngredients",
                column: "MeasuringId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_PackagingComponentInternalId",
                table: "RecipeIngredients",
                column: "PackagingComponentInternalId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ExternalId",
                table: "Recipes",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_TelegramModerators_ExternalId",
                table: "TelegramModerators",
                column: "ExternalId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_TelegramModerators_TelegramModeratorStateId",
                table: "TelegramModerators",
                column: "TelegramModeratorStateId",
                unique: true
            );

            migrationBuilder.CreateIndex(
                name: "IX_TelegramModeratorStates_ExternalId",
                table: "TelegramModeratorStates",
                column: "ExternalId",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ComponentMeasuringConversion");

            migrationBuilder.DropTable(name: "ConsumablePackagingImages");

            migrationBuilder.DropTable(name: "DessertPricings");

            migrationBuilder.DropTable(name: "DessertTemplateRecipes");

            migrationBuilder.DropTable(name: "OrderItemDetailPackagingComponents");

            migrationBuilder.DropTable(name: "OrderItemDetailsAdditions");

            migrationBuilder.DropTable(name: "OrderItemDetailsImages");

            migrationBuilder.DropTable(name: "OrderItems");

            migrationBuilder.DropTable(name: "PurchaseItems");

            migrationBuilder.DropTable(name: "RecipeDescriptionItems");

            migrationBuilder.DropTable(name: "RecipeIngredients");

            migrationBuilder.DropTable(name: "TelegramModerators");

            migrationBuilder.DropTable(name: "DessertTemplates");

            migrationBuilder.DropTable(name: "OrderItemDetails");

            migrationBuilder.DropTable(name: "Orders");

            migrationBuilder.DropTable(name: "ConsumablePackagingPrices");

            migrationBuilder.DropTable(name: "Purchases");

            migrationBuilder.DropTable(name: "RecipeDescriptionItemTypes");

            migrationBuilder.DropTable(name: "Recipes");

            migrationBuilder.DropTable(name: "TelegramModeratorStates");

            migrationBuilder.DropTable(name: "DessertFamilyWeights");

            migrationBuilder.DropTable(name: "CustomDiscounts");

            migrationBuilder.DropTable(name: "CustomPrices");

            migrationBuilder.DropTable(name: "Customers");

            migrationBuilder.DropTable(name: "ConsumablePackagings");

            migrationBuilder.DropTable(name: "DessertFamilies");

            migrationBuilder.DropTable(name: "DessertWeights");

            migrationBuilder.DropTable(name: "Consumables");

            migrationBuilder.DropTable(name: "Components");

            migrationBuilder.DropTable(name: "Measurings");
        }
    }
}
