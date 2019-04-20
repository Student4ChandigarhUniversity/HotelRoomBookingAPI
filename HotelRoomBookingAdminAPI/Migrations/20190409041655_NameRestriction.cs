using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelRoomBookingAdminAPI.Migrations
{
    public partial class NameRestriction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HotelTypeName",
                table: "HotelTypes",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomType",
                table: "HotelRooms",
                unicode: false,
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HotelTypeName",
                table: "HotelTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HotelName",
                table: "Hotels",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoomType",
                table: "HotelRooms",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 5,
                oldNullable: true);
        }
    }
}
