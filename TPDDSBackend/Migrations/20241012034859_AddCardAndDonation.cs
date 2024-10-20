using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCardAndDonation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistratedAt",
                table: "PersonInVulnerableSituations");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Contributions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInVulnerableSituationId",
                table: "Contributions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions",
                column: "PersonInVulnerableSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_PersonInVulnerableSituations_PersonInVulnerab~",
                table: "Contributions",
                column: "PersonInVulnerableSituationId",
                principalTable: "PersonInVulnerableSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_PersonInVulnerableSituations_PersonInVulnerab~",
                table: "Contributions");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_PersonInVulnerableSituationId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "PersonInVulnerableSituationId",
                table: "Contributions");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistratedAt",
                table: "PersonInVulnerableSituations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
