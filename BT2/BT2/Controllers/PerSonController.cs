using BT2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BT2.Controllers
{
    [Authorize]
    public class PerSonController : Controller
    {
        private LTQLDbConText db = new LTQLDbConText();
        Autogenkey autoK = new Autogenkey();
        PerSon ps = new PerSon();
        // GET: PerSon
        
        public ActionResult Index()
        {
            
            return View(db.PerSons.ToList());
        }

        public ActionResult Create()
        {
            //var PsID = db.PerSons.OrderByDescending(m => m.PerSonID).FirstOrDefault().PerSonID;
            //var newID = autoK.GenKey("PS", PsID);
            //ViewBag.newperID = newID;
            return View();
        }

        [HttpPost]

        public ActionResult Create(PerSon ps)
        {
            if(ModelState.IsValid)
            {
                db.PerSons.Add(ps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ps);
        }
        
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerSon ps = db.PerSons.Find(id);
            if(ps == null)
            {
                return HttpNotFound();

            }
            return View(ps);
        }

        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PerSon ps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ps);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerSon ps = db.PerSons.Find(id);
            if (ps == null)
            {
                return HttpNotFound();

            }else if(ps!=null)
            {
                db.PerSons.Remove(ps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(ps);
        }

        //[HttpPost,ActionName("Delete")]
        //public ActionResult DeleteConFirm(string id)
        //{
        //    PerSon ps = db.PerSons.Find(id);
            
        //}
    }
}