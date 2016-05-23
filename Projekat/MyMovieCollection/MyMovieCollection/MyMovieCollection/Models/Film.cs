using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }
        public string Naziv { get; set; }
        public double ProsjecnaOcjena { get; set; } //obrisali smo atribut ocjena, koji i ne treba, nema ga ni na dijagramu klasa...
        public string Opis { get; set; }
        public DateTime Godina { get; set; }
       // public List<Ocjena> Ocjene { get; set; } //Dodan atribut lista ocjena, nismo ga na dijagramu stavili
        public byte[] slika { get; set; }
        public int KorisnikId { get; set; }
        public int KolekcijaId { get; set; }
    }
}
