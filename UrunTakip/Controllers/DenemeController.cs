using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UrunTakip.Models.Entity;

namespace UrunTakip.Controllers
{
    [Authorize]
    public class DenemeController : Controller
    {
        private UrunTakipEntities2 db = new UrunTakipEntities2();

        // GET: Deneme
        public ActionResult Index()
        {
            return View(db.TBL_Users.ToList());
        }

        // GET: Deneme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // GET: Deneme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deneme/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserName,UserPassword")] TBL_Users tBL_Users)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Users.Add(tBL_Users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Users);
        }

        // GET: Deneme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // POST: Deneme/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserName,UserPassword")] TBL_Users tBL_Users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Users);
        }

        // GET: Deneme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            if (tBL_Users == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Users);
        }

        // POST: Deneme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Users tBL_Users = db.TBL_Users.Find(id);
            db.TBL_Users.Remove(tBL_Users);
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
