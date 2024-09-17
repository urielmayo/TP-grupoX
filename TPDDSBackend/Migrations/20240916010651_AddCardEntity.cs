using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCardEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PersonInVulnerableSituation_DoneeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituation_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInVulnerableSituation",
                table: "PersonInVulnerableSituation");

            migrationBuilder.DropColumn(
                name: "RegistratedAt",
                table: "PersonInVulnerableSituation");

            migrationBuilder.RenameTable(
                name: "PersonInVulnerableSituation",
                newName: "PersonInVulnerableSituations");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInVulnerableSituation_DocumentTypeId",
                table: "PersonInVulnerableSituations",
                newName: "IX_PersonInVulnerableSituations_DocumentTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Contribution",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInVulnerableSituationId",
                table: "Contribution",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInVulnerableSituations",
                table: "PersonInVulnerableSituations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contribution_PersonInVulnerableSituationId",
                table: "Contribution",
                column: "PersonInVulnerableSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_PersonInVulnerableSituations_PersonInVulnerabl~",
                table: "Contribution",
                column: "PersonInVulnerableSituationId",
                principalTable: "PersonInVulnerableSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PersonInVulnerableSituations_DoneeId",
                table: "Foods",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituations",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_PersonInVulnerableSituations_PersonInVulnerabl~",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PersonInVulnerableSituations_DoneeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropIndex(
                name: "IX_Contribution_PersonInVulnerableSituationId",
                table: "Contribution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInVulnerableSituations",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Contribution");

            migrationBuilder.DropColumn(
                name: "PersonInVulnerableSituationId",
                table: "Contribution");

            migrationBuilder.RenameTable(
                name: "PersonInVulnerableSituations",
                newName: "PersonInVulnerableSituation");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInVulnerableSituations_DocumentTypeId",
                table: "PersonInVulnerableSituation",
                newName: "IX_PersonInVulnerableSituation_DocumentTypeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistratedAt",
                table: "PersonInVulnerableSituation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInVulnerableSituation",
                table: "PersonInVulnerableSituation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_PersonInVulnerableSituation_DoneeId",
                table: "Foods",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInVulnerableSituation_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituation",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
