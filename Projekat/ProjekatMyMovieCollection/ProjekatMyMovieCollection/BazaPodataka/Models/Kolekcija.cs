using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    //Klasa Kolekcija je klasa koja predstavlja kolekciju filmova za odgovarajuceg korisnika. Obzirom da svaki objekt klase Kolekcija
    //ima svoj ID, time svaki korisnik ima jedinstvene kolekcije.. Za kolekciju se mora znati ko joj je vlasnik(KorisnikID)...
    class Kolekcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KolekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public List<Film> Filmovi { get; set; }
        
    }
}
