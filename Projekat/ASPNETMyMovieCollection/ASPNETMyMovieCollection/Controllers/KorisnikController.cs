using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ASPNETMyMovieCollection.Models;

namespace ASPNETMyMovieCollection.Controllers
{
    public class KorisnikController : Controller
    {
        private KorisnikDbContext db = new KorisnikDbContext();

        // GET: Korisnik
        public async Task<ActionResult> Index()
        {
            return View(await db.Korisnici.ToListAsync());
        }

        // GET: Korisnik/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            if (korisnik  == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "KorisnikId,Ime,Prezime,Username")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisnici.Add(korisnik);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: Korisnik/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "KorisnikId,Ime,Prezime,Username")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: Korisnik/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Korisnik korisnik = await db.Korisnici.FindAsync(id);
            db.Korisnici.Remove(korisnik);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}