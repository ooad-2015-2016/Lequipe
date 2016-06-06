using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace MyMovieCollectionProjekatMigrations
{
    public partial class InitialMigration1 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
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
                    RFid = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Spol = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true),
                    slika = table.Column(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Korisnik");
        }
    }
}
