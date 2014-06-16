using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Security;
using System.Xml.Linq;

namespace RehberYS.Models
{
    public class GirisRepository
    {
        private List<Giris> TumYoneticiler;
        private XDocument YoneticiData;

        public GirisRepository()
        {
            TumYoneticiler = new List<Giris>();
            YoneticiData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));

            var yoneticiler = from yonetici in YoneticiData.Descendants("yoneticim")
                  select new Giris(yonetici.Element("kullaniciad").Value,yonetici.Element("sifre").Value);


            TumYoneticiler.AddRange(yoneticiler.ToList<Giris>());
        }

        public Giris GirisYap(string kullaniciAd, string sifre)
        {
            return TumYoneticiler.Find(z => z.KullaniciAd == kullaniciAd && z.Sifre == sifre);
        }
    }
}