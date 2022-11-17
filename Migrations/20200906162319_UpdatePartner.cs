using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitiesDraft1.Migrations
{
    public partial class UpdatePartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Supporters",
                table: "Supporters");

            migrationBuilder.RenameTable(
                name: "Supporters",
                newName: "Partners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partners",
                table: "Partners",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Partners",
                table: "Partners");

            migrationBuilder.RenameTable(
                name: "Partners",
                newName: "Supporters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supporters",
                table: "Supporters",
                column: "Id");
        }
    }
}
