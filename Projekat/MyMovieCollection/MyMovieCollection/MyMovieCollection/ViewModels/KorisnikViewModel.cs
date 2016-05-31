﻿using MyMovieCollection.MyMovieCollection.DataSource;
using MyMovieCollection.MyMovieCollection.Helper;
using MyMovieCollection.MyMovieCollection.Models;
using MyMovieCollection.MyMovieCollection.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollection.MyMovieCollection.ViewModels
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
            korisnik = parametar.Korisnik;
            Ime_txb = parametar.Korisnik.Ime;
            Prezime_txb = parametar.Korisnik.Prezime;
            Datum_txb = parametar.Korisnik.DatumRodjenja.ToString();
            Username_txb = parametar.Korisnik.Username;
            Mail_txb = parametar.Korisnik.Mail;
            Sifra_txb = parametar.Korisnik.Sifra;

            SacuvajIzmjene = new RelayCommand<object>(sacuvajIzmjene);
            Nazad = new RelayCommand<object>(nazad);

            SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
           
            SveOcjene = parametar.SveOcjene;


        }


        private  async void sacuvajIzmjene(object parametar)
        {
            //prvo provjeri jel dobro unesen stari password

            if (Sifra_txb.Equals(korisnik.KorisnikId))
            {
                //korisnik = db.Korisnici.Where(x => x.Username == KorisnickoIme_txb && x.Sifra == Sifra_txb).FirstOrDefault();

                if (NovaSifra.Equals(PonovoNovaSifra) && NovaSifra != null)
                {
                    /*  using (var db = new MovieCollectionDbContext())
                      {
                          korisnik.Sifra = NovaSifra;
                          // db.Korisnici.Remove(db.Korisnici.Where(x => x.Username == KorisnickoIme_txb && x.Sifra == Sifra_txb).FirstOrDefault());
                          // db.Korisnici.Add(korisnik);
                          // db.SaveChanges();
                          //Messagebox zelite li sacuvati izmjene...
                          var dialog = new MessageDialog("Izmjene sacuvane!");
                          await dialog.ShowAsync();
                      }*/
                    korisnik.Sifra = NovaSifra;
                    SviKorisnici.Remove(SviKorisnici.Where(x => x.KorisnikId == korisnik.KorisnikId).FirstOrDefault());
                    SviKorisnici.Add(korisnik);

                    var dialog = new MessageDialog("Izmjene sacuvane!");
                    await dialog.ShowAsync();

                }
                else
                {
                    var dialog = new MessageDialog("Šifre se ne podudaraju!");
                    await dialog.ShowAsync();


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