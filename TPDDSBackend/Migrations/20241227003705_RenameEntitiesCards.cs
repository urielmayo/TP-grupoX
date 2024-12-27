using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameEntitiesCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorCard_AspNetUsers_CollaboratorId",
                table: "CollaboratorCard");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorCard_Card_CardId",
                table: "CollaboratorCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Card_CardId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeOpenings_Card_CardId",
                table: "FridgeOpenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorCard",
                table: "CollaboratorCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "CollaboratorCard",
                newName: "CollaboratorCards");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorCard_CollaboratorId",
                table: "CollaboratorCards",
                newName: "IX_CollaboratorCards_CollaboratorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorCards",
                table: "CollaboratorCards",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorCards_AspNetUsers_CollaboratorId",
                table: "CollaboratorCards",
                column: "CollaboratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorCards_Cards_CardId",
                table: "CollaboratorCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Cards_CardId",
                table: "Contributions",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeOpenings_Cards_CardId",
                table: "FridgeOpenings",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorCards_AspNetUsers_CollaboratorId",
                table: "CollaboratorCards");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorCards_Cards_CardId",
                table: "CollaboratorCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Cards_CardId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_FridgeOpenings_Cards_CardId",
                table: "FridgeOpenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollaboratorCards",
                table: "CollaboratorCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "CollaboratorCards",
                newName: "CollaboratorCard");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameIndex(
                name: "IX_CollaboratorCards_CollaboratorId",
                table: "CollaboratorCard",
                newName: "IX_CollaboratorCard_CollaboratorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollaboratorCard",
                table: "CollaboratorCard",
                column: "CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorCard_AspNetUsers_CollaboratorId",
                table: "CollaboratorCard",
                column: "CollaboratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorCard_Card_CardId",
                table: "CollaboratorCard",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Card_CardId",
                table: "Contributions",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FridgeOpenings_Card_CardId",
                table: "FridgeOpenings",
                column: "CardId",
                principalTable: "Card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
