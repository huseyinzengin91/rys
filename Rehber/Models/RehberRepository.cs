using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RehberYS.Models
{
    public class RehberRepository:IRehberRepository
    {
        private List<Rehber> TumMusteriler;
        private XDocument MusteriData;

        public RehberRepository()
        {
            TumMusteriler = new List<Rehber>();
            MusteriData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));

            var musteriler = from musteri in MusteriData.Descendants("musterim")
                             select new Rehber((int)musteri.Element("id"), musteri.Element("adsoyad").Value,
                             musteri.Element("telefon").Value,musteri.Element("eposta").Value,
                             musteri.Element("adres").Value,musteri.Element("not").Value,
                             musteri.Element("meslek").Value, musteri.Element("tarih").Value,
                             (bool)musteri.Element("durum"), (bool)musteri.Element("gorusme"),(bool)musteri.Element("egitim"));

            TumMusteriler.AddRange(musteriler.ToList<Rehber>());
        }

        public IEnumerable<Rehber> MusterileriGetir()
        {
            return TumMusteriler;

        }

        public Rehber MusteriGetir(int id)
        {
            return TumMusteriler.Find(z => z.Id == id);
        }

        public void MusteriEkle(Rehber rehber)
        {
            rehber.Id = (int)(from musteri in MusteriData.Descendants("musterim") orderby (int)musteri.Element("id") descending select (int)musteri.Element("id")).FirstOrDefault() + 1;
            MusteriData.Root.Add(new XElement("musterim", new XElement("id", rehber.Id), new XElement("adsoyad", rehber.AdSoyad),
                new XElement("telefon", rehber.Telefon), new XElement("eposta", rehber.Eposta), new XElement("adres", rehber.Adres),
                new XElement("not", rehber.Not), new XElement("meslek", rehber.Meslek), new XElement("tarih", rehber.Tarih),
                new XElement("durum", rehber.Durum), new XElement("gorusme", rehber.Gorusme), new XElement("egitim", rehber.Egitim)));

            MusteriData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));
        }

        public void MusteriSil(int id)
        {
            MusteriData.Root.Elements("musterim").Where(z => (int)z.Element("id") == id).Remove();

            MusteriData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));
        }

        public void MusteriDuzenle(Rehber rehber)
        {
            XElement node = MusteriData.Root.Elements("musterim").Where(z => (int)z.Element("id") == rehber.Id).FirstOrDefault();

            node.SetElementValue("adsoyad", rehber.AdSoyad);
            node.SetElementValue("telefon", rehber.Telefon);
            node.SetElementValue("eposta", rehber.Eposta);
            node.SetElementValue("adres", rehber.Adres);
            node.SetElementValue("not", rehber.Not);
            node.SetElementValue("meslek", rehber.Meslek);
            node.SetElementValue("tarih", rehber.Tarih);
            node.SetElementValue("durum", rehber.Durum);
            node.SetElementValue("gorusme",rehber.Gorusme);
            node.SetElementValue("egitim", rehber.Egitim);
            

            MusteriData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));
        }

        public void AlanEkle(string alan)
        {
            IEnumerable<XElement> node = MusteriData.Root.Elements("musterim");
            foreach (var xe in node)
            {
                xe.Add(new XElement(alan,""));
            }
            MusteriData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));

        }

        public void AlanSil(string alan)
        {
            IEnumerable<XElement> node = MusteriData.Root.Elements("musterim");
            foreach (var xe in node)
            {
                xe.Element(alan).Remove();
            }
            MusteriData.Save(HttpContext.Current.Server.MapPath("~/App_Data/Rehber.xml"));

        }
    }
}