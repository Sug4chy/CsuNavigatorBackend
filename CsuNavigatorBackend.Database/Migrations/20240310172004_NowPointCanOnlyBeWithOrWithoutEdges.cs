using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsuNavigatorBackend.Database.Migrations
{
    /// <inheritdoc />
    public partial class NowPointCanOnlyBeWithOrWithoutEdges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.AlterColumn<Guid>(
                name: "MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                column: "MapAsPointWithoutEdgeId",
                principalTable: "Map",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint");

            migrationBuilder.AlterColumn<Guid>(
                name: "MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MarkerPoint_Map_MapAsPointWithoutEdgeId",
                table: "MarkerPoint",
                column: "MapAsPointWithoutEdgeId",
                principalTable: "Map",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
