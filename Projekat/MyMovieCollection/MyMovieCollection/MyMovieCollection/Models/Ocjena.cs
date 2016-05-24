using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovieCollection.MyMovieCollection.Models
{
    class Ocjena
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OcjenaID { get; set; }
        public int FilmID { get; set; }
        public int KorisnikID { get; set; }
        public int KolekcijaID { get; set; }
        public string Opis { get; set; } 
        public int ocjena { get; set; }
    }
}
