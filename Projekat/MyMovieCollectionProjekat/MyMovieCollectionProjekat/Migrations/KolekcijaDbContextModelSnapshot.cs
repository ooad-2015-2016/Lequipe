using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyMovieCollectionProjekat.MyMovieCollection.Models;

namespace MyMovieCollectionProjekatMigrations
{
    [ContextType(typeof(KolekcijaDbContext))]
    partial class KolekcijaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyMovieCollectionProjekat.MyMovieCollection.Models.Kolekcija", b =>
                {
                    b.Property<int>("KolekcijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.Property<byte[]>("slika");

                    b.Key("KolekcijaId");
                });
        }
    }
}
