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
    public class SectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sectors
        public ActionResult Index()
        {
            return View(db.Sectors.ToList());
        }

        // GET: Sectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sectors sectors = db.Sectors.Find(id);
            if (sectors == null)
            {
                return HttpNotFound();
            }
            return View(sectors);
        }

        // GET: Sectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sectors/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,playGround,availableForVisit")] Sectors sectors)
        {
            if (ModelState.IsValid)
            {
                db.Sectors.Add(sectors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sectors);
        }

        // GET: Sectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sectors sectors = db.Sectors.Find(id);
            if (sectors == null)
            {
                return HttpNotFound();
            }
            return View(sectors);
        }

        // POST: Sectors/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,playGround,availableForVisit")] Sectors sectors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sectors);
        }

        // GET: Sectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sectors sectors = db.Sectors.Find(id);
            if (sectors == null)
            {
                return HttpNotFound();
            }
            return View(sectors);
        }

        // POST: Sectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sectors sectors = db.Sectors.Find(id);
            db.Sectors.Remove(sectors);
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
