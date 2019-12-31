using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Krola.Data.TimeTracking.Migrations
{
    public partial class AddedHeartbeatToSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Star",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Heartbeat",
                table: "Sessions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Sessions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Sessions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heartbeat",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Star",
                table: "Sessions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
