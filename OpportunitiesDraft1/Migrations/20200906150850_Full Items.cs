using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitiesDraft1.Migrations
{
    public partial class FullItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "BAMEs");

            migrationBuilder.AddColumn<bool>(
                name: "JobOpportunities",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Supporters",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WorkPlacement",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WorkshopTraining",
                table: "Supporters",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JobOpportunities",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Opportunists",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WorkPlacement",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WorkshopTraining",
                table: "Opportunists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BAMEs",
                maxLength: 600,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropColumn(
                name: "JobOpportunities",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "WorkPlacement",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "WorkshopTraining",
                table: "Supporters");

            migrationBuilder.DropColumn(
                name: "JobOpportunities",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "WorkPlacement",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "WorkshopTraining",
                table: "Opportunists");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BAMEs");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "BAMEs",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                defaultValue: "");
        }
    }
}
