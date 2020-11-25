using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gunes_ticarett.Models.Entity;

namespace gunes_ticarett.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_musteri.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tbl_musteri p1)
        {
            db.tbl_musteri.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var musteri = db.tbl_musteri.Find(id);
            db.tbl_musteri.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mstrg = db.tbl_musteri.Find(id);
            return View("MusteriGetir",mstrg);
        }
        public ActionResult guncelle(tbl_musteri p1)
        {
            var mst = db.tbl_musteri.Find(p1.musteri_id);
            mst.musteri_ad = p1.musteri_ad;
            mst.musteri_soyad = p1.musteri_soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}