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

        public ObservableCollection<Film> MojiFilmoviIzKolekcije{ get; set; }
        public Film OdabraniFilm { get; set; }


        public new string Naziv { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand DodajKolekciju { get; set; }
        public ICommand IzbrisiKolekciju { get; set; }
        public ICommand SacuvajKolekciju { get; set; }
        public ICommand PrikaziDetalje { get; set; }
        public ICommand PrikaziFilmove { get; set; }



      /*  //        ___________________

        public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();
        //______________

        */

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
            MojiFilmoviIzKolekcije = new ObservableCollection<Film>();


            Naziv = "";

            MojeKolekcije.Clear(); 
             using  (var db = new KolekcijaDbContext())
             {
                 foreach (Kolekcija k in db.Kolekcije)
                 {
                     if(k.KorisnikId==korisnik.KorisnikId)
                     MojeKolekcije.Add(k);
                 }
             }
       
            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);
            SacuvajKolekciju = new RelayCommand<object>(sacuvajKolekciju);
            PrikaziDetalje = new RelayCommand<object>(prikaziDetalje);
            PrikaziFilmove = new RelayCommand<object>(prikaziFilmove);



        }

        public KolekcijaViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = parametar.Korisnik;
            MojeKolekcije = new ObservableCollection<Kolekcija>();
            MojiFilmoviIzKolekcije = new ObservableCollection<Film>();

            Naziv = "";

           using  (var db = new KolekcijaDbContext())
           {
               foreach (Kolekcija k in db.Kolekcije)
               {
                   if(k.KorisnikId==korisnik.KorisnikId)
                   MojeKolekcije.Add(k);
               }
           }
           



            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);
          


        }

        private void dodajKolekciju(object parametar)
        {

        }

        private async void sacuvajKolekciju(object parametar)
        {
            int max = -1;
            using (var db = new KolekcijaDbContext())
            {
                foreach (Kolekcija k in db.Kolekcije)
                {
                    if (k.KolekcijaId > max) max = k.KolekcijaId;
                }

                max++;

                kolekcija = new Kolekcija(max);
                kolekcija.Naziv = Naziv;
                var dialog12 = new MessageDialog(Naziv);
                await dialog12.ShowAsync();

                kolekcija.KorisnikId = korisnik.KorisnikId;

                MojeKolekcije.Add(kolekcija);
                db.Kolekcije.Add(kolekcija);
                db.SaveChanges();


            }

         
            var dialog1 = new MessageDialog(MojeKolekcije.Count().ToString());
            await dialog1.ShowAsync();


        }

        private async void izbrisiKolekciju(object parametar)
        {
            if (OdabranaKolekcija != null)// && OdabranaKolekcija.Naziv!="")
            {
                using (var db = new KolekcijaDbContext())
                {

                   // MojeKolekcije.Remove(db.Kolekcije.Where(x =>  x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());
                    db.Kolekcije.Remove(db.Kolekcije.Where(x => x.KorisnikId == korisnik.KorisnikId && x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());
                    db.SaveChanges();

                    MojeKolekcije.Clear();
                    foreach (Kolekcija k in db.Kolekcije)
                    {
                        if (k.KorisnikId == korisnik.KorisnikId)
                            MojeKolekcije.Add(k);
                    }

                }

                    var dialog1 = new MessageDialog("Kolekcija uspješno obrisana.");
                await dialog1.ShowAsync();
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

        private void prikaziDetalje(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }

        private async void prikaziFilmove(object parametar)
        {

            if (OdabranaKolekcija != null)
            {
                using (var db = new FilmDbContext())
                {

                    if(MojiFilmoviIzKolekcije.Count()!=0) MojiFilmoviIzKolekcije.Clear();
                    foreach (Film k in db.Filmovi)
                    {
                        if (k.KolekcijaId == OdabranaKolekcija.KolekcijaId)
                            MojiFilmoviIzKolekcije.Add(k);
                    }

                }
            }
            else
            {
                var dialog11 = new MessageDialog("Niste oznacili kolekciju.");
                await dialog11.ShowAsync();
            }
        }




        public ObservableCollection<Kolekcija> DajsveMojeKolekcije()
        {
            return MojeKolekcije;

        }

    }

}
