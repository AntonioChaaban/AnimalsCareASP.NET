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
            // Busca a lista de animais no banco de dados
            var performfeedings = db.PerformFeedings.ToList();
            var feedings = db.Feedings.ToList();
            var personnels = db.Personnels.ToList();
            var foods = db.Foods.ToList();
            int number;

            foreach (var per in performfeedings)
            {
                foreach (var feed in feedings)
                {
                    if (int.TryParse(per.feedings, out number))
                    {
                        if (feed.id == int.Parse(per.feedings)) 
                        {
                            per.feedings = feed.name;
                        }
                    }
                    else { }
                }
                foreach (var food in foods)
                {
                    if (int.TryParse(per.food, out number))
                    {
                        if (food.id == int.Parse(per.food))
                        {
                            per.food = food.name;
                        }
                    }
                    else { }
                }
                foreach (var personnel in personnels) 
                {
                    if (int.TryParse(per.UserId, out number))
                    {
                        if (personnel.id == int.Parse(per.UserId))
                        {
                            per.UserId = personnel.name;
                        }
                    }
                    else { }
                }
            }

            return View(performfeedings);
        }

        // GET: PerformFeedings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerformFeedings performFeedings = db.PerformFeedings.Find(id);
            int number;
            
            if (performFeedings == null)
            {
                return HttpNotFound();
            }
            if (int.TryParse(performFeedings.feedings, out number) && int.TryParse(performFeedings.food, out number) && int.TryParse(performFeedings.UserId, out number))
            {
                Feedings feedings = db.Feedings.Find(int.Parse(performFeedings.feedings));
                Personnels personnels = db.Personnels.Find(int.Parse(performFeedings.UserId));
                Foods foods = db.Foods.Find(int.Parse(performFeedings.food));

                performFeedings.food = foods.name;
                performFeedings.feedings = feedings.name;
                performFeedings.UserId = personnels.name;

            }
            return View(performFeedings);
        }

        // GET: PerformFeedings/Create
        public ActionResult Create()
        {
            // Busca a lista de comidas no banco de dados
            var feedings = db.Feedings.ToList();
            var foods = db.Foods.ToList();
            var personnels = db.Personnels.ToList();

            // Converte a lista de comidas em uma lista de SelectListItem para enviar para a view
            var foodsSelectList = foods.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var personnelsSelectList = personnels.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var feedingsSelectList = feedings.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Animais = foodsSelectList;
            ViewBag.Personnels = personnelsSelectList;
            ViewBag.Feedings = feedingsSelectList;

            return View();
        }

        // POST: PerformFeedings/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,feedings,food,quantity,UserId,feedingDate")] PerformFeedings performFeedings)
        {
            if (ModelState.IsValid)
            {
                db.PerformFeedings.Add(performFeedings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var foods = db.Foods.ToList();
            ViewBag.Animais = foods.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

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
            // Busca a lista de comidas no banco de dados
            var feedings = db.Feedings.ToList();
            var foods = db.Foods.ToList();
            var personnels = db.Personnels.ToList();

            // Converte a lista de comidas em uma lista de SelectListItem para enviar para a view
            var foodsSelectList = foods.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var personnelsSelectList = personnels.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();
            var feedingsSelectList = feedings.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Animais = foodsSelectList;
            ViewBag.Personnels = personnelsSelectList;
            ViewBag.Feedings = feedingsSelectList;

            return View(performFeedings);
        }

        // POST: PerformFeedings/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,feedings,food,quantity,UserId,feedingDate")] PerformFeedings performFeedings)
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
