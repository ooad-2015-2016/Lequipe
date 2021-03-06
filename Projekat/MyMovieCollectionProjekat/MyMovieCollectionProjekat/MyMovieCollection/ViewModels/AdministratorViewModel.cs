﻿using MyMovieCollectionProjekat.MyMovieCollection.Helper;
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
    class AdministratorViewModel: INotifyPropertyChanged
    {
    
        
        public ICommand IzbrisiKorisnika { get; set; }
        public ICommand PostaviZaAdmina { get; set; }
        public ICommand PrikaziDetaljeKorisnik { get; set; }
        
        public PocetnaViewModel Parent { get; set; }
        public string PisiIme { get; set; }
        public string PisiMail { get; set; }
        public string PisiPrezime { get; set; }
        public string PisiUserName { get; set; }
        public string PisiDatumReg { get; set; }
        public string RFID_txb { get; set; }
        Rfid rfid { get; set; }

        public ObservableCollection<Korisnik> KorisniciAdmin { get; set; }
        public Korisnik OdabraniKorisnik { get; set; }
        public static Korisnik Korisnik_iz_pocetne { get; set; }
        public static AdministratorView admin_view { get; set; }

        public INavigationService NavigationService { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public AdministratorViewModel(AdministratorView p)
        {
            NavigationService = new NavigationService();
            admin_view = p;
            KorisniciAdmin = new ObservableCollection<Korisnik>();
            KorisniciAdmin.Clear();

            using (var db = new KorisnikDbContext())
            {
                foreach (Korisnik k in db.Korisnici)
                {
                    if(k.KorisnikId!=Korisnik_iz_pocetne.KorisnikId)
                    KorisniciAdmin.Add(k);
                }
            }

            IzbrisiKorisnika = new RelayCommand<object>(izbrisiKorisnika);
            PostaviZaAdmina = new RelayCommand<object>(postaviZaAdmina);
            PrikaziDetaljeKorisnik = new RelayCommand<object>(prikaziDetaljeKorisnik);

            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);

        }


        public AdministratorViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();

            KorisniciAdmin = new ObservableCollection<Korisnik>();
            Korisnik_iz_pocetne = new Korisnik();
            Korisnik_iz_pocetne = parametar.Korisnik;


            using (var db = new KorisnikDbContext())
            {
                foreach (Korisnik k in db.Korisnici)
                {
                    if (k.KorisnikId != Korisnik_iz_pocetne.KorisnikId)
                        KorisniciAdmin.Add(k);
                }
            }

            IzbrisiKorisnika = new RelayCommand<object>(izbrisiKorisnika);
            PostaviZaAdmina = new RelayCommand<object>(postaviZaAdmina);
            PrikaziDetaljeKorisnik = new RelayCommand<object>(prikaziDetaljeKorisnik);

            rfid = new Rfid();
            rfid.InitializeReader(RfidReadSomething);
        }

        public async void izbrisiKorisnika(object parametar)
        {
            if(OdabraniKorisnik != null)
            {
                using (var db = new KorisnikDbContext())
                {
                    db.Korisnici.Remove(db.Korisnici.Where(x => x.KorisnikId == OdabraniKorisnik.KorisnikId).FirstOrDefault());
                    db.SaveChanges();
                    KorisniciAdmin.Clear();

                    using (var dbase = new KorisnikDbContext())
                    {
                        foreach (Korisnik k in dbase.Korisnici)
                        {
                            if (k.KorisnikId != Korisnik_iz_pocetne.KorisnikId)
                                KorisniciAdmin.Add(k);
                        }
                    }
                }

                    var dialog1 = new MessageDialog("Korisnik uspješno obrisan.");
                    await dialog1.ShowAsync();
                
            }
                else
            {
                var dialog1 = new MessageDialog("Niste oznacili korisnika.");
                await dialog1.ShowAsync();
            }

        }

        public void RfidReadSomething(string rfidKod)
        {
              RFID_txb = rfidKod;

        }

        public async void prikaziDetaljeKorisnik(object parametar)
        {
            if(OdabraniKorisnik != null)
            {
                PisiIme = OdabraniKorisnik.Ime;
                PisiPrezime = OdabraniKorisnik.Prezime;
                PisiMail = OdabraniKorisnik.Mail;
                PisiUserName = OdabraniKorisnik.Username;
                PisiDatumReg = OdabraniKorisnik.DatumRegistracije.ToString();

            }
            else
            {
                var dialog1 = new MessageDialog("Niste oznacili korisnika.");
                await dialog1.ShowAsync();
            }
        }

        public async void postaviZaAdmina(object parameter)
        {

            if(OdabraniKorisnik!=null)
            {
                if (OdabraniKorisnik.RFid.Equals(RFID_txb))
                {
                    OdabraniKorisnik.DalijeAdmin = true;
                    using (var db = new KorisnikDbContext())
                    {
                        db.Korisnici.Remove(db.Korisnici.Where(x => x.KorisnikId == OdabraniKorisnik.KorisnikId).FirstOrDefault());

                        db.SaveChanges();

                        db.Korisnici.Add(OdabraniKorisnik);
                        db.SaveChanges();
                    }
                }
                else
                {
                    var dialog11 = new MessageDialog("Unesite ispravan RFID.");
                    await dialog11.ShowAsync();
                }
            }
            else
            {
                var dialog1 = new MessageDialog("Niste oznacili korisnika.");
                await dialog1.ShowAsync();
            }

        }
    }
}