using MyMovieCollection.MyMovieCollection.ViewModels;
using MyMovieCollection.MyMovieCollection.Views;
using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class PocetnaViewModel: INotifyPropertyChanged
    {
        public static Korisnik Korisnik1 { get; set; }
        public  Korisnik Korisnik { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand MojeKolekcije { get; set; }
        public ICommand DodajFilm { get; set; }
        public ICommand OdjaviSe { get; set; }
        public ICommand UrediProfil { get; set; }
        public ICommand JaAdmin { get; set; }


      
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
            
            Korisnik1 = parametar.korisnik;
            Korisnik = Korisnik1;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);
            JaAdmin = new RelayCommand<object>(jaAdmin);



        }

        public PocetnaViewModel(RegistracijaViewModel parametar)
        {
            Korisnik1 = parametar.korisnik;
            Korisnik = Korisnik1;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


        }

        public PocetnaViewModel(FilmViewModel parametar)
        {
            
            Korisnik = Korisnik1;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


        }

        public PocetnaViewModel(KolekcijaViewModel parametar)
        {
            Korisnik1 = parametar.korisnik;
            Korisnik = Korisnik1;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


        }

        public PocetnaViewModel(KorisnikViewModel parameter)
        {
            Korisnik1 = parameter.korisnik;
            Korisnik = Korisnik1;
            NavigationService = new NavigationService();

            MojeKolekcije = new RelayCommand<object>(mojeKolekcije);
            DodajFilm = new RelayCommand<object>(dodajFilm);
            OdjaviSe = new RelayCommand<object>(odjaviSe);
            UrediProfil = new RelayCommand<object>(urediProfil);


        }

        public PocetnaViewModel(AdministratorViewModel parametar)
        {
            
            Korisnik = Korisnik1;
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

        private async void jaAdmin(object parametar)
        {
            if (Korisnik.DalijeAdmin == true)
            { 
            NavigationService.Navigate(typeof(AdministratorView), new AdministratorViewModel(this));
            }
            else
            {
                var dialog1 = new MessageDialog("Pristup dozvoljen samo administratorima.");
                await dialog1.ShowAsync();
            }

        }
    }
}
