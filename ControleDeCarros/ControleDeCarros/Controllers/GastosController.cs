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
    public class GastosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Gastos
        public ActionResult Index()
        {
            var gastosSet = db.GastosSet.Include(g => g.SubTiposGastos).Include(g => g.Veiculos);
            return View(gastosSet.ToList());
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.GastosSet.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            ViewBag.SubTiposGastosId = new SelectList(db.SubTiposGastosSet, "Id", "Descricao");
            ViewBag.VeiculosId = new SelectList(db.VeiculosSet, "Id", "Nome");
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Data,SubTiposGastosId,VeiculosId")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.GastosSet.Add(gastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubTiposGastosId = new SelectList(db.SubTiposGastosSet, "Id", "Descricao", gastos.SubTiposGastosId);
            ViewBag.VeiculosId = new SelectList(db.VeiculosSet, "Id", "Nome", gastos.VeiculosId);
            return View(gastos);
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.GastosSet.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubTiposGastosId = new SelectList(db.SubTiposGastosSet, "Id", "Descricao", gastos.SubTiposGastosId);
            ViewBag.VeiculosId = new SelectList(db.VeiculosSet, "Id", "Nome", gastos.VeiculosId);
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Data,SubTiposGastosId,VeiculosId")] Gastos gastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubTiposGastosId = new SelectList(db.SubTiposGastosSet, "Id", "Descricao", gastos.SubTiposGastosId);
            ViewBag.VeiculosId = new SelectList(db.VeiculosSet, "Id", "Nome", gastos.VeiculosId);
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gastos gastos = db.GastosSet.Find(id);
            if (gastos == null)
            {
                return HttpNotFound();
            }
            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gastos gastos = db.GastosSet.Find(id);
            db.GastosSet.Remove(gastos);
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
