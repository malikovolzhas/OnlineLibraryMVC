using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineLibraryApp.Models;

namespace OnlineLibraryApp.Controllers
{
    public class Books_AuthorsController : Controller
    {
        private OnlineLibraryDbEntities1 db = new OnlineLibraryDbEntities1();

        // GET: Books_Authors
        public ActionResult Index()
        {
            var books_Authors = db.Books_Authors.Include(b => b.Author).Include(b => b.Book);
            return View(books_Authors.ToList());
        }

        // GET: Books_Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Authors books_Authors = db.Books_Authors.Find(id);
            if (books_Authors == null)
            {
                return HttpNotFound();
            }
            return View(books_Authors);
        }

        // GET: Books_Authors/Create
        public ActionResult Create()
        {
            ViewBag.author_id = new SelectList(db.Author, "Id", "last_name");
            ViewBag.book_id = new SelectList(db.Book, "Id", "name");
            return View();
        }

        // POST: Books_Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,book_id,author_id")] Books_Authors books_Authors)
        {
            if (ModelState.IsValid)
            {
                db.Books_Authors.Add(books_Authors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author_id = new SelectList(db.Author, "Id", "last_name", books_Authors.author_id);
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", books_Authors.book_id);
            return View(books_Authors);
        }

        // GET: Books_Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Authors books_Authors = db.Books_Authors.Find(id);
            if (books_Authors == null)
            {
                return HttpNotFound();
            }
            ViewBag.author_id = new SelectList(db.Author, "Id", "last_name", books_Authors.author_id);
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", books_Authors.book_id);
            return View(books_Authors);
        }

        // POST: Books_Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,book_id,author_id")] Books_Authors books_Authors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books_Authors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author_id = new SelectList(db.Author, "Id", "last_name", books_Authors.author_id);
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", books_Authors.book_id);
            return View(books_Authors);
        }

        // GET: Books_Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books_Authors books_Authors = db.Books_Authors.Find(id);
            if (books_Authors == null)
            {
                return HttpNotFound();
            }
            return View(books_Authors);
        }

        // POST: Books_Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books_Authors books_Authors = db.Books_Authors.Find(id);
            db.Books_Authors.Remove(books_Authors);
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
