using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovieCollectionProjekat.MyMovieCollection.Models
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

        public Ocjena()
        { }

        public Ocjena(int id)
        { OcjenaID = id; }
    }

}

