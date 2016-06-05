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
    class KolekcijaViewModel
    {
        public Korisnik korisnik { get; set; }
        public static Korisnik korisnik_iz_pocetne { get; set; }
        public static KolekcijaView kol_view { get; set; }
        public Kolekcija kolekcija { get; set; }


        public ObservableCollection<Kolekcija> MojeKolekcije { get; set; }
        public Kolekcija OdabranaKolekcija { get; set; }

        public ObservableCollection<Film> MojiFilmoviIzKolekcije{ get; set; }
        public Film OdabraniFilm { get; set; }


        public string Naziv { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand DodajKolekciju { get; set; }
        public ICommand IzbrisiKolekciju { get; set; }
        public ICommand SacuvajKolekciju { get; set; }
        public ICommand PrikaziDetalje { get; set; }
        public ICommand PrikaziFilmove { get; set; }
        public ICommand IzbrisiFilm { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
           PropertyChanged(this, new PropertyChangedEventArgs(info));            
        }

        public KolekcijaViewModel(KolekcijaView parametar)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();
            korisnik = korisnik_iz_pocetne;
            if (korisnik_iz_pocetne != null) { var dialog11 = new MessageDialog("pozivas li se katkad" + korisnik.KorisnikId.ToString());
                dialog11.ShowAsync(); }

            MojeKolekcije = new ObservableCollection<Kolekcija>();
            MojiFilmoviIzKolekcije = new ObservableCollection<Film>();

            kol_view = parametar;

            Naziv = "";

            MojeKolekcije.Clear(); 
             using  (var db = new KolekcijaDbContext())
             {
                 foreach (Kolekcija k in db.Kolekcije)
                 {
                     if(k.KorisnikId == korisnik.KorisnikId)
                     MojeKolekcije.Add(k);
                 }
             }
            
            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);
            SacuvajKolekciju = new RelayCommand<object>(sacuvajKolekciju);
            PrikaziDetalje = new RelayCommand<object>(prikaziDetalje);
            PrikaziFilmove = new RelayCommand<object>(prikaziFilmove);
            IzbrisiFilm = new RelayCommand<object>(izbrisiFilm);

        }

        public  KolekcijaViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = parametar.Korisnik;
            korisnik_iz_pocetne = parametar.Korisnik;


            var dialog11 = new MessageDialog("staticki: " + korisnik_iz_pocetne.KorisnikId.ToString() + " obicni kor: " + korisnik.KorisnikId.ToString());
            dialog11.ShowAsync();


            if (kol_view != null) kol_view.DataContext = new KolekcijaViewModel(kol_view);


            MojeKolekcije = new ObservableCollection<Kolekcija>();
            MojiFilmoviIzKolekcije = new ObservableCollection<Film>();

            Naziv = "";

            MojeKolekcije.Clear();

            using  (var db = new KolekcijaDbContext())
            {
                foreach (Kolekcija k in db.Kolekcije)
                {
                     if (k.KorisnikId == korisnik.KorisnikId)
                     {
                         MojeKolekcije.Add(k);                         
                     }
                }
            }


            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);
          
        }

        private void dodajKolekciju(object parametar)
        {
            var dialog11 = new MessageDialog(korisnik.KorisnikId.ToString());
            dialog11.ShowAsync();
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

                var dialog11 = new MessageDialog(korisnik.KorisnikId.ToString());
                await dialog11.ShowAsync();

                kolekcija = new Kolekcija();
                kolekcija.KorisnikId = max;
                kolekcija.Naziv = Naziv;
                

                kolekcija.KorisnikId = korisnik.KorisnikId;

                MojeKolekcije.Add(kolekcija);
                db.Kolekcije.Add(kolekcija);
                db.SaveChanges();

            }
                 
            var dialog1 = new MessageDialog("Kolekcija sacuvana");
            await dialog1.ShowAsync();
            Naziv = "";

        }

        private async void izbrisiKolekciju(object parametar)
        {
            if (OdabranaKolekcija != null)// && OdabranaKolekcija.Naziv!="")
            {

                using (var db = new FilmDbContext())
                {
                    for (int i = 0; i < MojiFilmoviIzKolekcije.Count; i++)
                        db.Filmovi.Remove(db.Filmovi.Where(x => x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());
                    db.SaveChanges();
                }
                MojiFilmoviIzKolekcije.Clear();  

                using (var db = new KolekcijaDbContext())
                {

                   
                    db.Kolekcije.Remove(db.Kolekcije.Where(x => x.KorisnikId == korisnik.KorisnikId && x.KolekcijaId == OdabranaKolekcija.KolekcijaId).FirstOrDefault());
                  
                    db.SaveChanges();

                    MojeKolekcije.Clear();
                   // MojiFilmoviIzKolekcije.Clear();
                    
                    foreach (Kolekcija k in db.Kolekcije)
                    {
                        if (k.KorisnikId == korisnik.KorisnikId)
                        {
                            MojeKolekcije.Add(k);
                            var dialog11 = new MessageDialog(k.KorisnikId.ToString() + " " + korisnik.KorisnikId.ToString());
                            await dialog11.ShowAsync();
                        }
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

        private void izbrisiFilm(object parametar)
        {
            int kolekcijaID = OdabraniFilm.KolekcijaId;

            if (OdabraniFilm != null)
            {
                using (var db = new FilmDbContext())
                {
                    db.Filmovi.Remove(db.Filmovi.Where(x => x.FilmId == OdabraniFilm.FilmId).FirstOrDefault());
                    db.SaveChanges();
                }

                using (var db = new FilmDbContext())
                { 
                    MojiFilmoviIzKolekcije.Clear();
                    foreach (Film k in db.Filmovi)
                    {
                        if (k.KolekcijaId == kolekcijaID)
                            MojiFilmoviIzKolekcije.Add(k);
                    }
                }
            }
            else
            {
                //nije obrisano
            }
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