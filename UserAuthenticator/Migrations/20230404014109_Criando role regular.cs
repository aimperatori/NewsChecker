using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthenticator.Migrations
{
    /// <inheritdoc />
    public partial class Criandoroleregular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999997, null, "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f22b683-9ff0-45d6-940a-33c344291788", "AQAAAAIAAYagAAAAEDza+798GTWxZ2fh7sMs12hnery4r9lwBQW6hxYluGhrGAzVWW4b4mp2wGItYPAmrg==", "92b9737c-c8a4-4ff1-b742-8b460e2b24ac" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999997);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c35e2d54-581f-4ccc-9285-326d681723db", "AQAAAAIAAYagAAAAEMAaA1r2x2Ovirbrn5Pq/X21JnN2ti4SmEWNs2AS/RYjkeR+IwFnF+D9hw3Ic/3GsQ==", "ed3c12f4-194c-496a-9c21-4480a87d0b09" });
        }
    }
}
