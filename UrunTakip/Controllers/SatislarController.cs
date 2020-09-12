using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrunTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace UrunTakip.Controllers
{
    [Authorize]
    public class SatislarController : Controller
    {
        // GET: Satislar
        UrunTakipEntities2 db = new UrunTakipEntities2();
        
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBL_Satislar.ToList();
            var degerler = db.TBL_Satislar.ToList().ToPagedList(sayfa, 8);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBL_Urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunAdi,
                                                 Value = i.UrunId.ToString()
                                             }).ToList();
            
            ViewBag.dgr = degerler;



            List<SelectListItem> degerler1 = (from i in db.TBL_Musteriler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MusteriAd + " " + i.MusteriSoyad,
                                                  Value = i.MusteriId.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;


            //List<SelectListItem> degerler2 = (from i in db.TBL_Satislar.ToList()
            //                                  select new SelectListItem
            //                                  {
            //                                      Text = i.KamyonDurum.ToString(),
            //                                      Value = i.KamyonDurum.ToString()
            //                                 }).ToList();

            //ViewBag.dgr2 = degerler2;


            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(TBL_Satislar p1)
        {
            var urn = db.TBL_Urunler.Where(m => m.UrunId == p1.TBL_Urunler.UrunId).FirstOrDefault();
            p1.TBL_Urunler = urn;
            db.TBL_Satislar.Add(p1);

            var mus = db.TBL_Musteriler.Where(m => m.MusteriId == p1.TBL_Musteriler.MusteriId).FirstOrDefault();
            p1.TBL_Musteriler = mus;
            db.TBL_Satislar.Add(p1);
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var sts = db.TBL_Satislar.Find(id);
            db.TBL_Satislar.Remove(sts);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        

        public ActionResult SatisGetir(int id)
        {
            var sts = db.TBL_Satislar.Find(id);
            List<SelectListItem> degerler = (from i in db.TBL_Urunler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.UrunAdi,
                                                 Value = i.UrunId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            List<SelectListItem> degerler1 = (from i in db.TBL_Musteriler.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.MusteriAd + " " + i.MusteriSoyad,
                                                  Value = i.MusteriId.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;

            
            return View("SatisGetir",sts);
        }
        [HttpPost]
        public ActionResult Guncelle(TBL_Satislar p1)
        {
            var sts = db.TBL_Satislar.Find(p1.SatisId);
            sts.Urun = p1.Urun;
            sts.Musteri = p1.Musteri;
            sts.Adet = p1.Adet;
            sts.Fiyat = p1.Fiyat;
            sts.SevkTarihi = p1.SevkTarihi;
            sts.KamyonPlaka = p1.KamyonPlaka;
            sts.KamyonDurum = p1.KamyonDurum;

            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}