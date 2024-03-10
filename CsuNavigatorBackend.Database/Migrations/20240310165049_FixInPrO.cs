using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsuNavigatorBackend.Database.Migrations
{
    /// <inheritdoc />
    public partial class FixInPrO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Edge_Point1Id",
                table: "Edge");

            migrationBuilder.DropIndex(
                name: "IX_Edge_Point2Id",
                table: "Edge");

            migrationBuilder.AddColumn<Guid>(
                name: "MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MarkerPoint_MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                column: "MapAsPointWithoutEdgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_Point1Id",
                table: "Edge",
                column: "Point1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_Point2Id",
                table: "Edge",
                column: "Point2Id");

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

            migrationBuilder.DropIndex(
                name: "IX_MarkerPoint_MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.DropIndex(
                name: "IX_Edge_Point1Id",
                table: "Edge");

            migrationBuilder.DropIndex(
                name: "IX_Edge_Point2Id",
                table: "Edge");

            migrationBuilder.DropColumn(
                name: "MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.CreateIndex(
                name: "IX_Edge_Point1Id",
                table: "Edge",
                column: "Point1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Edge_Point2Id",
                table: "Edge",
                column: "Point2Id",
                unique: true);
        }
    }
}
