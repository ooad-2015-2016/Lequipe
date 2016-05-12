using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class Ocjena
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmID { get; set; }
        public int KorisnikID { get; set; } //ID korisnika koji je stavio datu ocjenu... --by berns
        public string Opis { get; set; } //Nisam sigurna za šta će nam ovaj opis.. --by berns
        public int Ocjena { get; set; }
    }
}
