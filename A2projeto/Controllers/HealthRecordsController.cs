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
    public class HealthRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HealthRecords
        public ActionResult Index()
        {
            return View(db.HealthRecords.ToList());
        }

        // GET: HealthRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthRecords healthRecords = db.HealthRecords.Find(id);
            if (healthRecords == null)
            {
                return HttpNotFound();
            }
            return View(healthRecords);
        }

        // GET: HealthRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthRecords/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,physicalHealth,pregnancyIdentificationDay,pregnancyStage,pregnancyDay,dateOfDelivery,numberOfOffspring,description")] HealthRecords healthRecords)
        {
            if (ModelState.IsValid)
            {
                db.HealthRecords.Add(healthRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthRecords);
        }

        // GET: HealthRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthRecords healthRecords = db.HealthRecords.Find(id);
            if (healthRecords == null)
            {
                return HttpNotFound();
            }
            return View(healthRecords);
        }

        // POST: HealthRecords/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,physicalHealth,pregnancyIdentificationDay,pregnancyStage,pregnancyDay,dateOfDelivery,numberOfOffspring,description")] HealthRecords healthRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthRecords);
        }

        // GET: HealthRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthRecords healthRecords = db.HealthRecords.Find(id);
            if (healthRecords == null)
            {
                return HttpNotFound();
            }
            return View(healthRecords);
        }

        // POST: HealthRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthRecords healthRecords = db.HealthRecords.Find(id);
            db.HealthRecords.Remove(healthRecords);
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
