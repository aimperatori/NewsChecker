using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsChecker.Migrations
{
    /// <inheritdoc />
    public partial class NewsType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journalist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journalist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newspapper",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newspapper", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PublishDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    NewspapperId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Edition_Newspapper_NewspapperId",
                        column: x => x.NewspapperId,
                        principalTable: "Newspapper",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Subtitle = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Resume = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    EditionId = table.Column<int>(type: "INTEGER", nullable: false),
                    NewsType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Edition_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Edition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalistNews",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "INTEGER", nullable: false),
                    JournalistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalistNews", x => new { x.JournalistId, x.NewsId });
                    table.ForeignKey(
                        name: "FK_JournalistNews_Journalist_JournalistId",
                        column: x => x.JournalistId,
                        principalTable: "Journalist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalistNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Edition_NewspapperId",
                table: "Edition",
                column: "NewspapperId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalistNews_NewsId",
                table: "JournalistNews",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_News_EditionId",
                table: "News",
                column: "EditionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalistNews");

            migrationBuilder.DropTable(
                name: "Journalist");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Edition");

            migrationBuilder.DropTable(
                name: "Newspapper");
        }
    }
}
