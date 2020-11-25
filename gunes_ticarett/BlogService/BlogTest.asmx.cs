using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using gunes_ticarett.Models.Entity;
using gunes_ticarett.Models;



namespace gunes_ticarett.BlogService
{
    /// <summary>
    /// Summary description for BlogTest
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BlogTest : System.Web.Services.WebService
    {
        stokEntities db=new stokEntities();
        
        
        [WebMethod]
        public List<Musteri> Musteris(string userName, string password)
        {
            string un = "abdulselam";
            string pass = "123456";

            if (userName == un && password == pass)
            {
                var musteriList = (from m in db.tbl_musteri

                                   select new Musteri
                                   {
                                       musteri_id = m.musteri_id,
                                       musteri_ad = m.musteri_ad,
                                       musteri_soyad = m.musteri_soyad
                                   }

                                   ).ToList();
                return musteriList;
            }
            else
            {
                List<Musteri> error = new List<Musteri>();
                Musteri ER = new Musteri();
                //ER.musteri_statu = "SERVİS İÇİN YETKİSİZ GİRİŞ";
                error.Add(ER);
                return error;
            }
        }
        public partial class Musteri
        {
            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            //public musteri()
            //{
            //    this.tbl_satis = new HashSet<tbl_satis>();
            //}

            public int musteri_id { get; set; }
            public string musteri_ad { get; set; }
            public string musteri_soyad { get; set; }
            //public string musteri_statu { get; set; }

            //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            //public virtual ICollection<tbl_satis> tbl_satis { get; set; }
        }
    }
}
