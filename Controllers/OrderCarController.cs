using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class OrderCarController : Controller
    {
        public IConfiguration Configuration;
        public ApplicationDbContext AppDbContext { get; set; }

        public OrderCarController(IConfiguration configuration, ApplicationDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Configuration = configuration;
        }
        // GET: OrderCar
        [Authorize]
        public ActionResult Index(string id)
        {
            var x = from car in AppDbContext.Cars where car.id == Guid.Parse(id) select car;
            ViewBag.Detail = x;
            return View("OrderCar");
        }

        // GET: OrderCar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderCar/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: OrderCar/Create
        [HttpPost]
        public async Task<IActionResult> Payment(string Fullname,string Cars_id,string Email,string Location,DateTime Mulai,DateTime Selesai,int Driver,string Total_Price,string bank_type,string paymentMethod)
        {
            try
            {
                Console.WriteLine("masuk sini");
                var user_id = HttpContext.Session.GetString("Id");
                var client = new HttpClient();
                Console.WriteLine(Fullname + Email+ paymentMethod+ Total_Price+ bank_type);
                var transaksi = FormatPay( Fullname, Email, paymentMethod,Total_Price, bank_type);
                var hasil = new StringContent(transaksi, Encoding.UTF8, "application/json");
                var token = Encoding.ASCII.GetBytes("SB-Mid-server-3xaB-yb0Px1mIPnaPLeNFXIF:");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(token));
                var response = await client.PostAsync("https://api.sandbox.midtrans.com/v2/charge", hasil);
                var json = response.Content.ReadAsStringAsync().Result;
                var data_purchase = JsonConvert.DeserializeObject<Transaction_Details>(json);
                AppDbContext.Add(data_purchase);
                AppDbContext.SaveChanges();
                Transaction purchase = new Transaction()
                {
                    nama_pemesan = Fullname,
                    email = Email,
                    cars_id = Guid.Parse(Cars_id),
                    transaction_id = data_purchase.id,
                    location = Location,
                    driver = Driver,
                    User_id = Guid.Parse(user_id),
                    used_at = Mulai,
                    returned_at = Selesai,
                    created_at = DateTime.Now,

                };
                AppDbContext.Add(purchase);
                AppDbContext.SaveChanges();
                var carid = Guid.Parse(Cars_id);
                var x = AppDbContext.Cars.Find(carid);
                x.status = "Booked";
                AppDbContext.SaveChanges();
                var pembayaran = (from pur in AppDbContext.Transactions where pur.User_id == Guid.Parse(user_id) orderby pur.transaction_id descending select pur.Transaction_Details).FirstOrDefault();
                var va = (from v in AppDbContext.Transactions where v.User_id == Guid.Parse(user_id) orderby v.transaction_id descending select v.Transaction_Details.va_numbers).FirstOrDefault();
                ViewBag.Va = va;
                ViewBag.Detail = pembayaran;
                return View("Receipt");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderCar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderCar/Edit/5
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

        // GET: OrderCar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderCar/Delete/5
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

        public string FormatPay(string FullName, string email, string paymentMethod,string total_cart, string bank_type)
        {
            Console.WriteLine(total_cart);
            var user_id = HttpContext.Session.GetString("Id");
            var data = "";
            if (paymentMethod == "gopay")
            {
                var transaksi = new
                {
                    payment_type = paymentMethod,
                    transaction_details = new
                    {
                        order_id = "Order" + "-" + "G" + user_id,
                        gross_amount = total_cart
                    },
                    gopay = new
                    {
                        enable_callback = true,
                        callback_url = "someapps://callback"
                    }
                };
                data = JsonConvert.SerializeObject(transaksi);
                return data;
            }
            if (paymentMethod == "bank_transfer")
            {
                if (bank_type == "bca")
                {
                    var transaksi = new
                    {
                        payment_type = paymentMethod,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + "BCA" + user_id,
                            gross_amount = total_cart
                        },
                        customer_details = new
                        {
                            email = email
                        },
                        bank_transfer = new
                        {
                            bank = bank_type
                        }
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "echannel")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + "MAN" + user_id,
                            gross_amount = total_cart
                        },
                        echannel = new
                        {
                            bill_info1 = "Payment For:",
                            bill_info2 = "debt"
                        }
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "bni")
                {
                    var transaksi = new
                    {
                        payment_type = paymentMethod,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" +  "BNI" + user_id,
                            gross_amount = total_cart
                        },
                        customer_details = new
                        {
                            email = email
                        },
                        bank_transfer = new
                        {
                            bank = bank_type
                        }
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "permata")
                {
                    Console.WriteLine(bank_type);
                    var transaksi = new
                    {
                        payment_type = paymentMethod,
                        bank_transfer = new
                        {
                            bank = bank_type,
                            permata = new
                            {
                                recepient_name = FullName
                            }
                        },
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + "Per" + user_id,
                            gross_amount = int.Parse(total_cart)
                        },
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    Console.WriteLine(data);
                    return data;
                }

            }
            if (paymentMethod == "direct_debit")
            {
                if (bank_type == "bca_klikpay")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + user_id,
                            gross_amount = total_cart
                        },
                        bca_klikpay = new
                        {
                            description = "Pembelian"
                        }
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "cimb_clicks")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" +user_id,
                            gross_amount = total_cart
                        },
                        cimb_clicks = new
                        {
                            description = "Pembelian"
                        }
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "danamon_online")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + user_id,
                            gross_amount = total_cart
                        },
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "bri_epay")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + user_id,
                            gross_amount = total_cart
                        },
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
                if (bank_type == "akulaku")
                {
                    var transaksi = new
                    {
                        payment_type = bank_type,
                        transaction_details = new
                        {
                            order_id = "Order" + "-" + user_id,
                            gross_amount = total_cart
                        },
                    };
                    data = JsonConvert.SerializeObject(transaksi);
                    return data;
                }
            }
            return data;
        }
    }
}