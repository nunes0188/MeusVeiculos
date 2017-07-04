using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControleDeCarros.Models;

namespace ControleDeCarros.Controllers
{
    public class VeiculosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Veiculos
        public ActionResult Index()
        {
            var veiculosSet = db.VeiculosSet.Include(v => v.Categorias).Include(v => v.Marcas);
            return View(veiculosSet.ToList());
        }

        // GET: Veiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculos veiculos = db.VeiculosSet.Find(id);
            if (veiculos == null)
            {
                return HttpNotFound();
            }
            return View(veiculos);
        }

        // GET: Veiculos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriasId = new SelectList(db.CategoriasSet, "Id", "Descricao");
            ViewBag.MarcasId = new SelectList(db.MarcasSet, "Id", "Descricao");
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Modelo,AnoFab,AnoMod,Motor,Cor,ValorPago,Financiado,CategoriasId,MarcasId")] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                db.VeiculosSet.Add(veiculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriasId = new SelectList(db.CategoriasSet, "Id", "Descricao", veiculos.CategoriasId);
            ViewBag.MarcasId = new SelectList(db.MarcasSet, "Id", "Descricao", veiculos.MarcasId);
            return View(veiculos);
        }

        // GET: Veiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculos veiculos = db.VeiculosSet.Find(id);
            if (veiculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriasId = new SelectList(db.CategoriasSet, "Id", "Descricao", veiculos.CategoriasId);
            ViewBag.MarcasId = new SelectList(db.MarcasSet, "Id", "Descricao", veiculos.MarcasId);
            return View(veiculos);
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Modelo,AnoFab,AnoMod,Motor,Cor,ValorPago,Financiado,CategoriasId,MarcasId")] Veiculos veiculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriasId = new SelectList(db.CategoriasSet, "Id", "Descricao", veiculos.CategoriasId);
            ViewBag.MarcasId = new SelectList(db.MarcasSet, "Id", "Descricao", veiculos.MarcasId);
            return View(veiculos);
        }

        // GET: Veiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veiculos veiculos = db.VeiculosSet.Find(id);
            if (veiculos == null)
            {
                return HttpNotFound();
            }
            return View(veiculos);
        }

        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculos veiculos = db.VeiculosSet.Find(id);
            db.VeiculosSet.Remove(veiculos);
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
