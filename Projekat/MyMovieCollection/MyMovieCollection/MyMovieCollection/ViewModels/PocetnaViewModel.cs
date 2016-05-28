using MyMovieCollection.MyMovieCollection.Helper;
using MyMovieCollection.MyMovieCollection.Models;
using MyMovieCollection.MyMovieCollection.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class PocetnaViewModel
    {
        public Korisnik Korisnik;

        

        public INavigationService NavigationService { get; set; }
        public ICommand MojeKolekcije { get; set; }
        public ICommand DodajFilm { get; set; }
        public ICommand OdjaviSe { get; set; }
        public ICommand UrediProfil { get; set; }

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

        }

        public PocetnaViewModel(RegistracijaViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }

        public PocetnaViewModel(FilmViewModel parametar)
        {
            Korisnik = parametar.Korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }

        public PocetnaViewModel(KolekcijaViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }

        public PocetnaViewModel(KorisnikViewModel parametar)
        {
            Korisnik = parametar.korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }

        public PocetnaViewModel(AdministratorViewModel parametar)
        {
            Korisnik = parametar.Korisnik;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);

        }


        private void odjaviSe(object parametar)
        {
            // KorisnickoIme_txb = Korisnik_txb.Text.ToString();

           // MessageBox.Show("");
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
