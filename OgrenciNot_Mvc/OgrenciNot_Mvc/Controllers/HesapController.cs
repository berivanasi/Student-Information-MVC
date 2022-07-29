using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNot_Mvc.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Index(double sayi1 =0, double sayi2= 0)
        {
            double toplam = sayi1 + sayi2;
            double cıkarma = sayi1 - sayi2;
            double carma = sayi1 * sayi2;
            double bolme = sayi1 / sayi2;



            ViewBag.tpl = toplam;
            ViewBag.ckr = cıkarma;
            ViewBag.crp = carma;
            ViewBag.blm = bolme;
            ViewBag.sayi1 = sayi1;
            ViewBag.sayi2 = sayi2;


            return View();
        }
    }
}