using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using UrunTakip.Models.Entity;

namespace UrunTakip.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        // GET: Urunler
        UrunTakipEntities2 db = new UrunTakipEntities2();
        
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBL_Urunler.ToList();
            var degerler = db.TBL_Urunler.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBL_Urunler p1)
        {
            db.TBL_Urunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var urn = db.TBL_Urunler.Find(id);
            db.TBL_Urunler.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBL_Urunler.Find(id);
            return View("UrunGetir", urn);
        }
        public ActionResult Guncelle(TBL_Urunler p1)
        {
            var urn = db.TBL_Urunler.Find(p1.UrunId);
            urn.UrunAdi = p1.UrunAdi;
            urn.UrunFiyat = p1.UrunFiyat;
            urn.Stok = p1.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
    
}