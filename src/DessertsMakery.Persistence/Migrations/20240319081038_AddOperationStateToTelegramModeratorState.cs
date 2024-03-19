using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DessertsMakery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOperationStateToTelegramModeratorState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OperationState",
                table: "TelegramModeratorMenuStates",
                type: "TEXT",
                nullable: true
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 19, 8, 10, 37, 246, DateTimeKind.Utc).AddTicks(7051),
                    new Guid("939fd2e0-a8e7-471f-9e7f-0b87042a683f"),
                    new DateTime(2024, 3, 19, 8, 10, 37, 246, DateTimeKind.Utc).AddTicks(7051)
                }
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 19, 8, 10, 37, 246, DateTimeKind.Utc).AddTicks(7042),
                    new Guid("a69ddaa0-1a76-4f19-9a1a-8c2a20263402"),
                    new DateTime(2024, 3, 19, 8, 10, 37, 246, DateTimeKind.Utc).AddTicks(7042)
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "OperationState", table: "TelegramModeratorMenuStates");

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 11, 17, 15, 52, 488, DateTimeKind.Utc).AddTicks(7930),
                    new Guid("26ecbd9a-727d-4de7-bbc6-45d060a27efa"),
                    new DateTime(2024, 3, 11, 17, 15, 52, 488, DateTimeKind.Utc).AddTicks(7930)
                }
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 11, 17, 15, 52, 488, DateTimeKind.Utc).AddTicks(7926),
                    new Guid("f9333d32-f13d-40ab-8310-ac751f6317bb"),
                    new DateTime(2024, 3, 11, 17, 15, 52, 488, DateTimeKind.Utc).AddTicks(7926)
                }
            );
        }
    }
}
