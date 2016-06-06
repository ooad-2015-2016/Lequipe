using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyMovieCollectionProjekat.MyMovieCollection.Models;

namespace MyMovieCollectionProjekatMigrations
{
    [ContextType(typeof(KorisnikDbContext))]
    partial class KorisnikDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyMovieCollectionProjekat.MyMovieCollection.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("DalijeAdmin");

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Ime");

                    b.Property<string>("Mail");

                    b.Property<float>("OcjenaAplikacije");

                    b.Property<string>("Prezime");

                    b.Property<string>("RFid");

                    b.Property<string>("Sifra");

                    b.Property<string>("Spol");

                    b.Property<string>("Username");

                    b.Property<byte[]>("slika");

                    b.Key("KorisnikId");
                });
        }
    }
}
