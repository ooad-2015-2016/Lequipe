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
    class KolekcijaViewModel
    {
        public Korisnik korisnik { get; set; }
        public Kolekcija kolekcija { get; set; }


        public ObservableCollection<Kolekcija> MojeKolekcije { get; set; }
        public Kolekcija OdabranaKolekcija { get; set; }



        public string Naziv { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand DodajKolekciju { get; set; }
        public ICommand IzbrisiKolekciju { get; set; }
        public ICommand SacuvajKolekciju { get; set; }



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
        public KolekcijaViewModel()
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();

            MojeKolekcije = new ObservableCollection<Kolekcija>();

            Naziv = "";

            /*MojeKolekcije.Clear(); //aBd kad baza proradi
             using  (var db = new MovieCollectionDbContext())
             {
                 foreach (Kolekcija k in db.Kolekcije)
                 {
                     if(k.KorisnikId==korisnik.KorisnikId)
                     MojeKolekcije.Add(k);
                 }
             }
             */

            //dok se ne doda baza...
            foreach (Kolekcija k in DataSourceMyMovieCollection.DajSveKolekcije())
            {
                if (k.KorisnikId == korisnik.KorisnikId)
                    MojeKolekcije.Add(k);
            }

            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);
            SacuvajKolekciju = new RelayCommand<object>(sacuvajKolekciju);


        }

        public KolekcijaViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = parametar.Korisnik;
            MojeKolekcije = new ObservableCollection<Kolekcija>();

            Naziv = "";

            /*MojeKolekcije.Clear(); //aBd kad baza proradi
           using  (var db = new MovieCollectionDbContext())
           {
               foreach (Kolekcija k in db.Kolekcije)
               {
                   if(k.KorisnikId==korisnik.KorisnikId)
                   MojeKolekcije.Add(k);
               }
           }
           */

            //dok se ne doda baza...
            /* foreach (Kolekcija k in DataSourceMyMovieCollection.DajSveKolekcije())
             {
                 if (k.KorisnikId == korisnik.KorisnikId)
                     MojeKolekcije.Add(k);
             }
             */



            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);


            SviFilmovi = parametar.SviFilmovi;
            SviKorisnici = parametar.SviKorisnici;
            SveKolekcije = parametar.SveKolekcije;
            SviFilmovi = parametar.SviFilmovi;
            SveOcjene = parametar.SveOcjene;

            List<Kolekcija> kolekcije = SveKolekcije.ToList<Kolekcija>();
            foreach (Kolekcija k in kolekcije)
            {
                if (k.KorisnikId == korisnik.KorisnikId)
                    MojeKolekcije.Add(k);
            }


        }

        private void dodajKolekciju(object parametar)
        {

        }

        private async void sacuvajKolekciju(object parametar)
        {
            int max = -1;
            foreach (Kolekcija k in DataSourceMyMovieCollection.DajSveKolekcije())
            {
                if (k.KolekcijaId > max) max = k.KolekcijaId;
            }
            max++;

            kolekcija = new Kolekcija(max);
            kolekcija.Naziv = Naziv;
            kolekcija.KorisnikId = korisnik.KorisnikId;

            SveKolekcije.Add(kolekcija);

            MojeKolekcije.Add(kolekcija);



            var dialog1 = new MessageDialog(MojeKolekcije.Count().ToString());
            await dialog1.ShowAsync();


        }

        private async void izbrisiKolekciju(object parametar)
        {
            if (OdabranaKolekcija != null)
            {
                MojeKolekcije.Remove(SveKolekcije.Where(x => x.KorisnikId == korisnik.KorisnikId && x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());
                SveKolekcije.Remove(SveKolekcije.Where(x => x.KorisnikId == korisnik.KorisnikId && x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());

            }
            else
            {
                var dialog1 = new MessageDialog("Niste oznacili kolekciju.");
                await dialog1.ShowAsync();
            }

        }

        private void nazad(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }



        public ObservableCollection<Kolekcija> DajsveMojeKolekcije()
        {
            return MojeKolekcije;

        }

    }

}
