using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryAppConcept.Models;

namespace LibraryAppConcept.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private static List<Book> books = new List<Book>
        {
            new Book(1, "War and Peace", "Leo Tolstoy", "warandpeace.jpg", 1869),
            new Book(2, "Pride and Prejudice", "Jane Austen", "prideandprejudice.jpg", 1813),
            new Book(3, "The Great Gatsby", "F. Scott Fitzgerald", "thegreatgatsby.jpg", 1925)
        };

        public ActionResult Index()
        {
            return View(books);
        }

        public ActionResult Details(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                Book bookToUpdate = books.FirstOrDefault(b => b.Id == id);
                if (bookToUpdate != null)
                {
                    bookToUpdate.Name = book.Name;
                    bookToUpdate.Author = book.Author;
                    bookToUpdate.Photo = book.Photo;
                    bookToUpdate.YearOfPublishing = book.YearOfPublishing;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public ActionResult Delete(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
            return RedirectToAction("Index");
        }


    }
}