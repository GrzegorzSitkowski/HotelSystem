using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelSystem.Persistance.Migrations
{
    public partial class DeletedAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Amenities_AmenitiesId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_AmenitiesId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AmenitiesId",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirConditioning = table.Column<bool>(type: "bit", nullable: false),
                    CityView = table.Column<bool>(type: "bit", nullable: false),
                    CoffeeMachine = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dishwasher = table.Column<bool>(type: "bit", nullable: false),
                    EntireApartment = table.Column<bool>(type: "bit", nullable: false),
                    Inactivated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InactivatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patio = table.Column<bool>(type: "bit", nullable: false),
                    PrivateBathroom = table.Column<bool>(type: "bit", nullable: false),
                    PrivateKitchenette = table.Column<bool>(type: "bit", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Tv = table.Column<bool>(type: "bit", nullable: false),
                    WiFi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "AirConditioning", "CityView", "CoffeeMachine", "Created", "CreatedBy", "Dishwasher", "EntireApartment", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "Patio", "PrivateBathroom", "PrivateKitchenette", "StatusId", "Tv", "WiFi" },
                values: new object[] { 1, true, false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, true, null, null, null, null, false, true, true, 0, true, true });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AmenitiesId",
                table: "Rooms",
                column: "AmenitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Amenities_AmenitiesId",
                table: "Rooms",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
