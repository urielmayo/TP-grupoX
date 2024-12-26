using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageFridgeFailure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "FridgeIncidents");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "FridgeIncidents",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "FridgeIncidents");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "FridgeIncidents",
                type: "text",
                nullable: true);
        }
    }
}
