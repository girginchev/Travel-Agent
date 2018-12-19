using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Data.Migrations
{
    public partial class DestinationType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Tours_TourId",
                table: "Trips");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationType",
                table: "Tours",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationType",
                table: "Holidays",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Tours_TourId",
                table: "Trips",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Tours_TourId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "DestinationType",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "DestinationType",
                table: "Holidays");

            migrationBuilder.AlterColumn<int>(
                name: "TourId",
                table: "Trips",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Tours_TourId",
                table: "Trips",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
