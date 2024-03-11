using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DessertsMakery.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelegramModeratorMenuStates",
                columns: table => new
                {
                    InternalId = table
                        .Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuState = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramModeratorMenuStates", x => x.InternalId);
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
                    TelegramModeratorMenuStateId = table.Column<long>(type: "INTEGER", nullable: true),
                    ExternalId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DATE('now')"),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramModerators", x => x.InternalId);
                    table.ForeignKey(
                        name: "FK_TelegramModerators_TelegramModeratorMenuStates_TelegramModeratorMenuStateId",
                        column: x => x.TelegramModeratorMenuStateId,
                        principalTable: "TelegramModeratorMenuStates",
                        principalColumn: "InternalId"
                    );
                }
            );

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

            migrationBuilder.CreateIndex(
                name: "IX_TelegramModeratorMenuStates_ExternalId",
                table: "TelegramModeratorMenuStates",
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
                name: "IX_TelegramModerators_TelegramModeratorMenuStateId",
                table: "TelegramModerators",
                column: "TelegramModeratorMenuStateId",
                unique: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TelegramModerators");

            migrationBuilder.DropTable(name: "TelegramModeratorMenuStates");

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 6, 11, 36, 17, 505, DateTimeKind.Utc).AddTicks(9924),
                    new Guid("baf0dd1d-d24d-42a1-a112-e2bb55f6eeae"),
                    new DateTime(2024, 3, 6, 11, 36, 17, 505, DateTimeKind.Utc).AddTicks(9924)
                }
            );

            migrationBuilder.UpdateData(
                table: "Measurings",
                keyColumn: "InternalId",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId", "ModifiedAt" },
                values: new object[]
                {
                    new DateTime(2024, 3, 6, 11, 36, 17, 505, DateTimeKind.Utc).AddTicks(9910),
                    new Guid("0685a1f7-c185-4045-b158-3ee72128d2cb"),
                    new DateTime(2024, 3, 6, 11, 36, 17, 505, DateTimeKind.Utc).AddTicks(9910)
                }
            );
        }
    }
}
