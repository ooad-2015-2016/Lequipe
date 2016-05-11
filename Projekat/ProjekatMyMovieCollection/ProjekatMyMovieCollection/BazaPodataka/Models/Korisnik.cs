using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int korisnikId { get; set; }
        public string mail { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public byte[] slika { get; set; }
        public string sifra { get; set; }
        public float ocjenaAp { get; set; }
        public DateTime datumRodjenja { get; set; }
        public DateTime datumRegistracije { get; set; }
        //treba dodat listuKolekcija
    }
}
