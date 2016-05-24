using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; } //korisnicko ime bi nam trebalo...
        public string Spol { get; set; }
        public string Username { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public byte[] slika { get; set; }
        public string Sifra { get; set; }
        public float OcjenaAplikacije { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public bool DalijeAdmin { get; set; }
       
    }
}
