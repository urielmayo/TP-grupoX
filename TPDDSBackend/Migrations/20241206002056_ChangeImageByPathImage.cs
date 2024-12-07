using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageByPathImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contributions");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Contributions",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Contributions");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Contributions",
                type: "BYTEA",
                nullable: true);
        }
    }
}
