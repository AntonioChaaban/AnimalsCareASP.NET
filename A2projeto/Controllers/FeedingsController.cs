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
    public class FeedingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Feedings
        public ActionResult Index()
        {
            return View(db.Feedings.ToList());
        }

        // GET: Feedings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            return View(feedings);
        }

        // GET: Feedings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedings/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,feedingSchedule,feedingFrequencyPerDay,eatingHabits")] Feedings feedings)
        {
            if (ModelState.IsValid)
            {
                db.Feedings.Add(feedings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedings);
        }

        // GET: Feedings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            return View(feedings);
        }

        // POST: Feedings/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,feedingSchedule,feedingFrequencyPerDay,eatingHabits")] Feedings feedings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedings);
        }

        // GET: Feedings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            return View(feedings);
        }

        // POST: Feedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedings feedings = db.Feedings.Find(id);
            db.Feedings.Remove(feedings);
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
