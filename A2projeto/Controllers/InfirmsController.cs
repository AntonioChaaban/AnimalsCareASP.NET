using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A2projeto.Models;
using Microsoft.Ajax.Utilities;

namespace A2projeto.Controllers
{
    public class InfirmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Infirms
        public ActionResult Index()
        {
            var infirms = db.Infirms.ToList();
            var healtrecords = db.HealthRecords.ToList();
            var personels =  db.Personnels.ToList();
            int number;

            foreach (var infirm in infirms) 
            {
                foreach (var healthrecord in healtrecords)
                {
                    if (int.TryParse(infirm.healthRecords, out number))
                    {
                        if (healthrecord.id == int.Parse(infirm.healthRecords))
                        {
                            infirm.healthRecords = healthrecord.name;
                        }
                    }
                }
                foreach (var personel in personels)
                {
                    if (int.TryParse(infirm.UserId, out number))
                    {
                        if (personel.id == int.Parse(infirm.UserId))
                        {
                            infirm.UserId = personel.name;
                        }
                    }
                    else { }
                }
            }
            return View(infirms);
        }

        // GET: Infirms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Infirms infirms = db.Infirms.Find(id);

            try {
                var healthRecords = db.HealthRecords.Find(int.Parse(infirms.healthRecords));
                var personel = db.Personnels.Find(int.Parse(infirms.UserId));
                infirms.UserId = personel.name;
                infirms.healthRecords = healthRecords.name;
            } catch (Exception e)
            {
                return HttpNotFound();
            }

            return View(infirms);
        }

        // GET: Infirms/Create
        public ActionResult Create()
        {
            var personnels = db.Personnels.ToList();
            var healthRecords = db.HealthRecords.ToList();

            var personnelsSelectList = personnels.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var healthRecordsSelectList = healthRecords.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            ViewBag.Personnels = personnelsSelectList;
            ViewBag.HealthRecords = healthRecordsSelectList;
            return View();
        }

        // POST: Infirms/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,healthRecords,name,physicalTreatment,pharmaceuticalTreatment,vaccine,frequencyOfTreatment,durationOfTreatment,treatmentStartDate,UserId")] Infirms infirms)
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
