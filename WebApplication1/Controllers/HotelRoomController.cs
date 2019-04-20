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
    public class HotelRoomController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            HttpResponseMessage response = client.GetAsync("/api/HotelRoom").Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            List<HotelRoom> data = JsonConvert.DeserializeObject<List<HotelRoom>>(stringdata);
            return View(data);
        }

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind ("RoomType","RoomPrice", "RoomDescription","RoomImage")] HotelRoom us)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61076");

                string stringData = JsonConvert.SerializeObject(us);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("api/HotelRoom", contentData).Result;
                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            return View(us);

        }

        public IActionResult Detail(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/HotelRoom/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            HotelRoom data = JsonConvert.DeserializeObject<HotelRoom>(stringdata);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/HotelRoom/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            HotelRoom data = JsonConvert.DeserializeObject<HotelRoom>(stringdata);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind ("RoomType","RoomPrice", "RoomDescription","RoomImage")] HotelRoom hotel)
        {
            if(ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:61076");
                string stringData = JsonConvert.SerializeObject(hotel);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync("/api/HotelRoom/" + hotel.RoomId, contentData).Result;
                ViewBag.Meassage = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            HttpResponseMessage response = client.GetAsync("/api/HotelRoom/" + id).Result;
            string stringdata = response.Content.ReadAsStringAsync().Result;
            HotelRoom data = JsonConvert.DeserializeObject<HotelRoom>(stringdata);
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int id,HotelRoom hotel)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:61076");
            string stringData = JsonConvert.SerializeObject(hotel);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync("/api/HotelRoom/" + hotel.RoomId).Result;
            ViewBag.Meassage = response.Content.ReadAsStringAsync().Result;
            return RedirectToAction("Index");
        }
    }
}