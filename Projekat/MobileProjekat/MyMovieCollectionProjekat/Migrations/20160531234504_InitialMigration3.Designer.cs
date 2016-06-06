using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using MyMovieCollectionProjekat.MyMovieCollection.Models;

namespace MyMovieCollectionProjekatMigrations
{
    [ContextType(typeof(OcjenaDbContext))]
    partial class InitialMigration3
    {
        public override string Id
        {
            get { return "20160531234504_InitialMigration3"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("MyMovieCollectionProjekat.MyMovieCollection.Models.Ocjena", b =>
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
