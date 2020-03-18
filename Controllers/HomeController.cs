using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            List<string> search = new List<string>();
            List<int> sort = new List<int>();
            var rent = from x in AppDbContext.Cars where x.status == "Free" select x;
            search.Add(Search);
            sort.Add(Sort);
            var sortlast = (from s in sort orderby s select s).LastOrDefault();
            ViewBag.Sort = sortlast;
            var searchlast = (from s in search orderby s select s).LastOrDefault();
            ViewBag.Search = searchlast;
            if (Sort == 0 && !String.IsNullOrEmpty(Search))
            {
                Console.WriteLine("coba sort 0");
                Console.WriteLine(Sort);
                var get = HttpContext.Session.GetString("Id");
                var status = HttpContext.Session.GetString("Status");
                var name = HttpContext.Session.GetString("Name");
                ViewBag.Name = name;
                ViewBag.Status = status;
                ViewBag.User = get;
                var cars = from l in AppDbContext.Cars where l.brand.Contains(Search) || l.description.Contains(Search) || l.type.Contains(Search) where l.status == "Free" select l;
                ViewBag.Car = cars;
                return View("Index");
            }
            if (Sort != 0 && String.IsNullOrEmpty(Search))
            {
                var get = HttpContext.Session.GetString("Id");
                var status = HttpContext.Session.GetString("Status");
                var name = HttpContext.Session.GetString("Name");
                ViewBag.Name = name;
                ViewBag.Status = status;
                ViewBag.User = get;

                if (Sort == 1)
                {
                    Console.WriteLine("coba atas");
                    Console.WriteLine(searchlast);
                    Console.WriteLine(Sort);
                    var data = AppDbContext.Cars.OrderBy(s => s.type).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 2)
                {
                    Console.WriteLine("coba sini");
                    Console.WriteLine(Search);
                    Console.WriteLine(Sort);
                    var data = AppDbContext.Cars.OrderByDescending(s => s.type).Where(s => s.status == "Free");
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 3)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.brand).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 4)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.brand).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 5)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.priceperday).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 6)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.priceperday).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                return View("Index");
            }
            if (Sort != 0 && !String.IsNullOrEmpty(Search))
            {
                var get = HttpContext.Session.GetString("Id");
                var status = HttpContext.Session.GetString("Status");
                var name = HttpContext.Session.GetString("Name");
                ViewBag.Name = name;
                ViewBag.Status = status;
                ViewBag.User = get;

                if (Sort == 1)
                {
                    Console.WriteLine("atas");
                    Console.WriteLine(searchlast);
                    Console.WriteLine(Sort);
                    var data = AppDbContext.Cars.OrderBy(s => s.type).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 2)
                {
                    Console.WriteLine("bawah");
                    Console.WriteLine(Search);
                    Console.WriteLine(Sort);
                    var data = AppDbContext.Cars.OrderByDescending(s => s.type).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 3)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.brand).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 4)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.brand).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 5)
                {
                    var data = AppDbContext.Cars.OrderBy(s => s.priceperday).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                if (Sort == 6)
                {
                    var data = AppDbContext.Cars.OrderByDescending(s => s.priceperday).Where(s => s.status == "Free").Where(s => s.brand.Contains(Search) || s.description.Contains(Search) || s.type.Contains(Search));
                    ViewBag.Car = data;
                    var gets = HttpContext.Session.GetString("Id");
                    var statuss = HttpContext.Session.GetString("Status");
                    var names = HttpContext.Session.GetString("Name");
                    ViewBag.Name = names;
                    ViewBag.Status = statuss;
                    ViewBag.User = get;
                    return View("Index");
                }
                return View("Index");
            }
            else
            {
                var get = HttpContext.Session.GetString("Id");
                var status = HttpContext.Session.GetString("Status");
                var name = HttpContext.Session.GetString("Name");
                ViewBag.Name = name;
                ViewBag.Status = status;
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
