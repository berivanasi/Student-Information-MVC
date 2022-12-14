using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNot_Mvc.Models.EntityFramework;

namespace OgrenciNot_Mvc.Controllers
{
    public class DefaultController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();  //OLUŞTURDUĞUM NESNE TABLOLARIMA ULAŞMAK İÇİN KULLANICAM
        public ActionResult Index()
        {
            var dersler = db.Tbl_Dersler.ToList();  // var türünde dersler adında değişken oluşturup db nesnemden gelen derlere ait alanı listele
            return View(dersler); //döndürdüm dersleri
        }
        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }
        // yeni bir controller tanımlanması yap
       [HttpPost]
        public ActionResult YeniDers(Tbl_Dersler p)
        {
            db.Tbl_Dersler.Add(p); //EKLE
            db.SaveChanges();  //KAYDET
            return View();
        }
      public ActionResult Sil(int id)
        {
            var ders = db.Tbl_Dersler.Find(id);
            db.Tbl_Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.Tbl_Dersler.Find(id);
            
            return View("DersGetir",ders);
        }
           public ActionResult Guncelle(Tbl_Dersler p)
        {
            var drs = db.Tbl_Dersler.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}