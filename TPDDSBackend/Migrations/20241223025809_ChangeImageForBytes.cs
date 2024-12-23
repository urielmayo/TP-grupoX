using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageForBytes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "TechnicianVisits");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "TechnicianVisits",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TechnicianVisits");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "TechnicianVisits",
                type: "text",
                nullable: true);
        }
    }
}
