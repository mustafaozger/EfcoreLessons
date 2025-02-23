using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcoreLessons.Migrations
{
    /// <inheritdoc />
    public partial class addUseAsyncSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ef",
                table: "Actors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
