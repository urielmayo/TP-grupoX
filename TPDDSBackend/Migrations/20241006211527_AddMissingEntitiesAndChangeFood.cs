using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingEntitiesAndChangeFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_AspNetUsers_CollaboratorId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_DeliveryReason_DeliveryReasonId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Fridge_DestinationFridgeId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Fridge_FridgeId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Fridge_OriginFridgeId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Transactions_FoodId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Contribution_DeliveryId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Transactions_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituation_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituation");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_FoodState_StateId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Fridge_FridgeId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Fridge_FridgeId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_PersonInVulnerableSituation_DoneeId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_DoneeId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInVulnerableSituation",
                table: "PersonInVulnerableSituation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryReason",
                table: "DeliveryReason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution");

            migrationBuilder.DropColumn(
                name: "DoneeId",
                table: "Transactions");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Food");

            migrationBuilder.RenameTable(
                name: "PersonInVulnerableSituation",
                newName: "PersonInVulnerableSituations");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "DocumentTypes");

            migrationBuilder.RenameTable(
                name: "DeliveryReason",
                newName: "DeliveryReasons");

            migrationBuilder.RenameTable(
                name: "Contribution",
                newName: "Contributions");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_StateId",
                table: "Food",
                newName: "IX_Food_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FridgeId1",
                table: "Food",
                newName: "IX_Food_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FridgeId",
                table: "Food",
                newName: "IX_Food_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInVulnerableSituation_DocumentTypeId",
                table: "PersonInVulnerableSituations",
                newName: "IX_PersonInVulnerableSituations_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_OriginFridgeId",
                table: "Contributions",
                newName: "IX_Contributions_OriginFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_FridgeId",
                table: "Contributions",
                newName: "IX_Contributions_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_FoodId",
                table: "Contributions",
                newName: "IX_Contributions_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_DestinationFridgeId",
                table: "Contributions",
                newName: "IX_Contributions_DestinationFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_DeliveryReasonId",
                table: "Contributions",
                newName: "IX_Contributions_DeliveryReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Contribution_CollaboratorId",
                table: "Contributions",
                newName: "IX_Contributions_CollaboratorId");

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

            migrationBuilder.AddColumn<int>(
                name: "DoneeId",
                table: "Contributions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInVulnerableSituations",
                table: "PersonInVulnerableSituations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryReasons",
                table: "DeliveryReasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contributions_DoneeId",
                table: "Contributions",
                column: "DoneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_AspNetUsers_CollaboratorId",
                table: "Contributions",
                column: "CollaboratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_DeliveryReasons_DeliveryReasonId",
                table: "Contributions",
                column: "DeliveryReasonId",
                principalTable: "DeliveryReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Food_FoodId",
                table: "Contributions",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Fridge_DestinationFridgeId",
                table: "Contributions",
                column: "DestinationFridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Fridge_FridgeId",
                table: "Contributions",
                column: "FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_Fridge_OriginFridgeId",
                table: "Contributions",
                column: "OriginFridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contributions_PersonInVulnerableSituations_DoneeId",
                table: "Contributions",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituations",
                principalColumn: "Id");

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
                name: "FK_FoodXDelivery_Contributions_DeliveryId",
                table: "FoodXDelivery",
                column: "DeliveryId",
                principalTable: "Contributions",
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
                name: "FK_Contributions_AspNetUsers_CollaboratorId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_DeliveryReasons_DeliveryReasonId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Food_FoodId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Fridge_DestinationFridgeId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Fridge_FridgeId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_Fridge_OriginFridgeId",
                table: "Contributions");

            migrationBuilder.DropForeignKey(
                name: "FK_Contributions_PersonInVulnerableSituations_DoneeId",
                table: "Contributions");

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
                name: "FK_FoodXDelivery_Contributions_DeliveryId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Food_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInVulnerableSituations_DocumentTypes_DocumentTypeId",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInVulnerableSituations",
                table: "PersonInVulnerableSituations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentTypes",
                table: "DocumentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryReasons",
                table: "DeliveryReasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contributions",
                table: "Contributions");

            migrationBuilder.DropIndex(
                name: "IX_Contributions_DoneeId",
                table: "Contributions");

            migrationBuilder.DropColumn(
                name: "DoneeId",
                table: "Contributions");

            migrationBuilder.RenameTable(
                name: "PersonInVulnerableSituations",
                newName: "PersonInVulnerableSituation");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "DocumentTypes",
                newName: "DocumentType");

            migrationBuilder.RenameTable(
                name: "DeliveryReasons",
                newName: "DeliveryReason");

            migrationBuilder.RenameTable(
                name: "Contributions",
                newName: "Contribution");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInVulnerableSituations_DocumentTypeId",
                table: "PersonInVulnerableSituation",
                newName: "IX_PersonInVulnerableSituation_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_StateId",
                table: "Transactions",
                newName: "IX_Transactions_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Food_FridgeId1",
                table: "Transactions",
                newName: "IX_Transactions_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Food_FridgeId",
                table: "Transactions",
                newName: "IX_Transactions_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_OriginFridgeId",
                table: "Contribution",
                newName: "IX_Contribution_OriginFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_FridgeId",
                table: "Contribution",
                newName: "IX_Contribution_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_FoodId",
                table: "Contribution",
                newName: "IX_Contribution_FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_DestinationFridgeId",
                table: "Contribution",
                newName: "IX_Contribution_DestinationFridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_DeliveryReasonId",
                table: "Contribution",
                newName: "IX_Contribution_DeliveryReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Contributions_CollaboratorId",
                table: "Contribution",
                newName: "IX_Contribution_CollaboratorId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "PersonInVulnerableSituation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentTypeId",
                table: "PersonInVulnerableSituation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoneeId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInVulnerableSituation",
                table: "PersonInVulnerableSituation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryReason",
                table: "DeliveryReason",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contribution",
                table: "Contribution",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DoneeId",
                table: "Transactions",
                column: "DoneeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_AspNetUsers_CollaboratorId",
                table: "Contribution",
                column: "CollaboratorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_DeliveryReason_DeliveryReasonId",
                table: "Contribution",
                column: "DeliveryReasonId",
                principalTable: "DeliveryReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Fridge_DestinationFridgeId",
                table: "Contribution",
                column: "DestinationFridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Fridge_FridgeId",
                table: "Contribution",
                column: "FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Fridge_OriginFridgeId",
                table: "Contribution",
                column: "OriginFridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contribution_Transactions_FoodId",
                table: "Contribution",
                column: "FoodId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodXDelivery_Contribution_DeliveryId",
                table: "FoodXDelivery",
                column: "DeliveryId",
                principalTable: "Contribution",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodXDelivery_Transactions_FoodId",
                table: "FoodXDelivery",
                column: "FoodId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInVulnerableSituation_DocumentType_DocumentTypeId",
                table: "PersonInVulnerableSituation",
                column: "DocumentTypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_FoodState_StateId",
                table: "Transactions",
                column: "StateId",
                principalTable: "FoodState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Fridge_FridgeId",
                table: "Transactions",
                column: "FridgeId",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Fridge_FridgeId1",
                table: "Transactions",
                column: "FridgeId1",
                principalTable: "Fridge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_PersonInVulnerableSituation_DoneeId",
                table: "Transactions",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
