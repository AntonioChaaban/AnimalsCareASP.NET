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
    public class InfirmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Infirms
        public ActionResult Index()
        {
            return View(db.Infirms.ToList());
        }

        // GET: Infirms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infirms infirms = db.Infirms.Find(id);
            if (infirms == null)
            {
                return HttpNotFound();
            }
            return View(infirms);
        }

        // GET: Infirms/Create
        public ActionResult Create()
        {
            var personnels = db.Personnels.ToList();
            var personnelsSelectList = personnels.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            ViewBag.Personnels = personnelsSelectList;
            return View();
        }

        // POST: Infirms/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,physicalTreatment,pharmaceuticalTreatment,vaccine,frequencyOfTreatment,durationOfTreatment,treatmentStartDate,UserId")] Infirms infirms)
        {
            if (ModelState.IsValid)
            {
                db.Infirms.Add(infirms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var personnels = db.Personnels.ToList();
            var personnelsSelectList = personnels.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            return View(infirms);
        }

        // GET: Infirms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infirms infirms = db.Infirms.Find(id);
            if (infirms == null)
            {
                return HttpNotFound();
            }
            return View(infirms);
        }

        // POST: Infirms/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,physicalTreatment,pharmaceuticalTreatment,vaccine,frequencyOfTreatment,durationOfTreatment,treatmentStartDate,UserId")] Infirms infirms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infirms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infirms);
        }

        // GET: Infirms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infirms infirms = db.Infirms.Find(id);
            if (infirms == null)
            {
                return HttpNotFound();
            }
            return View(infirms);
        }

        // POST: Infirms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Infirms infirms = db.Infirms.Find(id);
            db.Infirms.Remove(infirms);
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
