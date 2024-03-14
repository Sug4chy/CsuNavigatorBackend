using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsuNavigatorBackend.Database.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDeletingOnMaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.AddForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                column: "MapAsPointWithoutEdgeId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.AddForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                column: "MapAsPointWithoutEdgeId",
                principalTable: "Map",
                principalColumn: "Id");
        }
    }
}
