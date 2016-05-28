using MyMovieCollection.MyMovieCollection.DataSource;
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
using Windows.UI.Popups;

namespace MyMovieCollection.MyMovieCollection.ViewModels
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

        }

        public async void registrujSe(object parametar)
        {
            var dialog1 = new MessageDialog(Ime_txb);
            await dialog1.ShowAsync();

            if (Ime_txb !="" && Prezime_txb != "" && Username_txb != "" && Sifra_txb != "" && Sifra_txb.Equals(SifraPonovo_txb))
            {
                
               
                using (var db = new MovieCollectionDbContext())
                {
                    //provjera da li postoji user s istim username-om
                   korisnik = db.Korisnici.Where(x => x.Username == Username_txb).FirstOrDefault();
                   // korisnik = DataSourceMyMovieCollection.ProvjeraUsername(Username_txb);
                    if (korisnik == null)
                    {
                        /* int max = -1;
                         foreach (Korisnik k in db.korisnici)
                         {
                             if (k.KorisnikId > max) max = k.KorisnikId;
                         }
                         max++;*/

                        int max = -1;
                        foreach (Korisnik k in DataSourceMyMovieCollection.DajSveKorisnike())
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




                        korisnik = noviKorisnik;
                         db.Korisnici.Add(noviKorisnik);
                         db.SaveChanges();



                        //uspjesno ste registrovani
                        var dialog = new MessageDialog("Uspješno ste registrovani!");
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
