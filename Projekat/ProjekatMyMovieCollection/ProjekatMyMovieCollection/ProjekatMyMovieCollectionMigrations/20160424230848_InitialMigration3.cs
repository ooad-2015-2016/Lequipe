using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatMyMovieCollectionMigrations
{
    public partial class InitialMigration3 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Film",
                columns: table => new
                {
                    filmId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    godina = table.Column(type: "TEXT", nullable: false),
                    naziv = table.Column(type: "TEXT", nullable: true),
                    opis = table.Column(type: "TEXT", nullable: true),
                    prosjecnaOcjena = table.Column(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.filmId);
                });
            migration.CreateTable(
                name: "Kolekcija",
                columns: table => new
                {
                    kolekcijaId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    naziv = table.Column(type: "TEXT", nullable: true),
                    opis = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolekcija", x => x.kolekcijaId);
                });
            migration.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    ocjenaId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ocjena = table.Column(type: "INTEGER", nullable: false),
                    opis = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.ocjenaId);
                });
            migration.AlterColumn(
                name: "korisnikId",
                table: "Korisnik",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Film");
            migration.DropTable("Kolekcija");
            migration.DropTable("Ocjena");
            migration.AlterColumn(
                name: "korisnikId",
                table: "Korisnik",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
