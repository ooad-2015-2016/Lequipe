using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatMyMovieCollection.BazaPodataka.Models;

namespace ProjekatMyMovieCollectionMigrations
{
    [ContextType(typeof(KorisnikDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160424212802_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatMyMovieCollection.BazaPodataka.Models.Korisnik", b =>
                {
                    b.Property<int>("korisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRegistracije");

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("ime");

                    b.Property<string>("mail");

                    b.Property<float>("ocjenaAp");

                    b.Property<string>("prezime");

                    b.Property<string>("sifra");

                    b.Property<byte[]>("slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Key("korisnikId");
                });
        }
    }
}
