using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineLibraryApp.Models;

namespace OnlineLibraryApp.Controllers
{
    public class BookCopiesController : Controller
    {
        private OnlineLibraryDbEntities1 db = new OnlineLibraryDbEntities1();

        // GET: BookCopies
        public ActionResult Index()
        {
            var bookCopy = db.BookCopy.Include(b => b.Book);
            return View(bookCopy.ToList());
        }

        // GET: BookCopies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCopy bookCopy = db.BookCopy.Find(id);
            if (bookCopy == null)
            {
                return HttpNotFound();
            }
            return View(bookCopy);
        }

        // GET: BookCopies/Create
        public ActionResult Create()
        {
            ViewBag.book_id = new SelectList(db.Book, "Id", "name");
            return View();
        }

        // POST: BookCopies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,inventory_number,is_available,take_date,return_date,book_id")] BookCopy bookCopy)
        {
            if (ModelState.IsValid)
            {
                db.BookCopy.Add(bookCopy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.book_id = new SelectList(db.Book, "Id", "name", bookCopy.book_id);
            return View(bookCopy);
        }

        // GET: BookCopies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCopy bookCopy = db.BookCopy.Find(id);
            if (bookCopy == null)
            {
                return HttpNotFound();
            }
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", bookCopy.book_id);
            return View(bookCopy);
        }

        // POST: BookCopies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,inventory_number,is_available,take_date,return_date,book_id")] BookCopy bookCopy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCopy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.book_id = new SelectList(db.Book, "Id", "name", bookCopy.book_id);
            return View(bookCopy);
        }

        // GET: BookCopies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCopy bookCopy = db.BookCopy.Find(id);
            if (bookCopy == null)
            {
                return HttpNotFound();
            }
            return View(bookCopy);
        }

        // POST: BookCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCopy bookCopy = db.BookCopy.Find(id);
            db.BookCopy.Remove(bookCopy);
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
