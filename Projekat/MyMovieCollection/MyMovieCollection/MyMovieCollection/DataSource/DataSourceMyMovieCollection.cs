using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.DataSource
{
    public class DataSourceMyMovieCollection
    {
        private static ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>()
        { new Korisnik(1) }; //posto mi je mrsko unosit sve, napravila sam konstruktor samo sa id-em
        private static ObservableCollection<Film> filmovi = new ObservableCollection<Film>()
        { new Film(1)};
        private static ObservableCollection<Kolekcija> kolekcije = new ObservableCollection<Kolekcija>()
        {
            new Kolekcija(1,1, "Najdrazi filmovi"),
            new Kolekcija(2,1, "Najbolji horori"),
            new Kolekcija(3,2, "Emir mi preporucuje da pogledam"),
             new Kolekcija(4,2, "Berina mi preporucuje da pregledam")
        };
        private static ObservableCollection<Ocjena> ocjene = new ObservableCollection<Ocjena>();

        internal static ObservableCollection<Korisnik> DajSveKorisnike()
        {
            return korisnici;
        }

        internal static ObservableCollection<Film> DajSveFilmove()
        {
            return filmovi;
        }

        internal static ObservableCollection<Kolekcija> DajSveKolekcije()
        {
            return kolekcije;
        }

        internal static ObservableCollection<Ocjena> DajSveOcjene()
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
