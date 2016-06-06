using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class LoginViewModel: INotifyPropertyChanged
    {
       

        public Korisnik korisnik { get; set; }

        public string Ime_txb { get; set; }
        public string Sifra_txb { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand PrijaviSe { get; set; }
        public ICommand RegistrujSe { get; set; }
        public ICommand HelpButton { get; set; }
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
            HelpButton = new RelayCommand<object>(helpButton);
        }

        public LoginViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();

            Ime_txb = "";

            PrijaviSe = new RelayCommand<object>(prijaviSe);
            RegistrujSe = new RelayCommand<object>(registrujSe);
            HelpButton = new RelayCommand<object>(helpButton);
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

                    Ime_txb = "";
                }

                
            }
        }



        private void registrujSe(object parametar)
        {
            NavigationService.Navigate(typeof(RegistracijaView), new RegistracijaViewModel(this));
        }

        private void helpButton(object parametar)
        {
            var dialog = new MessageDialog("Poštovani korisniče, pozdrav!\n\nOvo je aplikacija My Movie Collection, koju je razvio mladi i uspješni tim inženjera sa druge godine odsjeka za RI, prestižnog Elektrotehničkog fakulteta Univerziteta u Sarajevu.\n\nNa početnoj formi, vršite login, tj.ulazite u aplikaciju, ukoliko imate korisnički račun.\n\nUkoliko nemate račun, trebate da ga napravite, te stoga idete na Sign Up.\nNakon toga, unosite svoje podatke, pri čemu trebate paziti da nijedno polje ne ostavite praznim.\n\nNakon registrovanja, ulazite u aplikaciju.\nTu ste u mogućnosti da pretražujete filmove putem našeg online web servisa(imajte na umu da ovaj servis pokriva ZAISTA VELIKI BROJ FILMOVA, ali vjerovatno ne baš sve koji su ikad snimljeni).\nTakođe, možete da pravite svoje kolekcije, zatim da ih uređujete, brišete, dodajete i sl.\nOmogućeno Vam je da promijenite svoju šifru, u formi Uredi svoj profil.\n\nOvu aplikaciju su razvili: Amra Mujčinović, Berina Muhović, Emir Baručija, te Tarik Ahmetović.\n\nNadamo se da će Vam korištenje naše aplikacije biti ugodno:)\n\nZa sva pitanja nam se obratite u prostorijama Elektrotehničkog fakulteta, gdje vrlo često obitavamo (osim u ljetnim mjesecima kada smo na kratkom, ali zasluženom odmoru).");
            dialog.ShowAsync();
        }
    }
}