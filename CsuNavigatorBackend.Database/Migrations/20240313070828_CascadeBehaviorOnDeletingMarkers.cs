using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CsuNavigatorBackend.Database.Migrations
{
    /// <inheritdoc />
    public partial class CascadeBehaviorOnDeletingMarkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MarkerPoint");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Map");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Edge");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Profile",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Organization",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MarkerPoint",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Map",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Image",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Edge",
                type: "timestamp with time zone",
                nullable: true);
        }
    }
}
