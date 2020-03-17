using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class CarController : Controller
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public CarController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: Car
        public ActionResult Index()
        {
            var car = from x in AppDbContext.Cars select x;
            ViewBag.Car = car;
            return View("Car");
        }

        // GET: Car
        public ActionResult AddCar()
        {
            var user = from x in AppDbContext.Users where x.status == 2 select x;
            ViewBag.User = user;
            return View("AddCar");
        }

        // GET: Car/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Owner,string Brand,string Type,string Production,string CountSeat,string Price,string Transmision,string Baggage,string AC,string Fuel, [FromForm(Name = "FrontCar")]IFormFile FrontCar, [FromForm(Name = "BackCar")]IFormFile BackCar, [FromForm(Name = "TopCar")]IFormFile TopCar, [FromForm(Name = "LeftCar")]IFormFile LeftCar, [FromForm(Name = "RightCar")]IFormFile RightCar,string Deskripsi)
        {
            try
            {
                if (!System.IO.Directory.Exists("wwwroot" + "/Image/"))
                {
                    System.IO.Directory.CreateDirectory("wwwroot" + "/Image/");
                }
                string storePath = "wwwroot/Image/";
                if (FrontCar != null && BackCar != null && LeftCar != null && RightCar != null && TopCar != null)
                {
                    Console.WriteLine("Data masuk");
                    var pathf = Path.Combine(storePath, FrontCar.FileName);
                    var pathb = Path.Combine(storePath, BackCar.FileName);
                    var patht = Path.Combine(storePath, TopCar.FileName);
                    var pathr = Path.Combine(storePath, RightCar.FileName);
                    var pathl = Path.Combine(storePath, LeftCar.FileName);
                    using (var stream = new FileStream(pathf, FileMode.Create))
                    {
                        FrontCar.CopyTo(stream);
                    }
                    using (var stream = new FileStream(pathb, FileMode.Create))
                    {
                        BackCar.CopyTo(stream);
                    }
                    using (var stream = new FileStream(patht, FileMode.Create))
                    {
                        TopCar.CopyTo(stream);
                    }
                    using (var stream = new FileStream(pathr, FileMode.Create))
                    {
                        RightCar.CopyTo(stream);
                    }
                    using (var stream = new FileStream(pathl, FileMode.Create))
                    {
                        LeftCar.CopyTo(stream);
                    }
                    var pathffix = pathf.Substring(8);
                    var pathbfix = pathb.Substring(8);
                    var pathtfix = patht.Substring(8);
                    var pathrfix = pathr.Substring(8);
                    var pathlfix = pathl.Substring(8);
                    Car Car = new Car()
                    {
                        owner = Owner,
                        brand = Brand,
                        type = Type,
                        production_year = Production,
                        seat = CountSeat,
                        priceperday = Price,
                        transmision = Transmision,
                        ac = AC,
                        fuel = Fuel,
                        status = "Free",
                        baggage = Baggage,
                        front_image = pathffix,
                        back_image = pathbfix,
                        top_image = pathtfix,
                        left_image = pathlfix,
                        right_image = pathrfix,
                        description = Deskripsi
                    };
                    AppDbContext.Cars.Add(Car);
                }
                AppDbContext.SaveChanges();
                return RedirectToAction("Index","Car");
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Car/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Car/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Car/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public class CarInfo
        {
            public string Owner { get; set; }
            public string Brand { get; set; }
            public string Type { get; set; }
            public string Status { get; set; }
        }
    }
}