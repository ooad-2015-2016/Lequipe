using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class Film
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int filmId { get; set; }
        public string naziv { get; set; }
        public double prosjecnaOcjena { get; set; }
        public string opis { get; set; }
        public DateTime godinaFilma { get; set; }

    }
}
