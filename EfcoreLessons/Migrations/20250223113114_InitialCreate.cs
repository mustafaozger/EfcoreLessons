using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfcoreLessons.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_DirectorID",
                schema: "ef",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "ef",
                table: " Directors",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(42)",
                oldMaxLength: 42,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "ef",
                table: " Directors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ef",
                table: " Directors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreID",
                schema: "ef",
                table: "Movies",
                column: "GenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreID",
                schema: "ef",
                table: "Movies",
                column: "GenreID",
                principalSchema: "ef",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreID",
                schema: "ef",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreID",
                schema: "ef",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ef",
                table: " Directors",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(42)",
                maxLength: 42,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "ef",
                table: " Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "ef",
                table: " Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_DirectorID",
                schema: "ef",
                table: "Movies",
                column: "DirectorID",
                principalSchema: "ef",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
