using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace MyMovieCollectionProjekatMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Godina = table.Column(type: "TEXT", nullable: true),
                    KolekcijaId = table.Column(type: "INTEGER", nullable: false),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Link = table.Column(type: "TEXT", nullable: true),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    ProsjecnaOcjena = table.Column(type: "REAL", nullable: false),
                    god = table.Column(type: "TEXT", nullable: false),
                    slika = table.Column(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Film");
        }
    }
}
