using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class KorisnikViewModel
    {
        public Korisnik Korisnik { get; set; }

        public bool JaSamAdmin { get; set; } //potrebno kad zeli neko ObrisatiKorisnika, to nije moguce ako osoba nije admin ;)

        public ICommand RegistrujKorisnika { get; set; }
        public ICommand LoginKorisnika { get; set; }
        public ICommand LogoutKorisnika { get; set; }
        public ICommand ObrisiKorisnika { get; set; }
        public object NavigationService { get; internal set; }

        //... jos dodat PregledSvihKorisnika




        public KorisnikViewModel()
        {


            //RegistrujKorisnika = new RelayCommand<object>(registrujKorisnika, true);
            //LoginKorisnika = new RelayCommand<object>(loginKorisnika, mozeLiSeLogoutKorisnik);
            // LoginKorisnika = new RelayCommand<object>(logoutKorisnika, mozeLiSeLoginKorisnik);
            // ObrisiKorisnika = new RelayCommand<object>(obrisiKorisnika, mozeLiSeObrisatiKorisnik);

            //mozda treba i sacuvaj izmjene u kolekciji hm... nakon dodavanja filma
            //IMA SMISLA TO ... BYBERNS
            // SacuvajIzmjene = new RelayCommand<object>(sacuvajIzmjene, zeliteLiSacuvatiIzmjene);
        }
    }
}
