using Microsoft.EntityFrameworkCore.Migrations;

namespace DesignPatternSamples.Infra.Repository.Migrations
{
    public partial class PalestraGitHub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "Palestra",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "Palestra");
        }
    }
}
