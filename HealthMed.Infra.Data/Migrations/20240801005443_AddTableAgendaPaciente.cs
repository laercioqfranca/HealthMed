using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infra.Data.Migrations
{
    public partial class AddTableAgendaPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgendaMedica_Usuario_IdPaciente",
                table: "AgendaMedica");

            migrationBuilder.DropIndex(
                name: "IX_AgendaMedica_IdPaciente",
                table: "AgendaMedica");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "AgendaMedica");

            migrationBuilder.CreateTable(
                name: "AgendaPaciente",
                columns: table => new
                {
                    IdAgendaMedica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaPaciente", x => new { x.IdAgendaMedica, x.IdPaciente });
                    table.ForeignKey(
                        name: "FK_AgendaPaciente_AgendaMedica_IdAgendaMedica",
                        column: x => x.IdAgendaMedica,
                        principalTable: "AgendaMedica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AgendaPaciente_Usuario_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaPaciente_IdAgendaMedica",
                table: "AgendaPaciente",
                column: "IdAgendaMedica",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendaPaciente_IdPaciente",
                table: "AgendaPaciente",
                column: "IdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaPaciente");

            migrationBuilder.AddColumn<Guid>(
                name: "IdPaciente",
                table: "AgendaMedica",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedica_IdPaciente",
                table: "AgendaMedica",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_AgendaMedica_Usuario_IdPaciente",
                table: "AgendaMedica",
                column: "IdPaciente",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
