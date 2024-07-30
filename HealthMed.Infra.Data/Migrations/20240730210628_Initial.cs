using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthMed.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPerfil",
                columns: table => new
                {
                    IdClaim = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPerfil = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPerfil", x => new { x.IdClaim, x.IdPerfil });
                    table.ForeignKey(
                        name: "FK_ClaimPerfil_ClaimUsuario_IdClaim",
                        column: x => x.IdClaim,
                        principalTable: "ClaimUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimPerfil_PerfilUsuario_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CRM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdPerfil = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Especialidade_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Usuario_PerfilUsuario_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "PerfilUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaMedica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdHorario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaMedica_Horario_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaMedica_Usuario_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaMedica_Usuario_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedica_IdHorario",
                table: "AgendaMedica",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedica_IdMedico",
                table: "AgendaMedica",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedica_IdPaciente",
                table: "AgendaMedica",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPerfil_IdPerfil",
                table: "ClaimPerfil",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdEspecialidade",
                table: "Usuario",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('E2628372-5F4F-44F3-B34B-8EF5354F04FA', 'CARDIOLOGIA', '2024-07-30 18:08:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('8DCD764C-CEDE-4763-BCE8-9070D2D6E9E9', 'ORTOPEDIA', '2024-07-30 18:08:15.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('1199A2C5-61CF-4B13-A6C5-F422D3A96AE8', 'NUTROLOGIA', '2024-07-30 18:08:16.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('4D3BDC4B-3716-4799-BC46-4003D64C341C', 'CLINICA GERAL', '2024-07-30 18:08:17.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('597A888B-5705-4476-8499-3D562C534B20', 'DERMATOLOGIA', '2024-07-30 18:08:18.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('CEDB3C73-8682-4482-B3B8-B91428C444DF', 'GINECOLOGIA', '2024-07-30 18:08:19.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('E3A9CCB1-FC02-4183-A88A-8CCA5F82E6FB', 'ENDOCRINOLOGIA', '2024-07-30 18:09:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('FD24CC1D-94CE-4C06-B957-97005E714465', 'INFECTOLOGIA', '2024-07-30 18:10:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('AC95BAA4-BBA6-470C-81C3-7C08FFB7DDAF', 'PEDIATRIA', '2024-07-30 18:11:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Especialidade VALUES ('D4324EE7-B8CA-4A24-B836-2D4A1196767C', 'PSICOLOGIA', '2024-07-30 18:14:14.053', 0)");


            migrationBuilder.Sql("INSERT INTO Horario VALUES ('27482CF3-B4AC-403B-995B-D90F9B91DC87', '07:00', '2024-07-30 19:08:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('520DC2C8-A27B-4B4C-8EAA-83CB43179479', '07:30', '2024-07-30 19:08:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('160A66FC-A57A-47E8-8953-46008DCB9A45', '08:00', '2024-07-30 19:08:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('F890B9E5-918E-4F16-94C1-3319040790DF', '08:30', '2024-07-30 19:08:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('B1A825F5-6FE2-4D0A-9543-AB1F984CE68C', '09:00', '2024-07-30 19:08:15.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('537E5A56-149D-42A0-AD5D-033357E9554C', '09:30', '2024-07-30 19:08:15.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('36CD1CBC-08C7-42A3-923C-AA6119C79BA6', '10:00', '2024-07-30 19:08:16.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('82E06512-B823-46F8-8B53-45E6DB4A9F88', '10:30', '2024-07-30 19:08:16.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('2D0C39D1-F103-4E74-AF7A-E83C009C2E60', '11:00', '2024-07-30 19:08:17.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('C6626BD9-2BF0-40F5-8964-F1A37C397C57', '11:30', '2024-07-30 19:08:17.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('7BB8D4F3-6BD8-4207-87F3-AF935DBDA8BE', '12:00', '2024-07-30 19:08:18.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('69832C30-68CC-430D-BC50-88F4ED7E462B', '12:30', '2024-07-30 19:08:18.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('5A147F45-516B-44A7-8C1D-42BFD24E9AEE', '13:00', '2024-07-30 19:08:19.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('E40870C3-193C-4D2D-B179-585E1594DD6B', '13:30', '2024-07-30 19:08:19.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('0A533BAC-6730-4D12-8000-8B57330C0E5B', '14:00', '2024-07-30 19:09:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('4AAD1C5B-4FEC-4B82-A967-F66EA57FE35C', '14:30', '2024-07-30 19:09:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('79A0F454-55DB-4DA3-982F-306851F41A28', '15:00', '2024-07-30 19:10:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('D1D0E272-52EB-41CF-A929-98D21A977F61', '15:30', '2024-07-30 19:10:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('A8E98A5D-5133-4FA2-9569-C5B81F9C39DC', '16:00', '2024-07-30 19:11:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('0D3C934B-369A-4A0A-8F26-7C9634831A9F', '16:30', '2024-07-30 19:11:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('57C312D1-4398-4E1A-A8F9-D9494C9420CE', '17:00', '2024-07-30 19:14:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('0CCFD793-1C91-4162-A858-BBE4802207B4', '17:30', '2024-07-30 19:14:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('A3DE6E59-86E5-40B1-8D15-066E518963E5', '18:00', '2024-07-30 19:14:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('D05E83A0-3D28-4516-BB94-E121B55C3858', '18:30', '2024-07-30 19:14:14.053', 0)");
            migrationBuilder.Sql("INSERT INTO Horario VALUES ('C7193960-5E07-4B92-A9EB-0D58AB46D017', '19:00', '2024-07-30 19:14:14.053', 0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'E2628372-5F4F-44F3-B34B-8EF5354F04FA'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = '8DCD764C-CEDE-4763-BCE8-9070D2D6E9E9'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = '1199A2C5-61CF-4B13-A6C5-F422D3A96AE8'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = '4D3BDC4B-3716-4799-BC46-4003D64C341C'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = '597A888B-5705-4476-8499-3D562C534B20'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'CEDB3C73-8682-4482-B3B8-B91428C444DF'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'E3A9CCB1-FC02-4183-A88A-8CCA5F82E6FB'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'FD24CC1D-94CE-4C06-B957-97005E714465'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'AC95BAA4-BBA6-470C-81C3-7C08FFB7DDAF'");
            migrationBuilder.Sql("DELETE FROM Especialidade WHERE Id = 'D4324EE7-B8CA-4A24-B836-2D4A1196767C'");

            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '27482CF3-B4AC-403B-995B-D90F9B91DC87'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '520DC2C8-A27B-4B4C-8EAA-83CB43179479'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '160A66FC-A57A-47E8-8953-46008DCB9A45'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'F890B9E5-918E-4F16-94C1-3319040790DF'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'B1A825F5-6FE2-4D0A-9543-AB1F984CE68C'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '537E5A56-149D-42A0-AD5D-033357E9554C'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '36CD1CBC-08C7-42A3-923C-AA6119C79BA6'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '82E06512-B823-46F8-8B53-45E6DB4A9F88'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '2D0C39D1-F103-4E74-AF7A-E83C009C2E60'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'C6626BD9-2BF0-40F5-8964-F1A37C397C57'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '7BB8D4F3-6BD8-4207-87F3-AF935DBDA8BE'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '69832C30-68CC-430D-BC50-88F4ED7E462B'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '5A147F45-516B-44A7-8C1D-42BFD24E9AEE'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'E40870C3-193C-4D2D-B179-585E1594DD6B'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '0A533BAC-6730-4D12-8000-8B57330C0E5B'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '4AAD1C5B-4FEC-4B82-A967-F66EA57FE35C'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '79A0F454-55DB-4DA3-982F-306851F41A28'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'D1D0E272-52EB-41CF-A929-98D21A977F61'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'A8E98A5D-5133-4FA2-9569-C5B81F9C39DC'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '0D3C934B-369A-4A0A-8F26-7C9634831A9F'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '57C312D1-4398-4E1A-A8F9-D9494C9420CE'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = '0CCFD793-1C91-4162-A858-BBE4802207B4'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'A3DE6E59-86E5-40B1-8D15-066E518963E5'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'D05E83A0-3D28-4516-BB94-E121B55C3858'");
            migrationBuilder.Sql("DELETE FROM Horario WHERE Id = 'C7193960-5E07-4B92-A9EB-0D58AB46D017'");

            migrationBuilder.DropTable(
                name: "AgendaMedica");

            migrationBuilder.DropTable(
                name: "ClaimPerfil");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "ClaimUsuario");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "PerfilUsuario");
        }
    }
}
