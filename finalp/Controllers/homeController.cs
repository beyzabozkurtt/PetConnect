using finalp.Models;
using finalp.Models.manager;
using finalp.Models.viewmodel;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace finalp.Controllers
{
    public class HomeController : Controller
    {
        private databasecontext db = new databasecontext();

        [HttpGet]
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult AdoptAPet()
        {
            var pet = db.adopt_tablosu.ToList();
            return View(pet);
        }

        [Authorize]
        public ActionResult AdminsPage()
        {
            var petList = db.adopt_tablosu.ToList();
            var iletisimListesi = db.iletisim_tablosu.ToList();
            string User = HttpContext.User.Identity.Name;
            ViewBag.User = User.ToString();
            var viewModel = new adminspagevm
            {
                AdoptList = petList,
                IletisimList = iletisimListesi
            };



            return View(viewModel);
        }

        [HttpPost, ActionName("AdminsPage")]
        public ActionResult AdminsPageOK()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "home");
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(tbl_adopt pets)
        {
            db.adopt_tablosu.Add(pets);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.result = "Kaydedildi";
                ViewBag.status = "success";
            }
            else
            {
                ViewBag.result = "Kayıt başarısız";
                ViewBag.status = "danger";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Duzenle(int? petid)
        {
            var pet = db.adopt_tablosu.FirstOrDefault(x => x.id == petid);
            return View(pet);
        }

        [HttpPost]
        public ActionResult Duzenle(tbl_adopt model, int? petid)
        {
            var pets = db.adopt_tablosu.FirstOrDefault(x => x.id == petid);
            if (pets != null)
            {
                pets.isim = model.isim;
                pets.tur = model.tur;
                pets.cins = model.cins;
                pets.yas = model.yas;
                pets.cinsiyet = model.cinsiyet;
                pets.ozellik = model.ozellik;
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    ViewBag.result = "Kayıt güncellendi";
                    ViewBag.status = "success";
                }
                else
                {
                    ViewBag.result = "Güncelleme başarısız";
                    ViewBag.status = "danger";
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Sil(int? petid)
        {
            var pets = db.adopt_tablosu.FirstOrDefault(x => x.id == petid);
            return View(pets);
        }

        [HttpPost, ActionName("Sil")]
        public ActionResult SilOK(int? petid)
        {
            if (petid != null)
            {
                var pets = db.adopt_tablosu.FirstOrDefault(x => x.id == petid);

                if (pets != null)
                {
                    db.adopt_tablosu.Remove(pets);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("AdminsPage", "home");
        }

        [HttpPost]
        public ActionResult Anasayfa(iletisim model)
        {
            if (ModelState.IsValid)
            {
                db.iletisim_tablosu.Add(model);
                db.SaveChanges();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "home");
            }

            return View(user);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var matchedUser = db.users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (matchedUser != null)
            {
                //Session["session"] = user.username;
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("AdminsPage", "home");


            }
            else
            {
                ViewBag.giris = "hatali giris";
                return View(user);
            }



        }
        //kaybolan hayvan ilanlar sayfasi kodlari

        public ActionResult ilanlar()
        {
            var ilanlar = db.ilanlars.ToList();
            return View(ilanlar);
        }
        public ActionResult ilanformu()
        {

            return View();
        }


        [HttpPost]


        public ActionResult ilanformu(ilanlar model)
        {
            if (ModelState.IsValid)
            {
                db.ilanlars.Add(model);
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("ilanlar", "home");
                }
            }
            return View(model);
        }

        //blog sayfasi
        public ActionResult blogsayfasi()
        {
            var blog = db.blogs.ToList();
            return View(blog);


        }
        public ActionResult bagis()
        {

            return View();
        }
        public ActionResult blogformu()
        {

            return View();
        }
        [HttpPost]


        public ActionResult blogformu(blog model)
        {
            if (ModelState.IsValid)
            {
                db.blogs.Add(model);
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("blogsayfasi", "home");
                }
            }
            return View(model);
        }
        public ActionResult bagisyap()
        {

            return View();
        }
        [HttpPost]


        public ActionResult bagisyap(bagislar model)
        {
            if (ModelState.IsValid)
            {
                db.bagis.Add(model);
                int sonuc = db.SaveChanges();
                if (sonuc > 0)
                {
                    return RedirectToAction("Anasayfa", "home");
                }
            }
            return View(model);
        }
    }
}
