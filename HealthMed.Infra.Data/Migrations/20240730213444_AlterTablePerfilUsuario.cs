using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infra.Data.Migrations
{
    public partial class AlterTablePerfilUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoPerfil",
                table: "PerfilUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("INSERT INTO PerfilUsuario VALUES ('429835EC-20E1-4762-9356-8B79BF8A60F6', 'Médico', 0, '2024-07-30 20:14:14.053', 1)");
            migrationBuilder.Sql("INSERT INTO PerfilUsuario VALUES ('41EF8E8B-1EF0-439D-A299-D11D6591AA0C', 'Paciente', 0, '2024-07-30 20:14:14.053', 2)");

            migrationBuilder.Sql("INSERT INTO ClaimUsuario VALUES ('CE184A08-28EF-40C0-974B-C27D2B6E5B58', 'Acesso Médico', '2024-07-30 20:14:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO ClaimUsuario VALUES ('F5C81B47-4815-4B05-8328-7D0ED8E87B68', 'Acesso Paciente', '2024-07-30 20:14:14.053', 0)");

            migrationBuilder.Sql("INSERT INTO ClaimPerfil VALUES ('CE184A08-28EF-40C0-974B-C27D2B6E5B58','429835EC-20E1-4762-9356-8B79BF8A60F6')");
            migrationBuilder.Sql("INSERT INTO ClaimPerfil VALUES ('F5C81B47-4815-4B05-8328-7D0ED8E87B68','41EF8E8B-1EF0-439D-A299-D11D6591AA0C')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ClaimPerfil WHERE IdClaim = 'CE184A08-28EF-40C0-974B-C27D2B6E5B58' AND IdPerfil = '429835EC-20E1-4762-9356-8B79BF8A60F6'");
            migrationBuilder.Sql("DELETE FROM ClaimPerfil WHERE IdClaim = 'F5C81B47-4815-4B05-8328-7D0ED8E87B68' AND IdPerfil = '41EF8E8B-1EF0-439D-A299-D11D6591AA0C'");

            migrationBuilder.Sql("DELETE FROM ClaimUsuario WHERE Id = 'CE184A08-28EF-40C0-974B-C27D2B6E5B58'");
            migrationBuilder.Sql("DELETE FROM ClaimUsuario WHERE Id = 'F5C81B47-4815-4B05-8328-7D0ED8E87B68'");

            migrationBuilder.Sql("DELETE FROM PerfilUsuario WHERE Id = '429835EC-20E1-4762-9356-8B79BF8A60F6'");
            migrationBuilder.Sql("DELETE FROM PerfilUsuario WHERE Id = '41EF8E8B-1EF0-439D-A299-D11D6591AA0C'");

            migrationBuilder.DropColumn(
                name: "IdTipoPerfil",
                table: "PerfilUsuario");
        }
    }
}
