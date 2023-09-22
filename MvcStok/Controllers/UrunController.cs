using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        eaycoProDenemekkEntities db = new eaycoProDenemekkEntities();

        // GET: Urun
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();  
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle() {

            List<SelectListItem> degerler = (from i in db.TBLKATEGORİ.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                            }).ToList();
            ViewBag.dgr = degerler;
            return View();
            

        }

        [HttpPost]
        public  ActionResult UrunEkle(TBLURUNLER p1)

        {
            var ktg = db.TBLKATEGORİ.Where(m=>m.KATEGORIID==p1.TBLKATEGORİ.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORİ = ktg;
            
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

      

        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urun = db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            urun.MARKA = p1.MARKA;
            // urun.URUNKATEGORİ = p1.URUNKATEGORİ;
            var ktg = db.TBLKATEGORİ.Where(m => m.KATEGORIID == p1.TBLKATEGORİ.KATEGORIID).FirstOrDefault();
            urun.TBLKATEGORİ = ktg;

            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORİ.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;


            return View("UrunGetir", urun);



        }
    }
}