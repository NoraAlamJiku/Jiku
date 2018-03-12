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
     [Authorize(Roles = "ProjectManager, User")]
    public class TasksController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Tasks
        public ActionResult Index()
        {
            var taskss = db.Taskss.Include(t => t.Priority).Include(t => t.Projct).Include(t => t.User);
            return View(taskss.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Taskss.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.PriorityId = new SelectList(db.Prioritys, "Id", "Name");
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProjctId,UserId,Description,DueDate,PriorityId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Taskss.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityId = new SelectList(db.Prioritys, "Id", "Name", tasks.PriorityId);
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", tasks.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tasks.UserId);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Taskss.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityId = new SelectList(db.Prioritys, "Id", "Name", tasks.PriorityId);
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", tasks.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tasks.UserId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProjctId,UserId,Description,DueDate,PriorityId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityId = new SelectList(db.Prioritys, "Id", "Name", tasks.PriorityId);
            ViewBag.ProjctId = new SelectList(db.Projcts, "Id", "Name", tasks.ProjctId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", tasks.UserId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Taskss.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = db.Taskss.Find(id);
            db.Taskss.Remove(tasks);
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
