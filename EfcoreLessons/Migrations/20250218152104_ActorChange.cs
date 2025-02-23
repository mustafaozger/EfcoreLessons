using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcoreLessons.Migrations
{
    /// <inheritdoc />
    public partial class ActorChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(22)",
                maxLength: 22,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "ef",
                table: "Actors");
        }
    }
}
