using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthenticator.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandocustomidentityuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "Birthday", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a73e31f6-8949-432c-92a9-2761f0e85cf3", "AQAAAAIAAYagAAAAEMORdmQjCU6qTL3zMXU6++NysXOTtGebym+eg5ZqESaoneaxjFVOef6730YOwhQlqQ==", "c7ec759b-1caf-456e-94a4-80b0f8dfd199" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f22b683-9ff0-45d6-940a-33c344291788", "AQAAAAIAAYagAAAAEDza+798GTWxZ2fh7sMs12hnery4r9lwBQW6hxYluGhrGAzVWW4b4mp2wGItYPAmrg==", "92b9737c-c8a4-4ff1-b742-8b460e2b24ac" });
        }
    }
}
