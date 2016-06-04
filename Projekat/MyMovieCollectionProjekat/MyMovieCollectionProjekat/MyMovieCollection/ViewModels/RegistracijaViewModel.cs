using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class RegistracijaViewModel
    {
        public Korisnik korisnik { get; set; }
        public string Ime_txb { get; set; }
        public string Prezime_txb { get; set; }
        public string Username_txb { get; set; }
        //public string Mail_txb { get; set; }
        public string Sifra_txb { get; set; }
        public string SifraPonovo_txb { get; set; }
        public string Spol { get; set; }
        //public DateTime Datum_txb { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand RegistrujSe { get; set; }
        public ICommand MuskoJe { get; set; }
        public ICommand ZenskoJe { get; set; }


     /*   //        ___________________

        public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();
        //______________*/

        public event PropertyChangedEventHandler PropertyChanged;
        public string Poruka { get; set; }

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public RegistracijaViewModel()
        {

        }

        public RegistracijaViewModel(LoginViewModel parameter)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();
            Ime_txb = "";
            Prezime_txb = "";
            Username_txb = "";
            // Mail_txb = "";
            Sifra_txb = "";
            SifraPonovo_txb = "";
            Spol = "Zensko";
            // Datum_txb 

            ZenskoJe = new RelayCommand<object>(zenskoJe);
            MuskoJe = new RelayCommand<object>(muskoJe);
            RegistrujSe = new RelayCommand<object>(registrujSe);

         /*   SviFilmovi = parameter.SviFilmovi;
            SviKorisnici = parameter.SviKorisnici;
            SveKolekcije = parameter.SveKolekcije;
            SviFilmovi = parameter.SviFilmovi;
            SveOcjene = parameter.SveOcjene;*/

        }

        public async void registrujSe(object parametar)
        {
            if (Ime_txb != "" && Prezime_txb != "" && Username_txb != "" && Sifra_txb != "" && Sifra_txb.Equals(SifraPonovo_txb))
            {
                using (var db = new KorisnikDbContext())
                {                    
                       korisnik = db.Korisnici.Where(x => x.Username == Username_txb).FirstOrDefault();
                   
                    if (korisnik == null)
                    {
                          int max = -1;
                          foreach (Korisnik k in db.Korisnici)
                          {
                              if (k.KorisnikId > max) max = k.KorisnikId;
                          }
                          max++;
                         
                        Korisnik noviKorisnik = new Korisnik(max);

                        noviKorisnik.Ime = Ime_txb;
                        noviKorisnik.Prezime = Prezime_txb;
                        noviKorisnik.Username = Username_txb;
                        noviKorisnik.Sifra = Sifra_txb;
                        noviKorisnik.Mail = "";
                        noviKorisnik.Spol = Spol;

                        db.Korisnici.Add(noviKorisnik);
                        db.SaveChanges();

                        var dialog = new MessageDialog(noviKorisnik.Ime + " " + noviKorisnik.Prezime + ", uspješno ste registrovani!");
                        await dialog.ShowAsync();
                        NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
                    }
                    else
                    {
                        Poruka = "Username je zauzet.";
                        NotifyPropertyChanged("Poruka");
                    }
                }
            }
            else
            {
                var dialog = new MessageDialog("Unesite ispravne podatke!");
                await dialog.ShowAsync();
                Poruka = "Popunite sva polja ispravno.";
                NotifyPropertyChanged("Poruka");
            }
        }

        public void muskoJe(object parametar)
        {
            Spol = "musko";
        }

        public void zenskoJe(object parametar)
        {
            Spol = "zensko";
        }
    }
}