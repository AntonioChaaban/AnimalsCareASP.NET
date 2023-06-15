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
    public class ReproductionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reproductions
        public ActionResult Index()
        {
            return View(db.Reproductions.ToList());
        }

        // GET: Reproductions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reproductions reproductions = db.Reproductions.Find(id);
            if (reproductions == null)
            {
                return HttpNotFound();
            }
            return View(reproductions);
        }

        // GET: Reproductions/Create
        public ActionResult Create()
        {
            // Busca a lista de animais no banco de dados
            var animais = db.Animals.ToList();
            

            // Converte a lista de animais em uma lista de SelectListItem para enviar para a view
            var animaisSelectList = animais.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            ViewBag.Animais = animaisSelectList;
            return View();
        }

        // POST: Reproductions/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,expectedMatingDate,matingDateHeld,scenarioDescription,descriptionAct,pregnancy,animalMale,animalFemale")] Reproductions reproductions)
        {
            if (ModelState.IsValid)
            {
                db.Reproductions.Add(reproductions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var animais = db.Animals.ToList();
            ViewBag.Animais = animais.Select(a => new SelectListItem
            {
                Value = a.id.ToString(),
                Text = a.name
            }).ToList();

            return View(reproductions);
        }

        // GET: Reproductions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reproductions reproductions = db.Reproductions.Find(id);
            if (reproductions == null)
            {
                return HttpNotFound();
            }
            return View(reproductions);
        }

        // POST: Reproductions/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,expectedMatingDate,matingDateHeld,scenarioDescription,descriptionAct,pregnancy")] Reproductions reproductions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reproductions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reproductions);
        }

        // GET: Reproductions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reproductions reproductions = db.Reproductions.Find(id);
            if (reproductions == null)
            {
                return HttpNotFound();
            }
            return View(reproductions);
        }

        // POST: Reproductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reproductions reproductions = db.Reproductions.Find(id);
            db.Reproductions.Remove(reproductions);
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
