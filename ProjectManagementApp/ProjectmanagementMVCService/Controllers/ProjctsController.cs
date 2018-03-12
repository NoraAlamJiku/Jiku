using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectmanagementMVCService.Controllers
{
     [Authorize(Roles = "ProjectManager")]
    public class ProjctsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Projcts
        public ActionResult Index()
        {
            return View(db.Projcts.ToList());
        }

        // GET: Projcts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projct projct = db.Projcts.Find(id);
            if (projct == null)
            {
                return HttpNotFound();
            }
            return View(projct);
        }

        // GET: Projcts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projcts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projct projct, HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {
                if (UploadFile != null)
                {
                    if (UploadFile.ContentType == "image/jpeg" || UploadFile.ContentType == "image/png" || UploadFile.ContentType == "image/gif")
                    {
                        UploadFile.SaveAs(Server.MapPath("/") + "/UploadFile/" + UploadFile.FileName);
                        projct.UploadFile = UploadFile.FileName;
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }

                var project = db.Projcts.Where(m => m.Name == projct.Name).ToList();

                if (project.Count() == 1)
                {
                    var id = project[0].Id;
                    projct.Id = id;
                    db.Projcts.AddOrUpdate(projct);
                    db.SaveChanges();
                    ViewBag.Msg = "Update Project Successful!";
                }
                else
                {
                    db.Projcts.Add(projct);
                    db.SaveChanges();
                    ViewBag.Msg = "Project Saved Successful!";
                }
            }

            return View(projct);
        }

        // GET: Projcts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projct projct = db.Projcts.Find(id);
            if (projct == null)
            {
                return HttpNotFound();
            }
            return View(projct);
        }

        // POST: Projcts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CodeName,Description,StartDate,EndDate,Duration,UploadFile,Status")] Projct projct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projct);
        }

        // GET: Projcts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projct projct = db.Projcts.Find(id);
            if (projct == null)
            {
                return HttpNotFound();
            }
            return View(projct);
        }

        // POST: Projcts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projct projct = db.Projcts.Find(id);
            db.Projcts.Remove(projct);
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
