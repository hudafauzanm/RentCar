using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public HomeController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }

        public IActionResult Index(int Sort, string Search = "")
        {
            var rent = from x in AppDbContext.Cars where x.status == "Free" select x;
            ViewBag.Sort = Sort;
            ViewBag.Search = Search;
            if (!String.IsNullOrEmpty(Search) || !String.IsNullOrWhiteSpace(Search))
            {
                var get = HttpContext.Session.GetString("Id");
                ViewBag.User = get;
                var cars = from l in AppDbContext.Cars where l.brand.Contains(Search) || l.description.Contains(Search) where l.status == "Free" select l;
                ViewBag.Car = cars;
                return View("Index");
            }
            if (Sort != 0)
            {
                var get = HttpContext.Session.GetString("Id");
                ViewBag.User = get;
                var value = Sort;
                ViewBag.Sort = value;

                if (Sort == 1)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.brand).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 2)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.brand).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 3)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.priceperday).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 4)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.priceperday).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    ViewBag.User = get;
                    return View("Index");
                }
                return View("Index");
            }
            else
            {
                var get = HttpContext.Session.GetString("Id");
                ViewBag.User = get;
                var cars = from l in AppDbContext.Cars where l.status == "Free" select l;
                ViewBag.Car = cars;
                return View("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
