﻿using System;
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
    public class AnimalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Animals
        public ActionResult Index()
        {
            return View(db.Animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            var feedings = db.Feedings.Find(int.Parse(animals.feedings));
            var sectors = db.Sectors.Find(int.Parse(animals.sector));
            if (animals == null)
            {
                return HttpNotFound();
            }
            if (animals.healthRecords != null)
            {
                HealthRecords healthRecords = db.HealthRecords.Find(int.Parse(animals.healthRecords));
                animals.healthRecords = healthRecords.name;
            }
            else {
                animals.healthRecords = "Ainda não foi definido uma ficha médica";
            }
            animals.feedings = feedings.name;
            animals.sector = sectors.name;
            return View(animals);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            var feedings = db.Feedings.ToList();
            var sectors = db.Sectors.ToList();
            var healthRecords = db.HealthRecords.ToList();

            var feedingsSelectList = feedings.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            var sectorsSelectList = sectors.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            var healthRecordsSelectList = healthRecords.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Feedings = feedingsSelectList;
            ViewBag.Sectors = sectorsSelectList;
            ViewBag.HealthRecords = healthRecordsSelectList;

            return View();
        }

        // POST: Animals/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,feedings,sector,name,tag_code,specimen,dateBirth,age,gender,locomotion,color,characteristics,extinct,reproduction_characteristcs,standards_of_care")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var feedings = db.Feedings.ToList();

            var sectors = db.Sectors.ToList();

            var feedingsSelectList = feedings.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var sectorsSelectList = sectors.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            return View(animals);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            var feedings = db.Feedings.ToList();
            var sectors = db.Sectors.ToList();
            var feedingsSelectList = feedings.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var sectorsSelectList = sectors.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Sectors = sectorsSelectList;
            ViewBag.Feedings = feedingsSelectList;
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // POST: Animals/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,feedings,sector,name,tag_code,specimen,dateBirth,age,gender,locomotion,color,characteristics,extinct,reproduction_characteristcs,standards_of_care")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animals).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animals);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animals animals = db.Animals.Find(id);
            db.Animals.Remove(animals);
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
