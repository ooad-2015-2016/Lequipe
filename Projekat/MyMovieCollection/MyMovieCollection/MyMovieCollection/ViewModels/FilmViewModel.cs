using MyMovieCollection.MyMovieCollection.Helper;
using MyMovieCollection.MyMovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyMovieCollection.MyMovieCollection.ViewModels
{
    class FilmViewModel
    {
        public KolekcijaViewModel Parent1 { get; set; }
        public KorisnikViewModel Parent { get; set; }
        public INavigationService NavigationService { get; set; }

        public Film film { get; set; }
        //nije mi jasno gdje dodati atribut kojim korisnik ocjenjuje neki film, jedino bi
        //mozda moglo u neku Kolekciju OCJENJENO (koja se stvara prvi put kad ocjeni i
        //koja se ne moze brisat niti mjenjat), pa da imamo listu filmova i listu ocjena,
        //gdje su na istim indeksima ocjena i taj film --by amra

        //evo razrijesile smo, ne treba kolekcija, svaki film ima listu ocjena, svaka ocjena ID, i provjerimo
        //samo jel za taj i taj ID filma i Korisnika ocjena u listi, ako nije, onda korisnik ima pravo da ocjenjuje u suprotnom moze da mijenja ocjenu..


        public ICommand Dodaj { get; set; }
        public ICommand Obrisi { get; set; }
        public ICommand Ocjeni { get; set; }

        public FilmViewModel(KolekcijaViewModel parent1, KorisnikViewModel parent)
        {
            // this.Parent = parent.Korisnici.parent1; //stvarno nisam sigurna da li vako ide...
            film = new Film();
            NavigationService = new NavigationService();
            //prvi parametar funkcija koja se pozove na klik a druga funkcija koja testira da li se treba pozvati komanda
            // Dodaj = new RelayCommand<object>(dodaj, mozeLiSeDodati);

            //fali jos sutra nastavak
        }

        public bool mozeLiSeDodati(object parametar)
        {
            //ovdje se moze dodati uslov ako je potrebno da se komanda ne izvrsi
            return true;
        }

        public void dodaj(object parametar)
        {

            // Parent.Korisnici.Parent1.Kolekcije.filmovi.Add(film); 
            //ovo bi trebalo da doda film u kolekciju a zatim se vrati nazad i sacuva izmjenjenu kolekciju- postoji "jeftinije" rjesenje sigurno
            Parent1.NavigationService.GoBack();
        }
    }
}
