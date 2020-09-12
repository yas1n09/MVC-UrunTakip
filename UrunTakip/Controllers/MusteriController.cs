using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakip.Models.Entity;


namespace UrunTakip.Controllers
{
    [Authorize]
    public class MusteriController : Controller
    {
        // GET: Musteri
        UrunTakipEntities2 db = new UrunTakipEntities2();
        [Authorize]
        public ActionResult Index(String p)
        {
            var degerler =from d in db.TBL_Musteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_Musteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBL_Musteriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var mus = db.TBL_Musteriler.Find(id);
            db.TBL_Musteriler.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBL_Musteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TBL_Musteriler p1)
        {
            var mus = db.TBL_Musteriler.Find(p1.MusteriId);
            mus.MusteriAd = p1.MusteriAd;
            mus.MusteriSoyad = p1.MusteriSoyad;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}