using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DessertsMakery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNestedIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(name: "ParentId", table: "Components", type: "INTEGER", nullable: true);

            migrationBuilder.AddColumn<decimal>(name: "Proportion", table: "Components", type: "TEXT", nullable: true);

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 1, 16, 32, 57, 688, DateTimeKind.Utc).AddTicks(9443),
                    new Guid("70ebbf47-48b3-490f-b432-2e853ddf7e54"),
                    new DateTime(2024, 3, 1, 16, 32, 57, 688, DateTimeKind.Utc).AddTicks(9443)
                }
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 1, 16, 32, 57, 688, DateTimeKind.Utc).AddTicks(9437),
                    new Guid("ceb3add0-90ba-4078-9bae-8e86520a49e6"),
                    new DateTime(2024, 3, 1, 16, 32, 57, 688, DateTimeKind.Utc).AddTicks(9437)
                }
            );

            migrationBuilder.CreateIndex(name: "IX_Components_ParentId", table: "Components", column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Components_ParentId",
                table: "Components",
                column: "ParentId",
                principalTable: "Components",
                principalColumn: "InternalId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Components_Components_ParentId", table: "Components");

            migrationBuilder.DropIndex(name: "IX_Components_ParentId", table: "Components");

            migrationBuilder.DropColumn(name: "ParentId", table: "Components");

            migrationBuilder.DropColumn(name: "Proportion", table: "Components");

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8989),
                    new Guid("a00a53bf-f4b4-4f0a-9280-011e0c0c8388"),
                    new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8989)
                }
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8985),
                    new Guid("8daeae66-fc98-4d07-95e1-2eba336ab2ab"),
                    new DateTime(2024, 3, 1, 15, 35, 27, 693, DateTimeKind.Utc).AddTicks(8985)
                }
            );
        }
    }
}
