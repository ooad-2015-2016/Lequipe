using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class Kolekcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kolekcijaId { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
    }
}
