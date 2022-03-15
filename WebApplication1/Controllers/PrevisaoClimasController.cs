using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class PrevisaoClimasController : Controller
    {
        private ClimaTempoSimplesEntities db = new ClimaTempoSimplesEntities();

        // GET: PrevisaoClimas
        public ActionResult Index()
        {
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome");
            ViewBag.Previsao = new SelectList(db.PrevisaoClimas, "Clima", "temperaturaMinima", "temperaturaMaxima");
            return View(db.PrevisaoClimas.ToList());
        }

        

        // GET: PrevisaoClimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<PrevisaoClima> previsaoClima = db.PrevisaoClimas.Where(x => x.CidadeId == id).ToList();
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }



            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Create
        public ActionResult Create()
        {
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome");
            return View();
        }

        // POST: PrevisaoClimas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CidadeId,DataPrevisao,Clima,temperaturaMinima,temperaturaMaxima")] PrevisaoClima previsaoClima)
        {
            if (ModelState.IsValid)
            {
                db.PrevisaoClimas.Add(previsaoClima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            return View(previsaoClima);
        }

        // POST: PrevisaoClimas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CidadeId,DataPrevisao,Clima,temperaturaMinima,temperaturaMaxima")] PrevisaoClima previsaoClima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(previsaoClima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(previsaoClima);
        }

        // GET: PrevisaoClimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            if (previsaoClima == null)
            {
                return HttpNotFound();
            }
            return View(previsaoClima);
        }

        // POST: PrevisaoClimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrevisaoClima previsaoClima = db.PrevisaoClimas.Find(id);
            db.PrevisaoClimas.Remove(previsaoClima);
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

        // GET: PrevisaoClimas/Create
        //public SelectList CarregaListas(int idCidade)
        public ActionResult CarregaListas(int idCidade)
        {
            ViewBag.Dropdown = idCidade;
            return RedirectToAction("Index");
        }
    }
}
