using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gunes_ticarett.Models.Entity;

namespace gunes_ticarett.Controllers
{
    public class KategoriController : Controller
    {
        // stokEntities
        // GET: Kategori
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_kategori.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tbl_kategori p1)
        {
            if (!ModelState.IsValid) 
            {
                return View("YeniKategori");
            }
            db.tbl_kategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult sil(int id)
        {
            var kategori = db.tbl_kategori.Find(id);
            db.tbl_kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.tbl_kategori.Find(id);
            return View("KategoriGetir",ktgr);
        }
public ActionResult guncelle(tbl_kategori p1)
        {
            var ktg = db.tbl_kategori.Find(p1.kategori_id);
            ktg.kategori_ad = p1.kategori_ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
