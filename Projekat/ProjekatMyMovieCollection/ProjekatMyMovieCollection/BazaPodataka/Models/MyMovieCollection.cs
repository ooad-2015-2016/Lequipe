using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class MyMovieCollection
    {
        public List<Korisnik> Korisnici { get; set; }
        public List<Film> Filmovi { get; set; }
        public double ProsjecnaOcjena { get; set; } //prosjecna ocjena aplikacije...
        public List<Administrator> Administratori { get; set; }
        //Nisam skontala atribut poruke administratorima, al evo stavit cu ga --byberns
        // public List<String> PorukeAdministratorima { get; set; }
    }
}
