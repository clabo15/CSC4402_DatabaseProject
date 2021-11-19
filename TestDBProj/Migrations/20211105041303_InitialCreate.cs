using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDBProj.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "testdb");

            migrationBuilder.CreateTable(
                name: "bostonbikes",
                schema: "testdb",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    station_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    trips_ended = table.Column<int>(type: "integer", nullable: false),
                    trips_started = table.Column<int>(type: "integer", nullable: false),
                    trips_total = table.Column<int>(type: "integer", nullable: false),
                    fpct_started = table.Column<double>(type: "double precision", nullable: false),
                    fpct_ended = table.Column<double>(type: "double precision", nullable: false),
                    fpct_total = table.Column<double>(type: "double precision", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bostonbikes", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bostonbikes",
                schema: "testdb");
        }
    }
}
