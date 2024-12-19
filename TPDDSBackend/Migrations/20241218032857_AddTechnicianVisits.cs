using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnicianVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodXDelivery",
                table: "FoodXDelivery");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FoodXDelivery",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodXDelivery",
                table: "FoodXDelivery",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TechnicianVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TechnicianId = table.Column<int>(type: "integer", nullable: false),
                    FridgeId = table.Column<int>(type: "integer", nullable: false),
                    FridgeRepaired = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicianVisits_Fridge_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TechnicianVisits_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitXTechnicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TechnicianId = table.Column<int>(type: "integer", nullable: false),
                    TechnicianVisitId = table.Column<int>(type: "integer", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitXTechnicians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitXTechnicians_TechnicianVisits_TechnicianVisitId",
                        column: x => x.TechnicianVisitId,
                        principalTable: "TechnicianVisits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitXTechnicians_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodXDelivery_FoodId",
                table: "FoodXDelivery",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianVisits_FridgeId",
                table: "TechnicianVisits",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianVisits_TechnicianId",
                table: "TechnicianVisits",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitXTechnicians_TechnicianId",
                table: "VisitXTechnicians",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitXTechnicians_TechnicianVisitId",
                table: "VisitXTechnicians",
                column: "TechnicianVisitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitXTechnicians");

            migrationBuilder.DropTable(
                name: "TechnicianVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodXDelivery",
                table: "FoodXDelivery");

            migrationBuilder.DropIndex(
                name: "IX_FoodXDelivery_FoodId",
                table: "FoodXDelivery");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FoodXDelivery",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodXDelivery",
                table: "FoodXDelivery",
                columns: new[] { "FoodId", "DeliveryId" });
        }
    }
}
