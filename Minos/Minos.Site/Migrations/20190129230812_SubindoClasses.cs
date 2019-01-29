using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Minos.Site.Migrations
{
    public partial class SubindoClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Texto = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
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
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoTurma = table.Column<string>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    Serie = table.Column<int>(nullable: false),
                    Grau = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    Admin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    TurmaId = table.Column<int>(nullable: true),
                    Matricula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(nullable: false),
                    TurmaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorTurma", x => new { x.ProfessorId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorTurma_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    PeriodoId = table.Column<int>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    TurmaId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Questionarios_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
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
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_TurmaId",
                table: "ProfessorTurma",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionarioPergunta_PerguntaId",
                table: "QuestionarioPergunta",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_PeriodoId",
                table: "Questionarios",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionarios_TurmaId",
                table: "Questionarios",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "QuestionarioPergunta");

            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Questionarios");

            migrationBuilder.DropTable(
                name: "Periodo");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
