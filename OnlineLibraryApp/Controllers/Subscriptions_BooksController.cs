using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineLibraryApp.Models;

namespace OnlineLibraryApp.Controllers
{
    public class Subscriptions_BooksController : Controller
    {
        private OnlineLibraryDbEntities1 db = new OnlineLibraryDbEntities1();

        // GET: Subscriptions_Books
        public ActionResult Index()
        {
            var subscriptions_Books = db.Subscriptions_Books.Include(s => s.Book).Include(s => s.Subscription);
            return View(subscriptions_Books.ToList());
        }

        // GET: Subscriptions_Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriptions_Books subscriptions_Books = db.Subscriptions_Books.Find(id);
            if (subscriptions_Books == null)
            {
                return HttpNotFound();
            }
            return View(subscriptions_Books);
        }

        // GET: Subscriptions_Books/Create
        public ActionResult Create()
        {
            ViewBag.book_id = new SelectList(db.Book, "Id", "name");
            ViewBag.subscription_id = new SelectList(db.Subscription, "Id", "last_name");
            return View();
        }

        // POST: Subscriptions_Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,subscription_id,book_id")] Subscriptions_Books subscriptions_Books)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions_Books.Add(subscriptions_Books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.book_id = new SelectList(db.Book, "Id", "name", subscriptions_Books.book_id);
            ViewBag.subscription_id = new SelectList(db.Subscription, "Id", "last_name", subscriptions_Books.subscription_id);
            return View(subscriptions_Books);
        }

        // GET: Subscriptions_Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriptions_Books subscriptions_Books = db.Subscriptions_Books.Find(id);
            if (subscriptions_Books == null)
            {
                return HttpNotFound();
            }
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", subscriptions_Books.book_id);
            ViewBag.subscription_id = new SelectList(db.Subscription, "Id", "last_name", subscriptions_Books.subscription_id);
            return View(subscriptions_Books);
        }

        // POST: Subscriptions_Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,subscription_id,book_id")] Subscriptions_Books subscriptions_Books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscriptions_Books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", subscriptions_Books.book_id);
            ViewBag.subscription_id = new SelectList(db.Subscription, "Id", "last_name", subscriptions_Books.subscription_id);
            return View(subscriptions_Books);
        }

        // GET: Subscriptions_Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscriptions_Books subscriptions_Books = db.Subscriptions_Books.Find(id);
            if (subscriptions_Books == null)
            {
                return HttpNotFound();
            }
            return View(subscriptions_Books);
        }

        // POST: Subscriptions_Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscriptions_Books subscriptions_Books = db.Subscriptions_Books.Find(id);
            db.Subscriptions_Books.Remove(subscriptions_Books);
            db.SaveChanges();
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
