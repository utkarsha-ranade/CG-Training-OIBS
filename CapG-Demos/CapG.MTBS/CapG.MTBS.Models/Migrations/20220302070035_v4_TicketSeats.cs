using Microsoft.EntityFrameworkCore.Migrations;

namespace CapG.MTBS.Models.Migrations
{
    public partial class v4_TicketSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfSeats",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfSeats",
                table: "Tickets");
        }
    }
}
