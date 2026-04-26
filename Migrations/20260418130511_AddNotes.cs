using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoteID",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_NoteID",
                table: "Meals",
                column: "NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Notes_NoteID",
                table: "Meals",
                column: "NoteID",
                principalTable: "Notes",
                principalColumn: "NoteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Notes_NoteID",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Meals_NoteID",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "NoteID",
                table: "Meals");
        }
    }
}
