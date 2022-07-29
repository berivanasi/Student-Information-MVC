using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNot_Mvc.Models.EntityFramework;

namespace OgrenciNot_Mvc.Controllers
{
    public class KulupController : Controller
    {
        DbMvcOkulEntities db = new DbMvcOkulEntities();  //OLUŞTURDUĞUM NESNE TABLOLARIMA ULAŞMAK İÇİN KULLANICAM

        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList(); // değişken oluşturun kulup diye Kuluplerin listele
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("KulupGetir",kulup);
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index" ,"Kulup");
            
        }
    }
}