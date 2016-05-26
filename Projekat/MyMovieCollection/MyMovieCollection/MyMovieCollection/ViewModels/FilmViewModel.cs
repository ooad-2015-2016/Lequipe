using MyMovieCollection.MyMovieCollection.Helper;
using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class FilmViewModel
    {
        public Film OdabraniFilm { get; set; }
        public Korisnik Korisnik { get; set; }
        

        public string   NazivFilma_txb { get; set; }

        public ICollection<Film> FilmoviNet { get; set; }


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

        public FilmViewModel()
        {
            NavigationService = new NavigationService();
            
            NazivFilma_txb= "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);

        }

        public FilmViewModel(PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();

            Korisnik = parametar.Korisnik;

            NazivFilma_txb = "";

            Search = new RelayCommand<object>(search);
            DodajFilm = new RelayCommand<object>(dodajFilm);

        }

        private void search(object parametar)
        {
            //svaki put kad se pritisne dugme izbrise se trenutna lista fimova od prthodne pretrage i listbox
            FilmoviNet.Clear();
            //ASP.net
            //search na netu film iz textbox-a
            //zatim ide dodavanje u listu FilmoviNet
            //

        }
        private void dodajFilm(object parametar)
        {
            // ovdje bi program vec trebao da zna ko je korinik
            //potrebno je film iz listboxa koji je oznacen stavit u OdabraniFilm
           // OdabraniFilm=FilmoviNet.
         //  OdabraniFilm film= new Film( IDictionary, naziv,...., Korisnik.KorisnikId, KolekcijaUKojuSeDodajeFilm.KolekcijaId)
          
            using (var db = new MovieCollectionDbContext())
            {

                db.Filmovi.Add(OdabraniFilm);
            }

            //obavjestenje da je uspjesno dodano
        }


        }
}
