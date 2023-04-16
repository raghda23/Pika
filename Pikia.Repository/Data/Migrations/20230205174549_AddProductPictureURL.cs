using Microsoft.EntityFrameworkCore.Migrations;

namespace Pikia.Repository.Data.Migrations
{
    public partial class AddProductPictureURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureURL",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureURL",
                table: "Products");
        }
    }
}
