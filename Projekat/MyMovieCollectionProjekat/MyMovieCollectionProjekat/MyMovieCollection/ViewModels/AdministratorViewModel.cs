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

namespace MyMovieCollectionProjekat.MyMovieCollection.ViewModels
{
    class AdministratorViewModel
    {
        //ListBox vidjeti 
        //prkazi detalje dugme impl
        
        public ICommand IzbrisiKorisnika { get; set; }
        public ICommand PostaviZaAdmina { get; set; }
        public ICommand PrikaziDetaljeKorisnik { get; set; }
        public PocetnaViewModel Parent { get; set; }
        public string PisiIme { get; set; }
        public string PisiMail { get; set; }
        public string PisiPrezime { get; set; }
        public string PisiUserName { get; set; }
        public string PisiDatumReg { get; set; }


        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public Korisnik OdabraniKorisnik { get; set; }


        public INavigationService NavigationService { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public AdministratorViewModel()
        {
            NavigationService = new NavigationService();

            Korisnici = new ObservableCollection<Korisnik>();
            Korisnici.Clear();

            using (var db = new KorisnikDbContext())
            {
                foreach (Korisnik k in db.Korisnici)
                {
                    Korisnici.Add(k);
                }
            }

            IzbrisiKorisnika = new RelayCommand<object>(izbrisiKorisnika);
            PostaviZaAdmina = new RelayCommand<object>(postaviZaAdmina);
            PrikaziDetaljeKorisnik = new RelayCommand<object>(prikaziDetaljeKorisnik);


        }


        public AdministratorViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            
            Korisnici = new ObservableCollection<Korisnik>();

            
            using (var db = new KorisnikDbContext())
            {
                foreach (Korisnik k in db.Korisnici)
                {
                    Korisnici.Add(k);
                }
            }

            IzbrisiKorisnika = new RelayCommand<object>(izbrisiKorisnika);
            PostaviZaAdmina = new RelayCommand<object>(postaviZaAdmina);
            PrikaziDetaljeKorisnik = new RelayCommand<object>(prikaziDetaljeKorisnik);
        }

        public async void izbrisiKorisnika(object parametar)
        {
            if(OdabraniKorisnik != null)
            {
                using (var db = new KorisnikDbContext())
                {
                    db.Korisnici.Remove(db.Korisnici.Where(x => x.KorisnikId == OdabraniKorisnik.KorisnikId).FirstOrDefault());
                    db.SaveChanges();

                    Korisnici.Clear();

                    using (var dbase = new KorisnikDbContext())
                    {
                        foreach (Korisnik k in dbase.Korisnici)
                        {
                            Korisnici.Add(k);
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

        public void postaviZaAdmina(object parameter)
        {

        }




    }
}
