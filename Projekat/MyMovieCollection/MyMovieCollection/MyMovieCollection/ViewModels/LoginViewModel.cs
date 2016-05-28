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
using Windows.UI.Xaml.Controls;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class LoginViewModel
    {

        public Korisnik korisnik { get; set; }
        
        public string KorisnickoIme_txb { get; set; }
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
            KorisnickoIme_txb = "";
            Sifra_txb = "";

            PrijaviSe = new RelayCommand<object>(prijaviSe);
            RegistrujSe = new RelayCommand<object>(registrujSe);
            
        }

        public LoginViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();
            KorisnickoIme_txb = "";
            Sifra_txb = "";

            PrijaviSe = new RelayCommand<object>(prijaviSe);
            RegistrujSe = new RelayCommand<object>(registrujSe);

        }

        private void prijaviSe(object parametar)
        {
            var UnosPassBox = parametar as PasswordBox;
            Sifra_txb = UnosPassBox.Password;

            
            using (var db = new MovieCollectionDbContext())
            {
                if(KorisnickoIme_txb!=""  &&  Sifra_txb!="" )
                korisnik = db.Korisnici.Where(x => x.Username == KorisnickoIme_txb && x.Sifra == Sifra_txb).FirstOrDefault();

                if (korisnik == null)
                {
                    //Javiti korisniku da su pogresno uneseni podaci
                    //VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                    //NotifyPropertyChanged("VerifikacijaPoruka");

                }
                else
                {
                    /*VerifikacijaPoruka = "";
                    NotifyPropertyChanged("VerifikacijaPoruka");*/
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
