using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddCompletedToTechnicianVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "TechnicianVisits",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "TechnicianVisits");
        }
    }
}
