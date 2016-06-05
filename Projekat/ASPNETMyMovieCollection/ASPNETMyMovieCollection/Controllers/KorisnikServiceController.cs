using ASPNETMyMovieCollection.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ASPNETMyMovieCollection.Controllers
{
    public class KorisnikServiceController : ApiController
    {
        private KorisnikDbContext db = new KorisnikDbContext();

        // GET: api/KorisnikService
        public IQueryable<Korisnik> GetKorisnici()
        {
            return db.Korisnici;
        }

        // GET: api/KorisnikService/5
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> GetKorisnik(int id)
        {
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return Ok(korisnik);
        }

        // PUT: api/KorisnikService/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutKorisnik(int id, Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != korisnik.KorisnikId)
            {
                return BadRequest();
            }

            db.Entry(korisnik).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KorisnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KorisnikService
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> PostKorisnik(Korisnik korisnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Korisnici.Add(korisnik);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = korisnik.KorisnikId }, korisnik);
        }

        // DELETE: api/KorisnikService/5
        [ResponseType(typeof(Korisnik))]
        public async Task<IHttpActionResult> DeleteKorisnik(int id)
        {
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }

            db.Korisnici.Remove(korisnik);
            await db.SaveChangesAsync();

            return Ok(korisnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KorisnikExists(int id)
        {
            return db.Korisnici.Count(e => e.KorisnikId == id) > 0;
        }
    }
}