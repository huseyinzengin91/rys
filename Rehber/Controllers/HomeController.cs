using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RehberYS.Models;

namespace RehberYS.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private GirisRepository _girisRepository = new GirisRepository();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Index(Giris giris)
        {
            var _item = _girisRepository.GirisYap(giris.KullaniciAd, giris.Sifre);

            if (_item != null)
            {
                FormsAuthentication.SetAuthCookie(_item.KullaniciAd, false);
                System.Web.HttpContext.Current.Session.Add("yoneticiAd", _item.KullaniciAd);

                return RedirectToAction("Index", "Rehber");
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı ya da şifre yanlış !");
                return View(giris);
            }
        }

    }
}
