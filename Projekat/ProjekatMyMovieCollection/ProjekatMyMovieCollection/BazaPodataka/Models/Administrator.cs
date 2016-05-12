using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    //Podaci o administratoru.. posljednji atribut - dozvoljava se da i admin vodi sopstveni dnevnik filmova, posjeduje kolekciju filmova...
    class Administrator
    {
        public int AdminID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Sifra { get; set; }
        public List<Kolekcija> KolekcijeAdmin { get; set; }
    }
}
