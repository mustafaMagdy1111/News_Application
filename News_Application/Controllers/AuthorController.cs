using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using News_Application.Models;
using News_Application.ViewModel;

namespace News_Application.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Author
        public ActionResult Index()
        {


            return View(db.authors.ToList());
        }
        //data in json to be used in Data Table
        public object Load()
        {
            var all = new List<AuthorVM>();
            var authors = db.authors.ToList();
            foreach (var authr in authors)
            {
                all.Add(new AuthorVM()
                {
                    Name = authr.Name,
                    Id = authr.Id,
                    DateOfBirth = authr.DateOfBirth.ToShortDateString(),
                    PhoneNumber = authr.PhoneNumber,
                    Email = authr.Email
                });
            }
            return Json(new {data = all });
        }
        //model which show popup confirmation message
        public ActionResult ConfirmChangeActivity(long id)
        {
            var news = db.news.Where(m => m.authorID == id);
            if(news.Count() != 0)
            {
                return PartialView("~/Views/Author/PreventDelete.cshtml");
            }
            else
            {
                var model = db.authors.Where(m => m.Id == id).FirstOrDefault();
                return PartialView("~/Views/Author/Delete.cshtml", model);
            }
        }


        // GET: Admin/Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Admin/Author/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Author/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,DateOfBirth,PhoneNumber,Email,Name")] author author)
        {
            if (ModelState.IsValid)
            {
                db.authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Admin/Author/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/Author/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Id,DateOfBirth,PhoneNumber,Email,Name")] author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Admin/Author/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Admin/Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(author model)
        {
            author author = db.authors.Find(model.Id);
            db.authors.Remove(author);
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
