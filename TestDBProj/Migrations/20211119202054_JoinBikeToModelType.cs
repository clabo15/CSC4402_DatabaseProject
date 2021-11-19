using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestDBProj.Migrations
{
    public partial class JoinBikeToModelType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "serial_number",
                schema: "csc4402",
                table: "bike",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "bike_modeltypes",
                schema: "csc4402",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bike_id = table.Column<Guid>(type: "uuid", nullable: false),
                    model_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bike_modeltypes", x => x.id);
                    table.ForeignKey(
                        name: "fk_bike_modeltypes_bike_bike_id",
                        column: x => x.bike_id,
                        principalSchema: "csc4402",
                        principalTable: "bike",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_bike_modeltypes_modeltype_model_type_id",
                        column: x => x.model_type_id,
                        principalSchema: "csc4402",
                        principalTable: "modeltype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_bike_modeltypes_bike_id",
                schema: "csc4402",
                table: "bike_modeltypes",
                column: "bike_id");

            migrationBuilder.CreateIndex(
                name: "ix_bike_modeltypes_model_type_id",
                schema: "csc4402",
                table: "bike_modeltypes",
                column: "model_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bike_modeltypes",
                schema: "csc4402");

            migrationBuilder.AlterColumn<int>(
                name: "serial_number",
                schema: "csc4402",
                table: "bike",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
