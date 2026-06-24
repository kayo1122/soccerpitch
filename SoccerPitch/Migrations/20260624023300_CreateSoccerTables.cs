using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoccerPitch.Migrations
{
    /// <inheritdoc />
    public partial class CreateSoccerTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coach",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Formation",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "JerseyNumber",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Players",
                newName: "PreferredPosition");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Players",
                newName: "TeamName");

            migrationBuilder.AddColumn<double>(
                name: "OverallRating",
                table: "Players",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "Players",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    FormationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.FormationId);
                });

            migrationBuilder.CreateTable(
                name: "FormationSlot",
                columns: table => new
                {
                    FormationSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xPosition = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    yPosition = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationSlot", x => x.FormationSlotId);
                });

            migrationBuilder.CreateTable(
                name: "FormationFormationSlot",
                columns: table => new
                {
                    FormationId = table.Column<int>(type: "int", nullable: false),
                    FormationSlotsFormationSlotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormationFormationSlot", x => new { x.FormationId, x.FormationSlotsFormationSlotId });
                    table.ForeignKey(
                        name: "FK_FormationFormationSlot_FormationSlot_FormationSlotsFormationSlotId",
                        column: x => x.FormationSlotsFormationSlotId,
                        principalTable: "FormationSlot",
                        principalColumn: "FormationSlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormationFormationSlot_Formation_FormationId",
                        column: x => x.FormationId,
                        principalTable: "Formation",
                        principalColumn: "FormationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamLineUpSlot",
                columns: table => new
                {
                    TeamLineUpSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FormationSlotId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLineUpSlot", x => x.TeamLineUpSlotId);
                    table.ForeignKey(
                        name: "FK_TeamLineUpSlot_FormationSlot_FormationSlotId",
                        column: x => x.FormationSlotId,
                        principalTable: "FormationSlot",
                        principalColumn: "FormationSlotId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLineUpSlot_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId");
                    table.ForeignKey(
                        name: "FK_TeamLineUpSlot_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FormationFormationSlot_FormationSlotsFormationSlotId",
                table: "FormationFormationSlot",
                column: "FormationSlotsFormationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLineUpSlot_FormationSlotId",
                table: "TeamLineUpSlot",
                column: "FormationSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLineUpSlot_PlayerId",
                table: "TeamLineUpSlot",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLineUpSlot_TeamId",
                table: "TeamLineUpSlot",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "FormationFormationSlot");

            migrationBuilder.DropTable(
                name: "TeamLineUpSlot");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "FormationSlot");

            migrationBuilder.DropIndex(
                name: "IX_Players_TeamId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Players",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PreferredPosition",
                table: "Players",
                newName: "Position");

            migrationBuilder.AddColumn<string>(
                name: "Coach",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Formation",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JerseyNumber",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
