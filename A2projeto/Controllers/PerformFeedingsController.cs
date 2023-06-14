using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A2projeto.Models;

namespace A2projeto.Controllers
{
    public class PerformFeedingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PerformFeedings
        public ActionResult Index()
        {
            return View(db.PerformFeedings.ToList());
        }

        // GET: PerformFeedings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformFeedings performFeedings = db.PerformFeedings.Find(id);
            if (performFeedings == null)
            {
                return HttpNotFound();
            }
            return View(performFeedings);
        }

        // GET: PerformFeedings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerformFeedings/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,quantity,UserId,feedingDate")] PerformFeedings performFeedings)
        {
            if (ModelState.IsValid)
            {
                db.PerformFeedings.Add(performFeedings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(performFeedings);
        }

        // GET: PerformFeedings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformFeedings performFeedings = db.PerformFeedings.Find(id);
            if (performFeedings == null)
            {
                return HttpNotFound();
            }
            return View(performFeedings);
        }

        // POST: PerformFeedings/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,quantity,UserId,feedingDate")] PerformFeedings performFeedings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(performFeedings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(performFeedings);
        }

        // GET: PerformFeedings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformFeedings performFeedings = db.PerformFeedings.Find(id);
            if (performFeedings == null)
            {
                return HttpNotFound();
            }
            return View(performFeedings);
        }

        // POST: PerformFeedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerformFeedings performFeedings = db.PerformFeedings.Find(id);
            db.PerformFeedings.Remove(performFeedings);
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
