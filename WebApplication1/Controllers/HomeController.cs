using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContext;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
      [Authorize]
    public class HomeController : Controller
    {
        private Db _db; //

        public HomeController()
        {
            _db = new Db();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(_db.HotDog.Include(x => x.Sauce).ToList());
        }

        [Authorize]
        public ActionResult CreateHotDog()
        {
            var sauces = _db.Sauces.ToList();
            HotDogWithSauceViewModel hotDogWithSauceViewModel = new HotDogWithSauceViewModel()
            {
                Sauces = sauces,
                HotDog = new HotDog()
            };
            return View("HotDogForm", hotDogWithSauceViewModel);
        }

        public ActionResult EditHotDog(int id)
        {
            var hotDog = _db.HotDog.SingleOrDefault(x => x.Id == id);
            if (hotDog == null)
                return HttpNotFound();

            HotDogWithSauceViewModel hotDogWithSauceViewModel = new HotDogWithSauceViewModel()
            {
                Sauces = _db.Sauces.ToList(),
                HotDog = hotDog
            };

            return View("HotDogForm", hotDogWithSauceViewModel);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult AddHotDog(HotDog hotDog)
        {
            if (ModelState.IsValid)
            {
                if (hotDog.Id == 0)
                {
                    _db.HotDog.Add(hotDog);
                    _db.SaveChanges();
                }
                else
                {
                    var hotDogToUpdate = _db.HotDog.Single(x => x.Id == hotDog.Id);
                    hotDogToUpdate.Name = hotDog.Name;
                    hotDogToUpdate.Phone = hotDog.Phone;
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                var sauces = _db.Sauces.ToList();
                HotDogWithSauceViewModel hotDogWithSauceViewModel = new HotDogWithSauceViewModel()
                {
                    HotDog = hotDog,
                    Sauces = sauces
                };
                return View("HotDogForm", hotDogWithSauceViewModel);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
