using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace RehberYS.Models
{

    public class Giris
    {
        public Giris()
        {
            this.KullaniciAd = null;
            this.Sifre = null;

        }

        public Giris(string kullaniciAd, string sifre)
        {
            this.KullaniciAd = kullaniciAd;
            this.Sifre = sifre;
        }

        [Required(ErrorMessage = "Kullanıcı Adı zorunlu!")]
        public string KullaniciAd { get; set; }

        [Required(ErrorMessage = "Şifre zorunlu!")]
        public string Sifre { get; set; }
    }
}