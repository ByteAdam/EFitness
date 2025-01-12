using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFitness.Migrations
{
    /// <inheritdoc />
    public partial class FixActivityColumnName : Migration
    {
        /// <inheritdoc />
       protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.RenameColumn(
        name: "ActivityId", // Current column name in the database
        table: "Reservations",
        newName: "Activity1Id" // Correct column name to match your code
    );
}


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.RenameColumn(
        name: "Activity1Id", // Correct column name
        table: "Reservations",
        newName: "ActivityId" // Original column name
    );
}

    }
}
