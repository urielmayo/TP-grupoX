using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddBenefitAndBenefitExchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Contributions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contributions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Contributions",
                type: "BYTEA",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequiredPoints",
                table: "Contributions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BenefitExchanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BenefitId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitExchanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenefitExchanges_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenefitExchanges_Contributions_BenefitId",
                        column: x => x.BenefitId,
                        principalTable: "Contributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenefitExchanges_BenefitId",
                table: "BenefitExchanges",
                column: "BenefitId");

            migrationBuilder.CreateIndex(
                name: "IX_BenefitExchanges_UserId",
                table: "BenefitExchanges",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitExchanges");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "RequiredPoints",
                table: "Contributions");
        }
    }
}
