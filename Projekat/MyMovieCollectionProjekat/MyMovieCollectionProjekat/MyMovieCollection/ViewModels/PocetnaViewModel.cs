using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class PocetnaViewModel
    {
        public Korisnik Korisnik;



        public INavigationService NavigationService { get; set; }
        public ICommand MojeKolekcije { get; set; }
        public ICommand DodajFilm { get; set; }
        public ICommand OdjaviSe { get; set; }
        public ICommand UrediProfil { get; set; }


        //        ___________________

      /*  public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();
        //______________

    */

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public PocetnaViewModel()
        {

        }

        public PocetnaViewModel(LoginViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


           /* SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;
            */

        }

        public PocetnaViewModel(RegistracijaViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


           /* SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;
            */

        }

        public PocetnaViewModel(FilmViewModel parametar)
        {
            Korisnik = parametar.Korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


           /* SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;
            */
        }

        public PocetnaViewModel(KolekcijaViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

           /* SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;
            */

        }

        public PocetnaViewModel(KorisnikViewModel parameter)
        {
            Korisnik = parameter.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


           /* SviFilmovi = parameter.SviFilmovi;
            SviKorisnici = parameter.SviKorisnici;
            SveKolekcije = parameter.SveKolekcije;
            SviFilmovi = parameter.SviFilmovi;
            SveOcjene = parameter.SveOcjene;
            */

        }

        public PocetnaViewModel(AdministratorViewModel parametar)
        {
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }


        private void odjaviSe(object parametar)
        {
            Korisnik = null;
            NavigationService.Navigate(typeof(MainPage), new LoginViewModel(this));

        }

        private void dodajFilm(object parametar)
        {

            NavigationService.Navigate(typeof(FilmView), new FilmViewModel(this));
        }

        private void mojeKolekcije(object parametar)
        {

            NavigationService.Navigate(typeof(KolekcijaView), new KolekcijaViewModel(this));
        }

        private void urediProfil(object parametar)
        {

            NavigationService.Navigate(typeof(KorisnikView), new KorisnikViewModel(this));
        }
    }
}
