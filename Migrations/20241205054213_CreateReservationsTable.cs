using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFitness.Migrations
{
    /// <inheritdoc />
    /// 
    public partial class CreateReservationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "Reservations",
        columns: table => new
        {
            Id = table.Column<int>(nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
            MemberId = table.Column<int>(nullable: false),
            Activity1Id = table.Column<int>(nullable: false),
            Date = table.Column<DateTime>(nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Reservations", x => x.Id);
            table.ForeignKey(
                name: "FK_Reservations_Members_MemberId",
                column: x => x.MemberId,
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_Reservations_Activities_Activity1Id",
                column: x => x.Activity1Id,
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });
}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
