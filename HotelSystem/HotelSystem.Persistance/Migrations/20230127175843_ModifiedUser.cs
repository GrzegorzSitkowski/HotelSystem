using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelSystem.Persistance.Migrations
{
    public partial class ModifiedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName_LastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "UserName_FirstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumner",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumner",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "UserName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "UserName_FirstName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserName_FirstName", "UserName_LastName" },
                values: new object[] { "Grzegorz", "Sitkowski" });
        }
    }
}
