using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using PagedList.Mvc;
using UrunTakip.Models.Entity;



namespace UrunTakip.Controllers
{
    
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        UrunTakipEntities2 db = new UrunTakipEntities2();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_Users t)
        {
            var bilgiler = db.TBL_Users.FirstOrDefault(x => x.UserName == t.UserName && x.UserPassword == t.UserPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.UserName, false);
                return RedirectToAction("Index", "Urunler");
            }
            else
            {
                return View();
            }

        }

        public ActionResult CikisYap()
        {
            Session.Abandon();

            return RedirectToAction("GirisYap", "Guvenlik");
        }
        
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            
            var degerler = db.TBL_Users.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKullanici()
        {
            return View();
        }

        
        public ActionResult YeniKullanici(TBL_Users p1)
        {
            db.TBL_Users.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var usr = db.TBL_Users.Find(id);
            db.TBL_Users.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KullaniciGetir(int id)
        {
            var usr = db.TBL_Users.Find(id);
            return View("KullaniciGetir", usr);
        }
        public ActionResult Guncelle(TBL_Users p1)
        {
            var usr = db.TBL_Users.Find(p1.UserId);
            usr.UserName = p1.UserName;
            usr.UserPassword = p1.UserPassword;
          
            db.SaveChanges();
            return Redirect("Index");
        }
    }
}