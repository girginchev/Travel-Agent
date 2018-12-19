using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Data.Migrations
{
    public partial class ReservationTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Reservations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReservationId",
                table: "AdditionalServices",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalServices_ReservationId",
                table: "AdditionalServices",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalServices_Reservations_ReservationId",
                table: "AdditionalServices",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalServices_Reservations_ReservationId",
                table: "AdditionalServices");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalServices_ReservationId",
                table: "AdditionalServices");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "AdditionalServices");
        }
    }
}
