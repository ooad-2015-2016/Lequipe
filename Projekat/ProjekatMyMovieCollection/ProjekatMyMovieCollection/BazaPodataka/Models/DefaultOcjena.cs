using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatMyMovieCollection.BazaPodataka.Models
{
    class DefaultOcjena
    {

        public static void Initialize(OcjenaDbContext context)
        {

            if (!context.Ocjene.Any())
            {
                context.Ocjene.AddRange(
                    new Ocjena()
                    {
                        opis = "extra",
                        ocjena = 5
                    }

                );
            }
            context.SaveChanges();
        }
    }
}
