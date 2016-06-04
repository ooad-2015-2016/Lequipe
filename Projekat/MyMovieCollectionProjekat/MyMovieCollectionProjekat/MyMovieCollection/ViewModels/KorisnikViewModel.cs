using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class KorisnikViewModel
    {
        public Korisnik korisnik { get; set; }

        public string Ime_txb { get; set; }
        public string Prezime_txb { get; set; }
        public string Datum_txb { get; set; }
        public string Username_txb { get; set; }
        public string Mail_txb { get; set; }
        public string Sifra_txb { get; set; }
        public string StaraSifra { get; set; }
        public string NovaSifra { get; set; }
        public string PonovoNovaSifra { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand SacuvajIzmjene { get; set; }
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

        public KorisnikViewModel()
        {

        }

        public KorisnikViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();
            korisnik = parametar.Korisnik;
            Ime_txb = parametar.Korisnik.Ime;
            Prezime_txb = parametar.Korisnik.Prezime;
            Datum_txb = parametar.Korisnik.DatumRodjenja.ToString();
            Username_txb = parametar.Korisnik.Username;
            Mail_txb = parametar.Korisnik.Mail;
            Sifra_txb = parametar.Korisnik.Sifra;

            SacuvajIzmjene = new RelayCommand<object>(sacuvajIzmjene);
            Nazad = new RelayCommand<object>(nazad);

            /*SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;

            SveOcjene = parametar.SveOcjene;*/


        }


        private async void sacuvajIzmjene(object parametar)
        {
            //prvo provjeri jel dobro unesen stari password

            if (Sifra_txb.Equals(korisnik.Sifra))
            {
                using (var db = new KorisnikDbContext())
                {
                   
                    if (NovaSifra != null && PonovoNovaSifra != null)
                    {
                        if (NovaSifra.Equals(PonovoNovaSifra))
                        {
                            korisnik.Sifra = NovaSifra;
                            
                            db.Korisnici.Remove(db.Korisnici.Where(x => x.KorisnikId == korisnik.KorisnikId && x.Sifra == Sifra_txb).FirstOrDefault());
                            
                            db.SaveChanges();

                            db.Korisnici.Add(korisnik);
                            db.SaveChanges();

                            var dialog = new MessageDialog("Izmjene sacuvane!");
                            await dialog.ShowAsync();
                        }
                        else
                        {
                            var dialog = new MessageDialog("Šifre se ne podudaraju!");
                            await dialog.ShowAsync();
                        }
                    }
                }
            }
            else
            {
                var dialog = new MessageDialog("Niste unijeli ispravnu šifru.");
                await dialog.ShowAsync();
            }
        }


        private void nazad(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }
    }
}
