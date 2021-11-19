using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDBProj.Migrations
{
    public partial class BikeUserInformationJoinAndBikeBikeRackLocationsJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bike_bikeracklocation",
                schema: "csc4402",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bike_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bike_rack_location_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bike_bikeracklocation", x => x.id);
                    table.ForeignKey(
                        name: "fk_bike_bikeracklocation_bike_bike_id",
                        column: x => x.bike_id,
                        principalSchema: "csc4402",
                        principalTable: "bike",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bike_bikeracklocation_bikeracklocation_bike_rack_location_id",
                        column: x => x.bike_rack_location_id,
                        principalSchema: "csc4402",
                        principalTable: "bikeracklocation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bike_userinformation",
                schema: "csc4402",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bike_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_information_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bike_userinformation", x => x.id);
                    table.ForeignKey(
                        name: "fk_bike_userinformation_bike_bike_id",
                        column: x => x.bike_id,
                        principalSchema: "csc4402",
                        principalTable: "bike",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bike_userinformation_userinformation_user_information_id",
                        column: x => x.user_information_id,
                        principalSchema: "csc4402",
                        principalTable: "userinformation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bike_bikeracklocation_bike_id",
                schema: "csc4402",
                table: "bike_bikeracklocation",
                column: "bike_id");

            migrationBuilder.CreateIndex(
                name: "ix_bike_bikeracklocation_bike_rack_location_id",
                schema: "csc4402",
                table: "bike_bikeracklocation",
                column: "bike_rack_location_id");

            migrationBuilder.CreateIndex(
                name: "ix_bike_userinformation_bike_id",
                schema: "csc4402",
                table: "bike_userinformation",
                column: "bike_id");

            migrationBuilder.CreateIndex(
                name: "ix_bike_userinformation_user_information_id",
                schema: "csc4402",
                table: "bike_userinformation",
                column: "user_information_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bike_bikeracklocation",
                schema: "csc4402");

            migrationBuilder.DropTable(
                name: "bike_userinformation",
                schema: "csc4402");
        }
    }
}
