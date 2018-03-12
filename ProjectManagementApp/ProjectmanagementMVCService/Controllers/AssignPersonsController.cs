using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Models;

namespace ProjectmanagementMVCService.Controllers
{
     [Authorize(Roles = "ProjectManager")]
    public class AssignPersonsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: AssignPersons
        public ActionResult Index()
        {
            var assignPersons = db.AssignPersons.Include(a => a.Projct).Include(a => a.User);
            return View(assignPersons.ToList());
        }

        // GET: AssignPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignPerson assignPerson = db.AssignPersons.Find(id);
            if (assignPerson == null)
            {
                return HttpNotFound();
            }
            return View(assignPerson);
        }

        // GET: AssignPersons/Create
        public ActionResult Create()
        {
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: AssignPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ProjctId,AssignBy")] AssignPerson assignPerson)
        {
            if (ModelState.IsValid)
            {
                assignPerson.AssignBy = User.Identity.Name;
                db.AssignPersons.Add(assignPerson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", assignPerson.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", assignPerson.UserId);
            return View(assignPerson);
        }

        // GET: AssignPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignPerson assignPerson = db.AssignPersons.Find(id);
            if (assignPerson == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", assignPerson.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", assignPerson.UserId);
            return View(assignPerson);
        }

        // POST: AssignPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,ProjctId,AssignBy")] AssignPerson assignPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", assignPerson.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", assignPerson.UserId);
            return View(assignPerson);
        }

        // GET: AssignPersons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignPerson assignPerson = db.AssignPersons.Find(id);
            if (assignPerson == null)
            {
                return HttpNotFound();
            }
            return View(assignPerson);
        }

        // POST: AssignPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignPerson assignPerson = db.AssignPersons.Find(id);
            db.AssignPersons.Remove(assignPerson);
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
