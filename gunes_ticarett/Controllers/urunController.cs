using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gunes_ticarett.Models.Entity;

namespace gunes_ticarett.Controllers
{
    public class urunController : Controller
    {
        // GET: urun
        stokEntities db = new stokEntities();
        public ActionResult Index()
        {
            var degerler = db.tbl_urunler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yeniurun()
        {
            List<SelectListItem> degerler = (from i in db.tbl_kategori.ToList() select new SelectListItem
            {
                Text = i.kategori_ad, Value = i.kategori_id.ToString()
            }).ToList();
         
                ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult yeniurun(tbl_urunler p1)
        {
                var ktg = db.tbl_kategori.Where(m => m.kategori_id == p1.tbl_kategori.kategori_id).FirstOrDefault();
                p1.tbl_kategori = ktg;
                db.tbl_urunler.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult sil(int id)
        {
            var urun = db.tbl_urunler.Find(id);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult urunGetir(int id)
        {
            var urn = db.tbl_urunler.Find(id);
            return View("urunGetir",urn);
        }
        //public ActionResult Guncelle(tbl_urunler p1)
        //{
        //    var ur = db.tbl_urunler.Find(p1.urun_id);
        //    ur.urun_ad = p1.urun_ad;
        //    ur.urun_marka = p1.urun_marka;
        //    ur.urun_kategori = p1.urun_kategori;
        //    ur.urun_fiyat = p1.urun_fiyat;
        //    ur.urun_stok = p1.urun_stok;

        //}
    }
}