using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infra.Data.Migrations
{
    public partial class AddColumnAgendadoInTableAgendaMedica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Agendado",
                table: "AgendaMedica",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Agendado",
                table: "AgendaMedica");
        }
    }
}
