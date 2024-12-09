using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangesCardEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Contributions");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Contributions",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(13)",
                oldMaxLength: 13);

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Contributions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollaboratorCard",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CollaboratorId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorCard", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_CollaboratorCard_AspNetUsers_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollaboratorCard_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_CardId",
                table: "Contributions",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions",
                column: "PersonInVulnerableSituationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorCard_CollaboratorId",
                table: "CollaboratorCard",
                column: "CollaboratorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Card_CardId",
                table: "Contributions",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Card_CardId",
                table: "Contributions");

            migrationBuilder.DropTable(
                name: "CollaboratorCard");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_CardId",
                table: "Contributions");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Contributions");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Contributions",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(21)",
                oldMaxLength: 21);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Contributions",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions",
                column: "PersonInVulnerableSituationId");
        }
    }
}
