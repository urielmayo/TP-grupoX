using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFridgeOpening : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeOwner_FridgeId",
                table: "Contributions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FridgeOpenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FridgeId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    OpeningFor = table.Column<int>(type: "integer", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeOpenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeOpenings_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeOpenings_Fridge_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_FridgeOwner_FridgeId",
                table: "Contributions",
                column: "FridgeOwner_FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeOpenings_CardId",
                table: "FridgeOpenings",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeOpenings_FridgeId",
                table: "FridgeOpenings",
                column: "FridgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Fridge_FridgeOwner_FridgeId",
                table: "Contributions",
                column: "FridgeOwner_FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Fridge_FridgeOwner_FridgeId",
                table: "Contributions");

            migrationBuilder.DropTable(
                name: "FridgeOpenings");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_FridgeOwner_FridgeId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "FridgeOwner_FridgeId",
                table: "Contributions");
        }
    }
}
