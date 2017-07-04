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
    public class SubTiposGastosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: SubTiposGastos
        public ActionResult Index()
        {
            var subTiposGastosSet = db.SubTiposGastosSet.Include(s => s.TiposGastos);
            return View(subTiposGastosSet.ToList());
        }

        // GET: SubTiposGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTiposGastos subTiposGastos = db.SubTiposGastosSet.Find(id);
            if (subTiposGastos == null)
            {
                return HttpNotFound();
            }
            return View(subTiposGastos);
        }

        // GET: SubTiposGastos/Create
        public ActionResult Create()
        {
            ViewBag.TiposGastosId = new SelectList(db.TiposGastosSet, "Id", "Descricao");
            return View();
        }

        // POST: SubTiposGastos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,TiposGastosId")] SubTiposGastos subTiposGastos)
        {
            if (ModelState.IsValid)
            {
                db.SubTiposGastosSet.Add(subTiposGastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TiposGastosId = new SelectList(db.TiposGastosSet, "Id", "Descricao", subTiposGastos.TiposGastosId);
            return View(subTiposGastos);
        }

        // GET: SubTiposGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTiposGastos subTiposGastos = db.SubTiposGastosSet.Find(id);
            if (subTiposGastos == null)
            {
                return HttpNotFound();
            }
            ViewBag.TiposGastosId = new SelectList(db.TiposGastosSet, "Id", "Descricao", subTiposGastos.TiposGastosId);
            return View(subTiposGastos);
        }

        // POST: SubTiposGastos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,TiposGastosId")] SubTiposGastos subTiposGastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subTiposGastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposGastosId = new SelectList(db.TiposGastosSet, "Id", "Descricao", subTiposGastos.TiposGastosId);
            return View(subTiposGastos);
        }

        // GET: SubTiposGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTiposGastos subTiposGastos = db.SubTiposGastosSet.Find(id);
            if (subTiposGastos == null)
            {
                return HttpNotFound();
            }
            return View(subTiposGastos);
        }

        // POST: SubTiposGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTiposGastos subTiposGastos = db.SubTiposGastosSet.Find(id);
            db.SubTiposGastosSet.Remove(subTiposGastos);
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
