using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class DefaultKolekcija
    {

        public static void Initialize(KolekcijaDbContext context)
        {


            if (!context.Kolekcije.Any())
            {
                context.Kolekcije.AddRange(
                    new Kolekcija()
                    {
                        naziv = "n",
                        opis = "beze"
                    }

                );
            }
            context.SaveChanges();

          
    }
 }
}
