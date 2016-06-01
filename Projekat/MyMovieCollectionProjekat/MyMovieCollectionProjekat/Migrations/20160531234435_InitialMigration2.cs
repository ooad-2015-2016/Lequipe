using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace MyMovieCollectionProjekatMigrations
{
    public partial class InitialMigration2 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Kolekcija",
                columns: table => new
                {
                    KolekcijaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true),
                    Opis = table.Column(type: "TEXT", nullable: true),
                    slika = table.Column(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolekcija", x => x.KolekcijaId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Kolekcija");
        }
    }
}
