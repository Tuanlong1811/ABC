using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BT2.Models;

namespace BT2.Controllers
{
    [Authorize]
    public class InfoPerSonsController : Controller
    {
        private LTQLDbConText db = new LTQLDbConText();
        GenKeyAuto genkey = new GenKeyAuto();
        Autogenkey autoK = new Autogenkey();
        // GET: InfoPerSons
        public ActionResult Index()
        {
            return View(db.InfoPerSons.ToList());
        }

        // GET: InfoPerSons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoPerSon infoPerSon = db.InfoPerSons.Find(id);
            if (infoPerSon == null)
            {
                return HttpNotFound();
            }
            return View(infoPerSon);
        }

        // GET: InfoPerSons/Create
        public ActionResult Create()
        {
            var PsID = db.PerSons.OrderByDescending(m => m.PerSonID).FirstOrDefault().PerSonID;
            var newID = genkey.generatekey(PsID, 3);
            ViewBag.newperID = newID;
            return View();
        }

        // POST: InfoPerSons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerSonID,PsName,Address,Description,Sex")] InfoPerSon infoPerSon)
        {
            if (ModelState.IsValid)
            {
                db.PerSons.Add(infoPerSon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(infoPerSon);
        }

        // GET: InfoPerSons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoPerSon infoPerSon = db.InfoPerSons.Find(id);
            if (infoPerSon == null)
            {
                return HttpNotFound();
            }
            return View(infoPerSon);
        }

        // POST: InfoPerSons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerSonID,PsName,Address,Description,Sex")] InfoPerSon infoPerSon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infoPerSon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(infoPerSon);
        }

        // GET: InfoPerSons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InfoPerSon infoPerSon = db.InfoPerSons.Find(id);
            if (infoPerSon == null)
            {
                return HttpNotFound();
            }
            return View(infoPerSon);
        }

        // POST: InfoPerSons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            InfoPerSon infoPerSon = db.InfoPerSons.Find(id);
            db.PerSons.Remove(infoPerSon);
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
