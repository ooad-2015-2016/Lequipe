using MyMovieCollection.MyMovieCollection.Helper;
using MyMovieCollection.MyMovieCollection.Models;
using MyMovieCollection.MyMovieCollection.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class AdministratorViewModel
    {
        public Korisnik Korisnik = new Korisnik();

      /*  public ICommand Nazad { get; set; }


        private void nazad(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel(this));
        }
        */
    }
}
