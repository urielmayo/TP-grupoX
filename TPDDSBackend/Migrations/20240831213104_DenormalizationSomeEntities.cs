using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class DenormalizationSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Category_CategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OrganizationType_OrganizationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Contribution_Transactions_FoodId",
                table: "Contribution");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Transactions_FoodId",
                table: "FoodXDelivery");

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

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "MeanOfContact");

            migrationBuilder.DropTable(
                name: "OrganizationType");

            migrationBuilder.DropTable(
                name: "ContactMediaType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizationTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationTypeId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "Foods");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_StateId",
                table: "Foods",
                newName: "IX_Foods_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FridgeId1",
                table: "Foods",
                newName: "IX_Foods_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FridgeId",
                table: "Foods",
                newName: "IX_Foods_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_DoneeId",
                table: "Foods",
                newName: "IX_Foods_DoneeId");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationType",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
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
                name: "FK_Foods_PersonInVulnerableSituation_DoneeId",
                table: "Foods",
                column: "DoneeId",
                principalTable: "PersonInVulnerableSituation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodXDelivery_Foods_FoodId",
                table: "FoodXDelivery",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Foods_PersonInVulnerableSituation_DoneeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodXDelivery_Foods_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrganizationType",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Transactions");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_StateId",
                table: "Transactions",
                newName: "IX_Transactions_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_FridgeId1",
                table: "Transactions",
                newName: "IX_Transactions_FridgeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_FridgeId",
                table: "Transactions",
                newName: "IX_Transactions_FridgeId");

            migrationBuilder.RenameIndex(
                name: "IX_Foods_DoneeId",
                table: "Transactions",
                newName: "IX_Transactions_DoneeId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationTypeId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMediaType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMediaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeanOfContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollaboratorId = table.Column<string>(type: "text", nullable: false),
                    ContactMediaTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeanOfContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeanOfContact_AspNetUsers_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeanOfContact_ContactMediaType_ContactMediaTypeId",
                        column: x => x.ContactMediaTypeId,
                        principalTable: "ContactMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CategoryId",
                table: "AspNetUsers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizationTypeId",
                table: "AspNetUsers",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MeanOfContact_CollaboratorId",
                table: "MeanOfContact",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_MeanOfContact_ContactMediaTypeId",
                table: "MeanOfContact",
                column: "ContactMediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Category_CategoryId",
                table: "AspNetUsers",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OrganizationType_OrganizationTypeId",
                table: "AspNetUsers",
                column: "OrganizationTypeId",
                principalTable: "OrganizationType",
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
                name: "FK_FoodXDelivery_Transactions_FoodId",
                table: "FoodXDelivery",
                column: "FoodId",
                principalTable: "Transactions",
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
