using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/Booking").Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            List<Booking> data = JsonConvert.DeserializeObject<List<Booking>>(stringdata);
            return View(data);
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Booking us)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");

            string stringData = JsonConvert.SerializeObject(us);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("api/Booking", contentData).Result;
            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");


        }

        public IActionResult Detail(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/Booking/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            Booking data = JsonConvert.DeserializeObject<Booking>(stringdata);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/Booking/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            Booking data = JsonConvert.DeserializeObject<Booking>(stringdata);
            return View(data);
        }
        [HttpPost]

        public ActionResult Edit(Booking c)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            string stringData = JsonConvert.SerializeObject(c);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("/api/Booking/" + c.BookingId, contentData).Result;
            ViewBag.Meassage = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/Booking/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            Customer data = JsonConvert.DeserializeObject<Customer>(stringdata);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id, Booking c)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            string stringData = JsonConvert.SerializeObject(c);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync("/api/Booking/" + c.BookingId).Result;
            ViewBag.Meassage = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}