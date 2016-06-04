using MyMovieCollection.MyMovieCollection.Services;
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
    class FilmViewModel
    {
        public Film OdabraniFilm { get; set; }
        public Korisnik Korisnik { get; set; }


        public string NazivFilma_txb { get; set; }

        public ObservableCollection<Film> FilmoviNet { get; set; }
        public ObservableCollection<Kolekcija> MojeKolekcije { get; set; }
        public Kolekcija OdabranaKolekcija { get; set; }

        public INavigationService NavigationService { get; set; }
        public Kolekcija KolekcijaUKojuSeDodajeFilm { get; set; }
        public int OcjenaFilma { get; set; }
        public ICommand Search { get; set; }
        public ICommand DodajFilm { get; set; }
       

        //        ___________________

      /*  public ObservableCollection<Korisnik> SviKorisnici = new ObservableCollection<Korisnik>();
        public ObservableCollection<Kolekcija> SveKolekcije = new ObservableCollection<Kolekcija>();
        public ObservableCollection<Film> SviFilmovi = new ObservableCollection<Film>();
        public ObservableCollection<Ocjena> SveOcjene = new ObservableCollection<Ocjena>();
        //______________*/



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public FilmViewModel()
        {
            NavigationService = new NavigationService();
            Korisnik = new Korisnik();

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

                foreach(Film fl in f.Filmovi)
                FilmoviNet.Add(fl);
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
                //prvo oznacite filmi/ili kolekciju
            }
        }

        


    }
}
