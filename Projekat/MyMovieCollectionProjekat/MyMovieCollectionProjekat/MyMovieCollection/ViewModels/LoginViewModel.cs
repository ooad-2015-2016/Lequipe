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
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class LoginViewModel
    {
       /* //naše sve liste....__________________________________________

        public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();

        //..._________________________________________________________
        */

        public Korisnik korisnik { get; set; }

        public string Ime_txb { get; set; }
        public string Sifra_txb { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public bool nesto { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public LoginViewModel()
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();

            Ime_txb = "";



            PrijaviSe = new RelayCommand<object>(prijaviSe);
            RegistrujSe = new RelayCommand<object>(registrujSe);



        }

        public LoginViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = parametar.Korisnik;



            PrijaviSe = new RelayCommand<object>(prijaviSe);
            RegistrujSe = new RelayCommand<object>(registrujSe);

        }

        private async void prijaviSe(object parametar)
        {
            korisnik = null;

            var UnosPassBox = parametar as PasswordBox;
            Sifra_txb = UnosPassBox.Password;

            using (var db = new KorisnikDbContext())
            {
                if (Ime_txb != "" && Sifra_txb != "")
                    korisnik = db.Korisnici.Where(x => x.Username == Ime_txb && x.Sifra == Sifra_txb).FirstOrDefault();

                if (korisnik == null)
                {
                    var dialog1 = new MessageDialog("Neispravni podaci!");
                    await dialog1.ShowAsync();
                    
                   // VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                  //  NotifyPropertyChanged("VerifikacijaPoruka");

                }
                else
                {
                    //string VerifikacijaPoruka = "";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                    //U ovom slucaju sve je OK, idemo na drugu formu
                    NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
                }


            }
        }



        private void registrujSe(object parametar)
        {
            NavigationService.Navigate(typeof(RegistracijaView), new RegistracijaViewModel(this));
        }

    }
}
