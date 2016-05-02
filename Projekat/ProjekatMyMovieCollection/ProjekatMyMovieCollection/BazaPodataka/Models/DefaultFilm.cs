using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class DefaultFilm
    {

        public static void Initialize(FilmDbContext context)
        {

            if (!context.Filmovi.Any())
            {
                context.Filmovi.AddRange(
                    new Film()
                    {
                        naziv = "n",
                        opis = "beze",
                        prosjecnaOcjena = 0

                    }
                );
            }
            context.SaveChanges();

        }
    
}
}
