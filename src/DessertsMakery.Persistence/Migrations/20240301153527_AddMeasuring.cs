using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DessertsMakery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMeasuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Components_ComponentInternalId",
                table: "RecipeIngredients"
            );

            migrationBuilder.DeleteData(table: "RecipeDescriptionItemTypes", keyColumn: "InternalId", keyValue: 1L);

            migrationBuilder.DeleteData(table: "RecipeDescriptionItemTypes", keyColumn: "InternalId", keyValue: 2L);

            migrationBuilder.RenameColumn(
                name: "ComponentInternalId",
                table: "RecipeIngredients",
                newName: "PackagingComponentInternalId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_ComponentInternalId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_PackagingComponentInternalId"
            );

            migrationBuilder.AddColumn<long>(
                name: "AdditionInternalId",
                table: "RecipeIngredients",
                type: "INTEGER",
                nullable: true
            );

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RecipeIngredients",
                type: "TEXT",
                maxLength: 100,
                nullable: true
            );

            migrationBuilder.AddColumn<long>(
                name: "MeasuringId",
                table: "Components",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L
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

            migrationBuilder.InsertData(
                table: "Measurings",
                columns: new[] { "InternalId", "CreatedAt", "ExternalId", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    {
                        1L,
                        new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8989),
                        new Guid("a00a53bf-f4b4-4f0a-9280-011e0c0c8388"),
                        false,
                        new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8989),
                        "Quantity"
                    },
                    {
                        2L,
                        new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8985),
                        new Guid("8daeae66-fc98-4d07-95e1-2eba336ab2ab"),
                        false,
                        new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8985),
                        "Mass"
                    }
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_AdditionInternalId",
                table: "RecipeIngredients",
                column: "AdditionInternalId"
            );

            migrationBuilder.CreateIndex(name: "IX_Components_MeasuringId", table: "Components", column: "MeasuringId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Measurings_MeasuringId",
                table: "Components",
                column: "MeasuringId",
                principalTable: "Measurings",
                principalColumn: "InternalId",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Components_AdditionInternalId",
                table: "RecipeIngredients",
                column: "AdditionInternalId",
                principalTable: "Components",
                principalColumn: "InternalId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Components_PackagingComponentInternalId",
                table: "RecipeIngredients",
                column: "PackagingComponentInternalId",
                principalTable: "Components",
                principalColumn: "InternalId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Components_Measurings_MeasuringId", table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Components_AdditionInternalId",
                table: "RecipeIngredients"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Components_PackagingComponentInternalId",
                table: "RecipeIngredients"
            );

            migrationBuilder.DropTable(name: "ComponentMeasuringConversion");

            migrationBuilder.DropIndex(name: "IX_RecipeIngredients_AdditionInternalId", table: "RecipeIngredients");

            migrationBuilder.DropIndex(name: "IX_Components_MeasuringId", table: "Components");

            migrationBuilder.DeleteData(table: "Measurings", keyColumn: "InternalId", keyValue: 1L);

            migrationBuilder.DeleteData(table: "Measurings", keyColumn: "InternalId", keyValue: 2L);

            migrationBuilder.DropColumn(name: "AdditionInternalId", table: "RecipeIngredients");

            migrationBuilder.DropColumn(name: "Name", table: "RecipeIngredients");

            migrationBuilder.DropColumn(name: "MeasuringId", table: "Components");

            migrationBuilder.RenameColumn(
                name: "PackagingComponentInternalId",
                table: "RecipeIngredients",
                newName: "ComponentInternalId"
            );

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_PackagingComponentInternalId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_ComponentInternalId"
            );

            migrationBuilder.InsertData(
                table: "RecipeDescriptionItemTypes",
                columns: new[] { "InternalId", "CreatedAt", "ExternalId", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    {
                        1L,
                        new DateTime(2024, 3, 1, 14, 19, 31, 237, DateTimeKind.Utc).AddTicks(5719),
                        new Guid("7e115719-3d52-4d10-92c6-94f8074b14c1"),
                        false,
                        new DateTime(2024, 3, 1, 14, 19, 31, 237, DateTimeKind.Utc).AddTicks(5719),
                        "Step"
                    },
                    {
                        2L,
                        new DateTime(2024, 3, 1, 14, 19, 31, 237, DateTimeKind.Utc).AddTicks(5714),
                        new Guid("220bba1c-c15a-45b3-a535-eba1c2256710"),
                        false,
                        new DateTime(2024, 3, 1, 14, 19, 31, 237, DateTimeKind.Utc).AddTicks(5714),
                        "Remark"
                    }
                }
            );

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Components_ComponentInternalId",
                table: "RecipeIngredients",
                column: "ComponentInternalId",
                principalTable: "Components",
                principalColumn: "InternalId"
            );
        }
    }
}
