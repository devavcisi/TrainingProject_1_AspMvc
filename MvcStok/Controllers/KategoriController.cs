using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        eaycoProDenemekkEntities db = new eaycoProDenemekkEntities();

        public ActionResult Index(int sayfa=1)
        {

            // var degerler= db.TBLKATEGORİ.ToList();
            var degerler = db.TBLKATEGORİ.ToList().ToPagedList(sayfa, 4);

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()

        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİ p1) 
        
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORİ.Add(p1); 
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id); 
            db.TBLKATEGORİ.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {

            var ktgr = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir",ktgr);
            
        }
        public ActionResult Guncelle(TBLKATEGORİ p1)
        {
            var ktg = db.TBLKATEGORİ.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}