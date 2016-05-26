using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class PocetnaViewModel
    {
        public Korisnik Korisnik;
        public PocetnaViewModel()
        {

        }

        public PocetnaViewModel(LoginViewModel parametar)
        {
            Korisnik = parametar.korisnik;

        }
    }
}
