using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitiesDraft1.Migrations
{
    public partial class AddedInterestFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllyShip",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessOpportunities",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mentorship",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Partnership",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sponsorship",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartUp",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllyShip",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessOpportunities",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Mentorship",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Partnership",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sponsorship",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartUp",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllyShip",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "BusinessOpportunities",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "Mentorship",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "Partnership",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "Sponsorship",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "StartUp",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "AllyShip",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "BusinessOpportunities",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "Mentorship",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "Partnership",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "Sponsorship",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "StartUp",
                table: "Opportunists");
        }
    }
}
