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
    public class PersonnelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Método para validar o CPF
        private bool ValidarCPF(string cpf)
        {
            // Verifica se o CPF possui 11 dígitos
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int primeiroDigitoVerificador = (resto < 2) ? 0 : 11 - resto;

            // Verifica o primeiro dígito verificador
            if (int.Parse(cpf[9].ToString()) != primeiroDigitoVerificador)
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int segundoDigitoVerificador = (resto < 2) ? 0 : 11 - resto;

            // Verifica o segundo dígito verificador
            if (int.Parse(cpf[10].ToString()) != segundoDigitoVerificador)
            {
                return false;
            }

            return true; // CPF válido
        }

        // GET: Personnels
        public ActionResult Index()
        {
            return View(db.Personnels.ToList());
        }

        // GET: Personnels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnels personnels = db.Personnels.Find(id);
            if (personnels == null)
            {
                return HttpNotFound();
            }
            return View(personnels);
        }

        // GET: Personnels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personnels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,documentNumber,gender,workShift,expertises,memberSince")] Personnels personnels)
        {
            // Verifica se o CPF é válido
            if (!ValidarCPF(personnels.documentNumber))
            {
                ModelState.AddModelError("CPF", "CPF inválido");
            }

            if (ModelState.IsValid)
            {
                db.Personnels.Add(personnels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personnels);
        }


        // GET: Personnels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnels personnels = db.Personnels.Find(id);
            if (personnels == null)
            {
                return HttpNotFound();
            }
            return View(personnels);
        }

        // POST: Personnels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,documentNumber,gender,workShift,expertises,memberSince")] Personnels personnels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personnels);
        }

        // GET: Personnels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnels personnels = db.Personnels.Find(id);
            if (personnels == null)
            {
                return HttpNotFound();
            }
            return View(personnels);
        }

        // POST: Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personnels personnels = db.Personnels.Find(id);
            db.Personnels.Remove(personnels);
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
