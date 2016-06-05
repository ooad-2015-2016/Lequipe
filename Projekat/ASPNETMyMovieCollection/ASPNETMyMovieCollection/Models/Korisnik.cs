using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETMyMovieCollection.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
    }
}