using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.DataSource
{
    public class DataSourceMyMovieCollection
    {
        private static List<Korisnik> korisnici = new List<Korisnik>()
        { new Korisnik(1) }; //posto mi je mrsko unosit sve, napravila sam konstruktor samo sa id-em
        private static List<Film> filmovi = new List<Film>()
        { new Film(1)};
        private static List<Kolekcija> kolekcije = new List<Kolekcija>();
        private static List<Ocjena> ocjene = new List<Ocjena>();

        internal static IList<Korisnik> DajSveKorisnike()
        {
            return korisnici;
        }

        internal static IList<Film> DajSveFilmove()
        {
            return filmovi;
        }

        internal static IList<Kolekcija> DajSveKolekcije()
        {
            return kolekcije;
        }

        internal static IList<Ocjena> DajSveOcjene()
        {
            return ocjene;
        }

        internal static Korisnik DajKorisnikaPoId(int korisnikId)
        {
            return korisnici.Where(k => k.KorisnikId.Equals(korisnikId)).FirstOrDefault();
        }

        internal static Kolekcija DajKolekcijuPoId(int kolekcijaId)
        {
            return kolekcije.Where(k => k.KolekcijaId.Equals(kolekcijaId)).FirstOrDefault();
        }

        internal static Film DajFilmPoId(int filmId)
        {
            return filmovi.Where(k => k.FilmId.Equals(filmId)).FirstOrDefault();
        }

        internal static Ocjena DajOcjenuPoId(int ocjenaId)
        {
            return ocjene.Where(k => k.OcjenaID.Equals(ocjenaId)).FirstOrDefault();
        }

        internal static Korisnik ProvjeraUsername(string username)
        {
            return korisnici.Where(k => k.Username.Equals(username)).FirstOrDefault();
        }

        internal static string DajSifruKorisnika(Korisnik k)
        {
            return k.Sifra;

        }
    }
}
