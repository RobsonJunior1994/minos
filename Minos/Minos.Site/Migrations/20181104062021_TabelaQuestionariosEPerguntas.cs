using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Minos.Site.Migrations
{
    public partial class TabelaQuestionariosEPerguntas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionarioId",
                table: "Turmas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeriodoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionarios_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalTable: "Periodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuestionarioPergunta",
                columns: table => new
                {
                    QuestionarioId = table.Column<int>(nullable: false),
                    PerguntaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionarioPergunta", x => new { x.QuestionarioId, x.PerguntaId });
                    table.ForeignKey(
                        name: "FK_QuestionarioPergunta_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionarioPergunta_Questionarios_QuestionarioId",
                        column: x => x.QuestionarioId,
                        principalTable: "Questionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_QuestionarioId",
                table: "Turmas",
                column: "QuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionarioPergunta_PerguntaId",
                table: "QuestionarioPergunta",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_PeriodoId",
                table: "Questionarios",
                column: "PeriodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Questionarios_QuestionarioId",
                table: "Turmas",
                column: "QuestionarioId",
                principalTable: "Questionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Questionarios_QuestionarioId",
                table: "Turmas");

            migrationBuilder.DropTable(
                name: "QuestionarioPergunta");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Questionarios");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_QuestionarioId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "QuestionarioId",
                table: "Turmas");
        }
    }
}
