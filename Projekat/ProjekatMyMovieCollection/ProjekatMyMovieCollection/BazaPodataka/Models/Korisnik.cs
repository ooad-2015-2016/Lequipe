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
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public byte[] Slika { get; set; }
        public string Sifra { get; set; }
        public float OcjenaAplikacije { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public List<Kolekcija> ListaKolekcija { get; set; }
    }
}
