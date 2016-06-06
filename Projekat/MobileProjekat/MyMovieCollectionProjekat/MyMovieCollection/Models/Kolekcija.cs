using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovieCollectionProjekat.MyMovieCollection.Models
{
    class Kolekcija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KolekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public byte[] slika { get; set; }
        public Kolekcija()
        { }
        public Kolekcija(int id)
        {
            KolekcijaId = id;

        }

        public Kolekcija(int k, int K, string naziv)
        {
            KolekcijaId = k;
            KorisnikId = K;
            Naziv = naziv;
        }
    }
}
