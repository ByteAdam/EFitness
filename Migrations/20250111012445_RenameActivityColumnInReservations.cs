using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFitness.Migrations
{
    /// <inheritdoc />
    public partial class RenameActivityColumnInReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.RenameColumn(
        name: "Activity1Id", // Current column name in the database
        table: "Reservations",
        newName: "ActivityId" // Desired column name in the database
    );
}


        /// <inheritdoc />
       protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.RenameColumn(
        name: "ActivityId", // Desired column name
        table: "Reservations",
        newName: "Activity1Id" // Original column name
    );
}
    }
}
