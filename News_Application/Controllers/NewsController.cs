using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using News_Application.Models;
using News_Application.ViewModel;

namespace News_Application.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public ActionResult Index()
        {
            IEnumerable<News> news = db.news.ToList();
            IEnumerable<Author> authors = db.authors.ToList();

            var author = new AuthorViewModel
            {
               news=news,
               authors=authors
            };

            //  var news = db.news.ToList();
            
            return View(author);
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: News/Create
        [Authorize]
        public ActionResult Create()
        {
            var news = new News();
            var authorsView = new AuthorViewModel
            {
                newss = news,
                authors = db.authors.ToList()
                
            };
          
            return View(authorsView);
        }


        public ActionResult ViewNews(int news)
        {
            var dbcontect = db.news.Where(m => m.Id == news).FirstOrDefault();
            

            return View(dbcontect);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(AuthorViewModel authorViewModel, HttpPostedFileBase file)
        {
            var news = authorViewModel.newss;
            //news.Publiction_Date = DateTime.Now;
            news.Creation_nDate = DateTime.Now;


            if (ModelState.IsValid)
            {
                // code to save to database, redirect to other page
                
                db.news.Add(news);
                db.SaveChanges();

                if (file != null && file.ContentLength > 0)
                    try
                    {
                        News newss = db.news.OrderByDescending(u => u.Id).FirstOrDefault();

                        string path = Path.Combine(Server.MapPath("~/uploads"),
                            Path.GetFileName(file.FileName));

                        string filename = Convert.ToString(newss.Id + "ID") + System.IO.Path.GetFileName(file.FileName);
                        string extension = Path.GetExtension(Path.GetFileName(file.FileName));

                        //   file.SaveAs(Path.Combine(Server.MapPath("~/uploads") + "0" + extension));

                        file.SaveAs(Server.MapPath("~/Uploads/" + newss.Id + extension));
                        ViewBag.message = "File Uploaded Successfully";

                    }
                    catch (Exception ex)
                    {
                        ViewBag.message = "Error" + ex.Message.ToString();
                    }

                return RedirectToAction("Index", authorViewModel);
            }
            else
            {
                return View(news);

            }

        }


        // GET: News/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            var x = new AuthorViewModel
            {
                newss = news,
                authors = db.authors.ToList()

            };

            return View(x);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(AuthorViewModel authorViewModel, HttpPostedFileBase file)
        {
            var news = authorViewModel.newss;
            //news.Publiction_Date = DateTime.Now;
            news.Creation_nDate = DateTime.Now;


            if (ModelState.IsValid)
            {
                // code to save to database, redirect to other page
                var customerInDb = db.news.Single(c => c.Id == news.Id);
                customerInDb._News = news._News;
                customerInDb.Title = news.Title;
                customerInDb.Publiction_Date = news.Publiction_Date;
                customerInDb.Creation_nDate = news.Creation_nDate;
                customerInDb.Img_Url=news.Id + ".jpg";
                ;


                //  db.news.Add(customerInDb);
                db.SaveChanges();

                if (file != null && file.ContentLength > 0)
                    try
                    {
                        News newss = db.news.FirstOrDefault(m => m.Id == news.Id);

                        string path = Path.Combine(Server.MapPath("~/uploads"),
                            Path.GetFileName(file.FileName));

                        string filename = Convert.ToString(newss.Id + "ID") + System.IO.Path.GetFileName(file.FileName);
                        string extension = Path.GetExtension(Path.GetFileName(file.FileName));

                        //   file.SaveAs(Path.Combine(Server.MapPath("~/uploads") + "0" + extension));

                        file.SaveAs(Server.MapPath("~/Uploads/" + newss.Id + extension));
                        ViewBag.message = "File Uploaded Successfully";

                    }
                    catch (Exception ex)
                    {
                        ViewBag.message = "Error" + ex.Message.ToString();
                    }

                return RedirectToAction("Index", authorViewModel);
            }
            else
            {
                return View(news);

            }

        }


        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.news.Find(id);
            db.news.Remove(news);
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
