using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SquaresAPI.Migrations
{
    public partial class lists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointPointList",
                columns: table => new
                {
                    PointListsId = table.Column<int>(type: "int", nullable: false),
                    PointsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointPointList", x => new { x.PointListsId, x.PointsId });
                    table.ForeignKey(
                        name: "FK_PointPointList_PointList_PointListsId",
                        column: x => x.PointListsId,
                        principalTable: "PointList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PointPointList_Points_PointsId",
                        column: x => x.PointsId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointPointList_PointsId",
                table: "PointPointList",
                column: "PointsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointPointList");

            migrationBuilder.DropTable(
                name: "PointList");
        }
    }
}
