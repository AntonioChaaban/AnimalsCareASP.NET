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



        public ActionResult SeeInferms(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int number;

            var infirms = db.Set<Infirms>().Where(a => a.healthRecords == id.ToString()).ToList();
            var healtrecords = db.HealthRecords.ToList();
            var personels = db.Personnels.ToList();

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
                    else { }
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



            // GET: HealthRecords
        public ActionResult Index()
        {
            var healthrecords = db.HealthRecords.ToList();
            var animals = db.Animals.ToList();
            int number;
            foreach (var healthrecord in healthrecords)
            {
                foreach (var animal in animals)
                {
                    if (int.TryParse(healthrecord.animal, out number))
                    {
                        if (animal.id == int.Parse(healthrecord.animal))
                        {
                            healthrecord.animal = animal.name;
                        }
                    }
                    else { }
                }
            }
            return View(healthrecords);
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
           var animals = db.Animals.ToList();

            var animalsSelectList = animals.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Animals = animalsSelectList;
            return View();
        }

        // POST: HealthRecords/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,animal,physicalHealth,pregnancyIdentificationDay,pregnancyStage,pregnancyDay,dateOfDelivery,numberOfOffspring,description")] HealthRecords healthRecords)
        {
            if (ModelState.IsValid)
            {

                Animals animal = db.Animals.FirstOrDefault(a => a.id.ToString() == healthRecords.animal);
                animal.healthRecords = healthRecords.id.ToString();
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
        public ActionResult Edit([Bind(Include = "id,name,physicalHealth,pregnancyIdentificationDay,pregnancyStage,pregnancyDay,dateOfDelivery,numberOfOffspring,description")] HealthRecords healthRecords)
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
