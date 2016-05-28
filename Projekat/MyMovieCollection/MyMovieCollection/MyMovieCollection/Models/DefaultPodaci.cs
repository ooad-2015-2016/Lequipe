using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class DefaultPodaci
    {
        public static void Initialize(MovieCollectionDbContext context)
        {


            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                    new Korisnik()
                    {
                        Ime = "n",
                        Prezime = "fdfd",
                        Mail = "etf@etf.unsa.ba",
                        Spol = "musko",
                        Username = "neko",
                        Sifra = "neko",
                        DalijeAdmin = false

                    }

                );
            }
            context.SaveChanges();

            if (!context.Kolekcije.Any())
            {
                context.Kolekcije.AddRange(
                    new Kolekcija()
                    {
                        Naziv = "ffd",
                        Opis = "FDF"

                    }

                );
            }
            context.SaveChanges();

            if (!context.Filmovi.Any())
            {
                context.Filmovi.AddRange(
                 new Film()
                    {
                        Naziv = "film",
                        ProsjecnaOcjena = 0,
                        Opis = "fdfdf"

                    }

                );
            }
            context.SaveChanges();
        }
    }
}
