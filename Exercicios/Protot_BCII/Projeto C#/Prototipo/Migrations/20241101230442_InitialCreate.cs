using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prototipo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.ModalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Competicoes",
                columns: table => new
                {
                    CompeticaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false),
                    TipoTorneio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModalidadeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competicoes", x => x.CompeticaoId);
                    table.ForeignKey(
                        name: "FK_Competicoes_Modalidades_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competicoes_Modalidades_ModalidadeId1",
                        column: x => x.ModalidadeId1,
                        principalTable: "Modalidades",
                        principalColumn: "ModalidadeId");
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompeticaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeId);
                    table.ForeignKey(
                        name: "FK_Equipes_Competicoes_CompeticaoId",
                        column: x => x.CompeticaoId,
                        principalTable: "Competicoes",
                        principalColumn: "CompeticaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atleta",
                columns: table => new
                {
                    AtletaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleta", x => x.AtletaId);
                    table.ForeignKey(
                        name: "FK_Atleta_Equipes_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipes",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atleta_EquipeId",
                table: "Atleta",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Competicoes_ModalidadeId",
                table: "Competicoes",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Competicoes_ModalidadeId1",
                table: "Competicoes",
                column: "ModalidadeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_CompeticaoId",
                table: "Equipes",
                column: "CompeticaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atleta");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Competicoes");

            migrationBuilder.DropTable(
                name: "Modalidades");
        }
    }
}
