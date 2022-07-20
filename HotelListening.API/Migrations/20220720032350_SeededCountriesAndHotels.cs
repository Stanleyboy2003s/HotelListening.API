using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListening.API.Migrations
{
    public partial class SeededCountriesAndHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "T_Country",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1L, "Jamaica", "JM" },
                    { 2L, "Jamaica", "JM" },
                    { 3L, "Cayman Island", "CI" },
                    { 4L, "Taiwan", "TW" }
                });

            migrationBuilder.InsertData(
                table: "T_Hotel",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1L, "Negril", 1L, "Sandals Resort and Spa", 4.5 },
                    { 2L, "George Town", 3L, "Comfort Suites", 4.2999999999999998 },
                    { 3L, "Nassua", 2L, "Grand Palldium", 4.0 },
                    { 4L, "Taichung", 4L, "Splendor Hotel-Taichung", 4.2000000000000002 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "T_Hotel",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "T_Hotel",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "T_Hotel",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "T_Hotel",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "T_Country",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "T_Country",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "T_Country",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "T_Country",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
