﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class MovieCollectionDbContext: DbContext
    {
        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Kolekcija> Kolekcije { get; set; }
        public DbSet<Ocjena> Ocjene { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {

            string DBPath = "Ooadbaza.db";

            try
            {
                DBPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DBPath);
            }
            catch (InvalidOperationException)
            {
                optBuilder.UseSqlite($"Data source = {DBPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBulider)
        {
            modelBulider.Entity<Korisnik>().Property(p => p.slika).HasColumnType("picture");
            modelBulider.Entity<Kolekcija>().Property(p => p.slika).HasColumnType("picture");
            modelBulider.Entity<Film>().Property(p => p.slika).HasColumnType("picture");

           


        }

      
    }
}