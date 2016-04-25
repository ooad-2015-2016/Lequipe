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
        public int ocjenaId { get; set; }
        public string opis { get; set; }
        public int ocjena { get; set; }
    }
}
