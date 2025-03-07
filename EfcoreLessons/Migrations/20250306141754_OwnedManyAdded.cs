using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcoreLessons.Migrations
{
    /// <inheritdoc />
    public partial class OwnedManyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Release_Amount",
                schema: "ef",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Release_Date",
                schema: "ef",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MovieReleaseCinemas",
                schema: "ef",
                columns: table => new
                {
                    MovieEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AdresLine1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AdresLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieReleaseCinemas", x => new { x.MovieEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_MovieReleaseCinemas_Movies_MovieEntityId",
                        column: x => x.MovieEntityId,
                        principalSchema: "ef",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieReleaseCinemas",
                schema: "ef");

            migrationBuilder.DropColumn(
                name: "Release_Amount",
                schema: "ef",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Release_Date",
                schema: "ef",
                table: "Movies");
        }
    }
}
