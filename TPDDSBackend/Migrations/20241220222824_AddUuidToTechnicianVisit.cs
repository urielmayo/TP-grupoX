using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddUuidToTechnicianVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UuidToComplete",
                table: "TechnicianVisits",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianVisits_UuidToComplete",
                table: "TechnicianVisits",
                column: "UuidToComplete",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TechnicianVisits_UuidToComplete",
                table: "TechnicianVisits");

            migrationBuilder.DropColumn(
                name: "UuidToComplete",
                table: "TechnicianVisits");
        }
    }
}
