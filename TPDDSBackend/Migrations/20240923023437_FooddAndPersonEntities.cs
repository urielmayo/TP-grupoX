using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class FooddAndPersonEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Foods_FoodId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_FoodState_StateId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Fridge_FridgeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Fridge_FridgeId1",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_PersonInVulnerableSituations_DoneeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Foods_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "DocumentTypes");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Contribution",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_StateId",
                table: "Food",
                newName: "IX_Food_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_FridgeId1",
                table: "Food",
                newName: "IX_Food_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_FridgeId",
                table: "Food",
                newName: "IX_Food_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DoneeId",
                table: "Food",
                newName: "IX_Food_DoneeId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "PersonInVulnerableSituations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "PersonInVulnerableSituations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Food_FoodId",
                table: "Contribution",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_FoodState_StateId",
                table: "Food",
                column: "StateId",
                principalTable: "FoodState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Fridge_FridgeId",
                table: "Food",
                column: "FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Fridge_FridgeId1",
                table: "Food",
                column: "FridgeId1",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Food_PersonInVulnerableSituations_DoneeId",
                table: "Food",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodXDelivery_Food_FoodId",
                table: "FoodXDelivery",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentTypes_DocumentTypeId",
                table: "PersonInVulnerableSituations",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Food_FoodId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_FoodState_StateId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Fridge_FridgeId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Fridge_FridgeId1",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_PersonInVulnerableSituations_DoneeId",
                table: "Food");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Food_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentTypes_DocumentTypeId",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.RenameTable(
                name: "DocumentTypes",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Contribution",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Food_StateId",
                table: "Foods",
                newName: "IX_Foods_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_FridgeId1",
                table: "Foods",
                newName: "IX_Foods_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Food_FridgeId",
                table: "Foods",
                newName: "IX_Foods_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_DoneeId",
                table: "Foods",
                newName: "IX_Foods_DoneeId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "PersonInVulnerableSituations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "PersonInVulnerableSituations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Foods_FoodId",
                table: "Contribution",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_FoodState_StateId",
                table: "Foods",
                column: "StateId",
                principalTable: "FoodState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Fridge_FridgeId",
                table: "Foods",
                column: "FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Fridge_FridgeId1",
                table: "Foods",
                column: "FridgeId1",
                principalTable: "Fridge",
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
                name: "FK_FoodXDelivery_Foods_FoodId",
                table: "FoodXDelivery",
                column: "FoodId",
                principalTable: "Foods",
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
    }
}
