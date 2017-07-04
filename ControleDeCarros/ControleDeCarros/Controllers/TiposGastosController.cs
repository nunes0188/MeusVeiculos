using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ControleDeCarros.Models
{
    public class TiposGastosController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: TiposGastos
        public ActionResult Index()
        {
            return View(db.TiposGastosSet.ToList());
        }

        // GET: TiposGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposGastos tiposGastos = db.TiposGastosSet.Find(id);
            if (tiposGastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposGastos);
        }

        // GET: TiposGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposGastos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao")] TiposGastos tiposGastos)
        {
            if (ModelState.IsValid)
            {
                db.TiposGastosSet.Add(tiposGastos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposGastos);
        }

        // GET: TiposGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposGastos tiposGastos = db.TiposGastosSet.Find(id);
            if (tiposGastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposGastos);
        }

        // POST: TiposGastos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao")] TiposGastos tiposGastos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposGastos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposGastos);
        }

        // GET: TiposGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposGastos tiposGastos = db.TiposGastosSet.Find(id);
            if (tiposGastos == null)
            {
                return HttpNotFound();
            }
            return View(tiposGastos);
        }

        // POST: TiposGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposGastos tiposGastos = db.TiposGastosSet.Find(id);
            db.TiposGastosSet.Remove(tiposGastos);
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
