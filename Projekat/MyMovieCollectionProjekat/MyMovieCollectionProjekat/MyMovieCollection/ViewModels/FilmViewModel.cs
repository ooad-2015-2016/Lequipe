using MyMovieCollection.MyMovieCollection.Services;
using MyMovieCollection.MyMovieCollection.Views;
using MyMovieCollectionProjekat.MyMovieCollection.Helper;
using MyMovieCollectionProjekat.MyMovieCollection.Models;
using MyMovieCollectionProjekat.MyMovieCollection.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class FilmViewModel: INotifyPropertyChanged
    {
        public Film OdabraniFilm { get; set; }
        public  Korisnik Korisnik { get; set; }
        public string NazivFilma_txb { get; set; }

        public ObservableCollection<Film> FilmoviNet { get; set; }
        public ObservableCollection<Kolekcija> MojeKolekcije { get; set; }
        public Kolekcija OdabranaKolekcija { get; set; }
        public static Korisnik Korisnik_iz_pocetne { get; set; }
        public static FilmView film_view { get; set; }

        public INavigationService NavigationService { get; set; }
        public Kolekcija KolekcijaUKojuSeDodajeFilm { get; set; }
        public int OcjenaFilma { get; set; }
        public ICommand Search { get; set; }
        public ICommand DodajFilm { get; set; }
       


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public FilmViewModel(FilmView p)
        {
            NavigationService = new NavigationService();
            Korisnik = new Korisnik();
            Korisnik = Korisnik_iz_pocetne;
            film_view = p;

            NazivFilma_txb = "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);
           

            FilmoviNet = new ObservableCollection<Film>();
            MojeKolekcije = new ObservableCollection<Kolekcija>();

           
            using (var db = new KolekcijaDbContext())
            {
                foreach (Kolekcija k in db.Kolekcije)
                {
                    if (k.KorisnikId == Korisnik.KorisnikId)
                        MojeKolekcije.Add(k);
                }
            }
        }

        public FilmViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            MojeKolekcije = new ObservableCollection<Kolekcija>();
            FilmoviNet = new ObservableCollection<Film>();
            Korisnik = new Korisnik();
            Korisnik_iz_pocetne= parametar.Korisnik;
            Korisnik = parametar.Korisnik;

            NazivFilma_txb = "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);

            using (var db = new KolekcijaDbContext())
            {
                foreach (Kolekcija k in db.Kolekcije)
                {
                    if (k.KorisnikId == Korisnik.KorisnikId)
                        MojeKolekcije.Add(k);
                }
            }
        }

        private async void search(object parametar)
        {
            try
            {
                FilmoviNet.Clear();
                FilmoviService f = new FilmoviService();
                await f.getFilmovi(NazivFilma_txb);


                foreach (Film fl in f.Filmovi)
                {
                    FilmoviNet.Add(fl);
                    if (FilmoviNet.Count > 12) break;
                }

                
            }
            catch(Exception e)
                { }
         

            
            
        }

        private async void dodajFilm(object parametar)
        {
            
         if(OdabraniFilm!=null && OdabranaKolekcija!=null)
            {
                using (var db = new FilmDbContext())
                {
                    int max = -1;
                    foreach (Film k in db.Filmovi)
                    {
                        if (k.FilmId > max) max = k.FilmId;
                    }
                    max++;

                    Film novi = new Film(max);
                    novi = OdabraniFilm;
                    novi.FilmId = max;
                    novi.KolekcijaId = OdabranaKolekcija.KolekcijaId;
                    novi.KorisnikId = Korisnik.KorisnikId;

                    db.Filmovi.Add(novi);
                    db.SaveChanges();
                }

                var dialog = new MessageDialog("Film uspjesno sacuvan");
                await dialog.ShowAsync();

            }
            else
            {
                var dialog = new MessageDialog("Oznacite film ili kolekciju.");
                await dialog.ShowAsync();
            }
        }

        


    }
}
