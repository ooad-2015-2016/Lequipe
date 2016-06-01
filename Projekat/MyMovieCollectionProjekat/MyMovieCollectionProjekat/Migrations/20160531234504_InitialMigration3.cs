using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace MyMovieCollectionProjekatMigrations
{
    public partial class InitialMigration3 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Ocjena",
                columns: table => new
                {
                    OcjenaID = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
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
            migration.DropTable("Ocjena");
        }
    }
}
