using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TPDDSBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFridgeSubscriptionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationMedias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FridgeSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CollaboratorId = table.Column<string>(type: "text", nullable: false),
                    FridgeId = table.Column<int>(type: "integer", nullable: false),
                    AvailableFoodsQuantity = table.Column<int>(type: "integer", nullable: true),
                    FullFoodsQuantity = table.Column<int>(type: "integer", nullable: true),
                    IncidentSubscription = table.Column<bool>(type: "boolean", nullable: true),
                    CommunicationMediaId = table.Column<int>(type: "integer", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeSubscriptions_AspNetUsers_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeSubscriptions_CommunicationMedias_CommunicationMediaId",
                        column: x => x.CommunicationMediaId,
                        principalTable: "CommunicationMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeSubscriptions_Fridge_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CommunicationMediaId = table.Column<int>(type: "integer", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModificationAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionMessages_CommunicationMedias_CommunicationMedia~",
                        column: x => x.CommunicationMediaId,
                        principalTable: "CommunicationMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeSubscriptions_CollaboratorId",
                table: "FridgeSubscriptions",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeSubscriptions_CommunicationMediaId",
                table: "FridgeSubscriptions",
                column: "CommunicationMediaId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeSubscriptions_FridgeId",
                table: "FridgeSubscriptions",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionMessages_CommunicationMediaId",
                table: "SubscriptionMessages",
                column: "CommunicationMediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeSubscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionMessages");

            migrationBuilder.DropTable(
                name: "CommunicationMedias");
        }
    }
}
