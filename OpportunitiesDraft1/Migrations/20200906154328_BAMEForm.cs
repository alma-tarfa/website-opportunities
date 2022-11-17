using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitiesDraft1.Migrations
{
    public partial class BAMEForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "BAMEs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLink",
                table: "BAMEs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "BAMEs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "BAMEs");

            migrationBuilder.DropColumn(
                name: "InstagramLink",
                table: "BAMEs");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "BAMEs");
        }
    }
}
