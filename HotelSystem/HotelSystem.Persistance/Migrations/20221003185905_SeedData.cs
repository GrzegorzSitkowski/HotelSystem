using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelSystem.Persistance.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "CityView", "CoffeeMachine", "Created", "CreatedBy", "Dishwasher", "EntireApartment", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Patio", "PrivateBathroom", "PrivateKitchenette", "StatusId", "Tv", "WiFi" },
                values: new object[] { 1, true, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, null, null, null, null, false, true, true, 0, true, true });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AmenitiesId", "Avability", "Capacity", "Created", "CreatedBy", "Description", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Name", "Price", "StatusId", "UserId" },
                values: new object[] { 1, null, false, 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Room for two.", null, null, null, null, null, 450, 0, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Mail", "Modified", "ModifiedBy", "Password", "StatusId", "Type", "UserName_FirstName", "UserName_LastName" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "example@mail.com", null, null, "password", 0, "Customer", null, "Sitkowski" });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CheckIn", "CheckOut", "Created", "CreatedBy", "Inactivated", "InactivatedBy", "Mail", "Modified", "ModifiedBy", "Payment", "Price", "RoomId", "StatusId", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "example@mail.com", null, null, true, 0, 1, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
