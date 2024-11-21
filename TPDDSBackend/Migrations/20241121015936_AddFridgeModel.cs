using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFridgeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FridgeModelId",
                table: "Fridge",
                type: "integer",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<float>(
                name: "LastTemperature",
                table: "Fridge",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "FridgeModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MaxTemperature = table.Column<float>(type: "real", nullable: false),
                    MinTemperature = table.Column<float>(type: "real", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "CreatedAt", "LastModificationAt", "MaxTemperature", "MinTemperature", "Name" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10f, -5f, "DefaultModel" });

            migrationBuilder.CreateIndex(
                name: "IX_Fridge_FridgeModelId",
                table: "Fridge",
                column: "FridgeModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fridge_FridgeModels_FridgeModelId",
                table: "Fridge",
                column: "FridgeModelId",
                principalTable: "FridgeModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fridge_FridgeModels_FridgeModelId",
                table: "Fridge");

            migrationBuilder.DropTable(
                name: "FridgeModels");

            migrationBuilder.DropIndex(
                name: "IX_Fridge_FridgeModelId",
                table: "Fridge");

            migrationBuilder.DropColumn(
                name: "FridgeModelId",
                table: "Fridge");

            migrationBuilder.DropColumn(
                name: "LastTemperature",
                table: "Fridge");
        }
    }
}
