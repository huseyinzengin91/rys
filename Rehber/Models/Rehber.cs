using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace RehberYS.Models
{
    public class Rehber
    {
        public Rehber()
        {
            this.Id = 0;
            this.AdSoyad = null;
            this.Telefon = null;
            this.Eposta = null;
            this.Adres = null;
            this.Not = null;
            this.Meslek = null;
            this.Tarih = null;
            this.Durum = false;
            this.Gorusme = false;
            this.Egitim = false;
            
        }

        public Rehber(int id, string adSoyad, string telefon, string eposta,
            string adres, string not, string meslek, string tarih, bool durum, bool alan, bool egitim)
        {
            this.Id = id;
            this.AdSoyad = adSoyad;
            this.Telefon = telefon;
            this.Eposta = eposta;
            this.Adres = adres;
            this.Not = not;
            this.Meslek = meslek;
            this.Tarih = tarih;
            this.Durum = durum;
            this.Gorusme = alan;
            this.Egitim = egitim;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunlu")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Telefon zorunlu")]
        public string Telefon { get; set; }

        public string Eposta { get; set; }

        public string Adres { get; set; }

        public string Not { get; set; }

        public string Meslek { get; set; }

        public string Tarih { get; set; }

        public bool Durum { get; set; }
        
        public bool Gorusme { get; set; }

        public bool Egitim { get; set; }
    }
}