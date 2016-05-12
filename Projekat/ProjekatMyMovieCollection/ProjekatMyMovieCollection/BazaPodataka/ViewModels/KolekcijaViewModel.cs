using ProjekatMyMovieCollection.BazaPodataka.Helper;
using ProjekatMyMovieCollection.BazaPodataka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.ViewModels
{
    class KolekcijaViewModel
    {
        public KorisnikViewModel Parent { get; set; } //pocetna 
        public Kolekcija Kolekcija { get; set; } //ovo se dodaje kasnije u Parent.listaFilmova
        public INavigationService NavigationService { get; set; } //za prelazak na druge forme

        //haman viška ili ipak ne?
        public string naziv { get; set; } //a zasto ce mi ovaj atribut kad imam atribut Kolekcija u koji cu smjestit naziv??
        public string opis { get; set; } //a zasto ce mi ovaj atribut kad imam atribut Kolekcija u koji cu smjestit opis??
        //a pa cici ne treba ti, nema ni na MVVM dijagramu, PAJEL?! --byberns


        public ICommand DodajKolekciju { get; set; }
        public ICommand ObrisiKolekciju { get; set; }
        //mozda da napravimo staticke kolekcije, kad se napravi ne moze se mjenjat, al time ovo dvoje ispod gubi smisao
        public ICommand DodajFilm { get; set; } //kao opcija- nisam sigurna da li cemo ovo imat kao i ovo ispod
        public ICommand ObrisiFilm { get; set; }  //iz ovog razloga ce se u FilmViewModel kolekcija da bude parent, jer se iz nje poziva film



        public KolekcijaViewModel(KorisnikViewModel parent)
        {
            this.Parent = parent;
            Kolekcija = new Kolekcija();
            NavigationService = new NavigationService();
            //prvi parametar funkcija koja se pozove na klik a druga funkcija koja testira da li se treba pozvati komanda
            DodajKolekciju= new RelayCommand<object>(dodajKolekciju, mozeLiSeDodatiKolekcija);
            ObrisiKolekciju = new RelayCommand<object>(ObrisiKolekciju, mozeLiSeObrisatiKolekcija);
            DodajFilm = new RelayCommand<object>(dodajFilm, mozeLiSeDodatiFilm);
            ObrisiFilm = new RelayCommand<object>(ObrisiFilm, mozeLiSeObrisatiFilm);

            //mozda treba i sacuvaj izmjene u kolekciji hm... nakon dodavanja filma
            //IMA SMISLA TO ... BYBERNS
            SacuvajIzmjene = new RelayCommand<object>(sacuvajIzmjene, zeliteLiSacuvatiIzmjene);
        }

        public bool mozeLiSeDodatiKolekcija(object parametar)
        {
            //ovdje se moze dodati uslov ako je potrebno da se komanda ne izvrsi
            return true;
        }

        public void dodavanjeKolekcije(object parametar)
        {
            //glavna forma ce biti login odnosno korisnik kad se loguje
            //nakon toga ako zeli dodati kolekciju prelazi sa Navigated na KolekcijaViewModel
            Parent.Korisnik.ListaKolekcija.Add(Kolekcija); //listaKolekcija svaki korisnik je ima
            //go back koristi navigation service da se vrati nazad
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiSeObrisatiiKolekcija(object parametar)
        {
            //bilo bi dobro dodati neki MessageBox koji trazi potvrdu
            return true;
        }

        public void brisanjeKolekcije(object parametar)
        {
            //pretpostavljam da se poveze  s bazom...
            
            Parent.NavigationService.GoBack();
        }

        public bool mozeLiSeDodatiFilm(object parametar)
        {
            return true;
        }

        public void dodajFilm(object parametar)
        {
            //da bi dodali film mora preci na novu forum Film
            NavigationService.Navigate(typeof(FilmViewModel), new FilmViewModel(this));
        }

        public bool mozeLiSeObrisatiFilm(object parametar)
        {
            //bilo bi dobro dodati neki MessageBox koji trazi potvrdu
            return true;
        }

        public void obrisiFilm(object parametar)
        {
            //da bi dodali film mora preci na novu forum Film
            NavigationService.Navigate(typeof(FilmViewModel), new FilmViewModel(this));
        }
    }
    
}
