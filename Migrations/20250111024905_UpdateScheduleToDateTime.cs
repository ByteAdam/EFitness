using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFitness.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScheduleToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Activities_Activity1Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Activity1Id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Activity1Id",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ActivityId",
                table: "Reservations",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Activities_ActivityId",
                table: "Reservations",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Activities_ActivityId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ActivityId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Activity1Id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Activity1Id",
                table: "Reservations",
                column: "Activity1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Activities_Activity1Id",
                table: "Reservations",
                column: "Activity1Id",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
