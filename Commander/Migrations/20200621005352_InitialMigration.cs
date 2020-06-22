using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Commander.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arvores",
                columns: table => new
                {
                    IdArvore = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEspecie = table.Column<int>(nullable: false),
                    CodigoArvore = table.Column<string>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false),
                    Idade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arvores", x => x.IdArvore);
                });

            migrationBuilder.CreateTable(
                name: "Colheita",
                columns: table => new
                {
                    IdColheita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArvore = table.Column<int>(nullable: false),
                    Info = table.Column<string>(maxLength: 250, nullable: false),
                    DataColheita = table.Column<DateTime>(nullable: false),
                    PesoBruto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colheita", x => x.IdColheita);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Howto = table.Column<string>(maxLength: 250, nullable: false),
                    Line = table.Column<string>(nullable: false),
                    Plataform = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    IdEspecie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoEspecie = table.Column<string>(maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.IdEspecie);
                });

            migrationBuilder.CreateTable(
                name: "GrupoArvores",
                columns: table => new
                {
                    IdGrupoArvore = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArvore = table.Column<int>(nullable: false),
                    CodigoGrupoArvore = table.Column<string>(maxLength: 10, nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoArvores", x => x.IdGrupoArvore);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arvores");

            migrationBuilder.DropTable(
                name: "Colheita");

            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "GrupoArvores");
        }
    }
}
