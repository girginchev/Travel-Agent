using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgent.Data.Migrations
{
    public partial class ReservationIsFinalized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinalized",
                table: "Reservations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinalized",
                table: "Reservations");
        }
    }
}
