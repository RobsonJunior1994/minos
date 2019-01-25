using Microsoft.EntityFrameworkCore.Migrations;

namespace Minos.Site.Migrations
{
    public partial class SubindoClassesDeleteProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Professores",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Professores");
        }
    }
}
