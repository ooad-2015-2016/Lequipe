using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Services;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class FilmViewModel
    {
        public Film OdabraniFilm { get; set; }
        public Korisnik Korisnik { get; set; }


        public string NazivFilma_txb { get; set; }

        public ObservableCollection<Film> FilmoviNet { get; set; }

        public INavigationService NavigationService { get; set; }
        public Kolekcija KolekcijaUKojuSeDodajeFilm { get; set; }
        public int OcjenaFilma { get; set; }
        public ICommand Search { get; set; }
        public ICommand DodajFilm { get; set; }
        public ICommand Nazad { get; set; }

        //        ___________________

        public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();
        //______________



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public FilmViewModel()
        {
            NavigationService = new NavigationService();

            NazivFilma_txb = "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            Nazad = new RelayCommand<object>(nazad);

            FilmoviNet = new ObservableCollection<Film>();
            Film f = new Film();
            f.Naziv = "Emirrrrrrr";
            FilmoviNet.Add(f);
        }

        public FilmViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();

            Korisnik = parametar.Korisnik;

            NazivFilma_txb = "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);

            SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;
        }

        private async void search(object parametar)
        {
            FilmoviNet.Clear();
            FilmoviService f = new FilmoviService();
            await f.getFilmovi("amra");
            foreach (Film fl in f.Filmovi)
                FilmoviNet.Add(fl);

            var dialog1 = new MessageDialog(FilmoviNet.Count.ToString());
            await dialog1.ShowAsync();
        }

        private void dodajFilm(object parametar)
        {
            // ovdje bi program vec trebao da zna ko je korinik
            //potrebno je film iz listboxa koji je oznacen stavit u OdabraniFilm
            // OdabraniFilm=FilmoviNet.
            //  OdabraniFilm film= new Film( IDictionary, naziv,...., Korisnik.KorisnikId, KolekcijaUKojuSeDodajeFilm.KolekcijaId)

          /*  using (var db = new MovieCollectionDbContext())
            {

                db.Filmovi.Add(OdabraniFilm);
            }*/

            //obavjestenje da je uspjesno dodano
        }

        private void nazad(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }


    }
}
