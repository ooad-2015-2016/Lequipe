using Microsoft.Data.Entity;
using System;
using System.IO;
using Windows.Storage;

namespace MyMovieCollectionProjekat.MyMovieCollection.Models
{
    class KolekcijaDbContext: DbContext
    {

        public DbSet<Kolekcija> Kolekcije { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dataBaseFilePath = "Ooadbaza.db";
            try
            {
                dataBaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dataBaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={dataBaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 
        }
    }
}

