using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectHealthApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAgendaProfessionalMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agenda_Professional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTable = table.Column<TimeSpan>(type: "time", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda_Professional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaProfessional_ProfessionalId",
                        column: x => x.ProfessionalId,
                        principalTable: "Professional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Professional_ProfessionalId",
                table: "Agenda_Professional",
                column: "ProfessionalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda_Professional");
        }
    }
}
