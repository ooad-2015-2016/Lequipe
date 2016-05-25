using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace MyMovieCollectionMigrations
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
                    Godina = table.Column(type: "TEXT", nullable: false),
                    KolekcijaId = table.Column(type: "INTEGER", nullable: false),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    ProsjecnaOcjena = table.Column(type: "REAL", nullable: false),
                    slika = table.Column(type: "picture", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmId);
                });
            migration.CreateTable(
                name: "Kolekcija",
                columns: table => new
                {
                    KolekcijaId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    slika = table.Column(type: "picture", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolekcija", x => x.KolekcijaId);
                });
            migration.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    DalijeAdmin = table.Column(type: "INTEGER", nullable: false),
                    DatumRegistracije = table.Column(type: "TEXT", nullable: false),
                    DatumRodjenja = table.Column(type: "TEXT", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Mail = table.Column(type: "TEXT", nullable: true),
                    OcjenaAplikacije = table.Column(type: "REAL", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Spol = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true),
                    slika = table.Column(type: "picture", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });
            migration.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    FilmID = table.Column(type: "INTEGER", nullable: false),
                    KolekcijaID = table.Column(type: "INTEGER", nullable: false),
                    KorisnikID = table.Column(type: "INTEGER", nullable: false),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    ocjena = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjena", x => x.OcjenaID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Film");
            migration.DropTable("Kolekcija");
            migration.DropTable("Korisnik");
            migration.DropTable("Ocjena");
        }
    }
}
