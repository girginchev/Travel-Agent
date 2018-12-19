using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Data.Migrations
{
    public partial class ReservationTourTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TourTitle",
                table: "Reservations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TourTitle",
                table: "Reservations");
        }
    }
}
