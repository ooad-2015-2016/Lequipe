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
    class KolekcijaViewModel
    {
        public Korisnik korisnik { get; set; }
        public Kolekcija kolekcija { get; set; }

        public string Naziv { get; set; }
        

        public INavigationService NavigationService { get; set; }
        public ICommand DodajKolekciju { get; set; }
        public ICommand IzbrisiKolekciju { get; set; }
        public ICommand PrikaziKolekciju { get; set; } //event je na kliku na combobox


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public KolekcijaViewModel (PocetnaViewModel parametar)
        {
            NavigationService = new NavigationService();
            korisnik = new Korisnik();
            Naziv= "";
           
            DodajKolekciju = new RelayCommand<object>(dodajKolekciju);
            IzbrisiKolekciju = new RelayCommand<object>(izbrisiKolekciju);

        }

        private void dodajKolekciju(object parametar)
        {
           //potrebno je visible postavit dvije stvari Naziv i onaj textbox u koji se upisuje
        }

        private void izbrisiKolekciju(object parametar)
        {
            //MessageBox da li zeli izbrisati

        }


    }
}
