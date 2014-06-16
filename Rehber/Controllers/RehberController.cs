using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RehberYS.Models;
using ModelState = System.Web.Http.ModelBinding.ModelState;

namespace RehberYS.Controllers
{
    [Authorize]
    public class RehberController : Controller
    {
        //
        // GET: /Rehber/

        private IRehberRepository _repository;

        public RehberController(): this(new RehberRepository())
        {
        }

        public RehberController(IRehberRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public ActionResult Index(int page=1)
        {
            
            var item = _repository.MusterileriGetir();
            var item2 = item.OrderByDescending(p => p.Id).Skip((page - 1) * 15).Take(15).ToList();
            ViewBag.Sayfalar = Math.Ceiling((double) (item.Count()/15));
            return View(item2);
        }

        public ActionResult Details(int id)
        {
            return View(_repository.MusteriGetir(id));
        }

        //public ActionResult Details2(short id=1)
        //{
        //    if (id == null)
        //    {
        //        Rehber rhbr = new Rehber();
        //        return PartialView(rhbr);
        //    }
        //    else
        //    {
        //        return PartialView(_repository.MusteriGetir(id));
        //    }
           
        //}

        public JsonResult Details2(int id)
        {
            var _item = _repository.MusteriGetir(id);
            return Json(_item, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Create(Rehber rehber)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.MusteriEkle(rehber);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","Kayıt hatası! "+ex.Message);
                }
            }

            return View(rehber);
        }

        public ActionResult Edit(int id)
        {
            Rehber rehber = _repository.MusteriGetir(id);

            if (rehber == null)
            {
                return RedirectToAction("Index");
            }

            return View(rehber);
        }

        [HttpPost()]
        public ActionResult Edit(Models.Rehber rehber)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.MusteriDuzenle(rehber);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("","Düzenleme hatası! "+ex.Message);
                }
            }

            return View(rehber);
        }

        public ActionResult Delete(int id)
        {
            Models.Rehber rehber = _repository.MusteriGetir(id);

            if (rehber == null)
            {
                ModelState.AddModelError("", "Böyle bir kayıt yok");
                return RedirectToAction("Index");
            }

            try
            {
                _repository.MusteriSil(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Silme hatası! " + ex.Message);
            }

            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            var ss = System.Web.HttpContext.Current.Session["yoneticiAd"];

            if (ss != null)
            {
                System.Web.HttpContext.Current.Session.Remove("yoneticiAd");
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
           
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult alanekle(string alan, string deger)
        {
            _repository.AlanEkle(alan);
            return null;
        }

        public ActionResult alansil(string alan, string deger)
        {
            _repository.AlanSil(alan);
            return null;
        }
    }
}
