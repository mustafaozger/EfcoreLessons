using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcoreLessons.Migrations
{
    /// <inheritdoc />
    public partial class ActorChange4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(42)",
                maxLength: 42,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(42)",
                oldMaxLength: 42,
                oldNullable: true);
        }
    }
}
