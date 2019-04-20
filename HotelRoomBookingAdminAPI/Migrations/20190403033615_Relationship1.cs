using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomBookingAdminAPI.Migrations
{
    public partial class Relationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Payments",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                newName: "IX_Payments_BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Bookings_BookingId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Payments",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_BookingId",
                table: "Payments",
                newName: "IX_Payments_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customers_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
