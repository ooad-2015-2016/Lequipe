using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatMyMovieCollection.BazaPodataka.Models;

namespace ProjekatMyMovieCollectionMigrations
{
    [ContextType(typeof(KorisnikDbContext))]
    partial class InitialMigration3
    {
        public override string Id
        {
            get { return "20160424230848_InitialMigration3"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatMyMovieCollection.BazaPodataka.Models.Film", b =>
                {
                    b.Property<int>("filmId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("godina");

                    b.Property<string>("naziv");

                    b.Property<string>("opis");

                    b.Property<double>("prosjecnaOcjena");

                    b.Key("filmId");
                });

            builder.Entity("ProjekatMyMovieCollection.BazaPodataka.Models.Kolekcija", b =>
                {
                    b.Property<int>("kolekcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("naziv");

                    b.Property<string>("opis");

                    b.Key("kolekcijaId");
                });

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

            builder.Entity("ProjekatMyMovieCollection.BazaPodataka.Models.Ocjena", b =>
                {
                    b.Property<int>("ocjenaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ocjena");

                    b.Property<string>("opis");

                    b.Key("ocjenaId");
                });
        }
    }
}
