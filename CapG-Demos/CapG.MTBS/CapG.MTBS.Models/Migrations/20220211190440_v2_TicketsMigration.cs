using Microsoft.EntityFrameworkCore.Migrations;

namespace CapG.MTBS.Models.Migrations
{
    public partial class v2_TicketsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Tickets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Tickets");
        }
    }
}
