using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class LoginController : Controller
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public LoginController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(string Username, string Email, string Password, int Status)
        {
            try
            {
                string mysalt = BCrypt.Net.BCrypt.GenerateSalt();
                var BPassword = BCrypt.Net.BCrypt.HashPassword(Password, mysalt);
                User User = new User()
                {
                    username = Username,
                    email = Email,
                    password = BPassword,
                    status = Status,
                    created_at = DateTime.Now,
                };
                AppDbContext.Users.Add(User);
                AppDbContext.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Login(string Email,string Password)
        {
            try
            {
                IActionResult response = Unauthorized();
                var user = AuthenticatedUser(Email, Password);
                if (user != null)
                {
                    Console.WriteLine(user.status);
                    if (user.status == 1)
                    {
                        var token = GenerateJwtToken(user);                       
                        HttpContext.Session.SetString("JWTToken", token);
                        HttpContext.Session.SetString("Id", user.id.ToString());
                        HttpContext.Session.SetString("Status", user.status.ToString());
                        HttpContext.Session.SetString("Name", user.username.ToString());
                        var get = HttpContext.Session.GetString("JWTToken");
                        Console.WriteLine(get);
                        return RedirectToAction("Index", "Home");

                    }
                    if (user.status == 2)
                    {
                        var token = GenerateJwtToken(user);
                        HttpContext.Session.SetString("JWTToken", token);
                        HttpContext.Session.SetString("Id", user.id.ToString());
                        HttpContext.Session.SetString("Status", user.status.ToString());
                        HttpContext.Session.SetString("Name", user.username.ToString());

                        var get = HttpContext.Session.GetString("JWTToken");
                        return RedirectToAction("Index", "Car");
                    }
                    if (user.status == 3)
                    {
                        var token = GenerateJwtToken(user);
                        HttpContext.Session.SetString("JWTToken", token);
                        HttpContext.Session.SetString("Id", user.id.ToString());
                        HttpContext.Session.SetString("Status", user.status.ToString());
                        HttpContext.Session.SetString("Name", user.username.ToString());

                        var get = HttpContext.Session.GetString("JWTToken");
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();
                // TODO: Add update logic here
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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

        private string GenerateJwtToken(User user)
        {
            var secuityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(secuityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                // new Claim(JwtRegisteredClaimNames.Sub,user.username),
                new Claim(JwtRegisteredClaimNames.Sub,Convert.ToString(user.email)),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Configuration["Jwt:Issuer"],
                audience: Configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedToken;
        }

        private User AuthenticatedUser(string Email, string Password)
        {
            User user = null;
            var x = (from data in AppDbContext.Users where data.email == Email orderby data.id select new { data.username, data.password, data.id, data.status, data.email }).LastOrDefault();
            var verify = BCrypt.Net.BCrypt.Verify(Password, x.password);
            if (x.email == Email && (verify == true))
            {
                user = new User
                {
                    id = x.id,
                    status = x.status,
                    username = x.username,
                    email = Email,
                    password = x.password,
                };
            }
            return user;
        }
    }
}