using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class Kolekcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KolekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        
        public byte[] slika { get; set; }
        public Kolekcija()
        { }
        public Kolekcija(int id)
        { KolekcijaId = id;
            
        }

    }
}
