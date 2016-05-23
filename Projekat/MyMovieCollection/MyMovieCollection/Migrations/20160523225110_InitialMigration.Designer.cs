using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyMovieCollection.MyMovieCollection.Models;

namespace MyMovieCollectionMigrations
{
    [ContextType(typeof(MovieCollectionDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160523225110_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyMovieCollection.MyMovieCollection.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Godina");

                    b.Property<int>("KolekcijaId");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<double>("ProsjecnaOcjena");

                    b.Property<byte[]>("slika")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Key("FilmId");
                });

            builder.Entity("MyMovieCollection.MyMovieCollection.Models.Kolekcija", b =>
                {
                    b.Property<int>("KolekcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<byte[]>("slika")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Key("KolekcijaId");
                });

            builder.Entity("MyMovieCollection.MyMovieCollection.Models.Korisnik", b =>
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

                    b.Property<string>("Sifra");

                    b.Property<string>("Spol");

                    b.Property<string>("Username");

                    b.Property<byte[]>("slika")
                        .Annotation("Relational:ColumnType", "picture");

                    b.Key("KorisnikId");
                });

            builder.Entity("MyMovieCollection.MyMovieCollection.Models.Ocjena", b =>
                {
                    b.Property<int>("OcjenaID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FilmID");

                    b.Property<int>("KolekcijaID");

                    b.Property<int>("KorisnikID");

                    b.Property<string>("Opis");

                    b.Property<int>("ocjena");

                    b.Key("OcjenaID");
                });
        }
    }
}
