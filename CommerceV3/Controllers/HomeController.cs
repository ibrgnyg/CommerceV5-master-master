using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommerceV3.Models;
using CommerceV3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Net;

namespace CommerceV3.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext db;
		public HomeController(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
		{
			ViewBag.Slides = db.Slides.Where(s => s.IsPublished == true).OrderBy(o => o.Position).Take(10).ToList();
			ViewBag.Products = db.Products.Include(i => i.Category).Where(p => p.IsPublished == true).OrderByDescending(o => o.CreateDate).Take(8).ToList();

			//(form p in db.Products where p.IaPublished == true orderby (o=>o.Position).Take(10).Tolist();
			return View();
		}

		public IActionResult Contact()
		{
			ViewBag.Countries = new SelectList(db.Regions.Where(r => r.RegionType == RegionType.Country).OrderBy(o => o.Name).ToList(), "Id", "Name");
			return View();
		}
		[HttpPost]
		public IActionResult Contact(string fullName,string email, string country, string city, string subject,string message)
		{
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			client.UseDefaultCredentials = false;
			client.EnableSsl = true;
			client.Credentials = new NetworkCredential("ibrahimgnyg@gmail.com","350ngygng554");

			var countryName = db.Regions.FirstOrDefault(r => r.Id == country)?.Name;
			var cityName = db.Regions.FirstOrDefault(r => r.Id == city)?.Name;

			MailMessage mailMessage = new MailMessage();
			mailMessage.From = new MailAddress("ibrahimgnyg@gmail.com");
			mailMessage.To.Add("ibrahimgnyg@gmail.com");
			mailMessage.Body = "Tam Adı:" + fullName + "\nE-posta: " + email + "\nÜlke:" + country + "\nŞehir: " + city + "\nMesaj: " + message;
			mailMessage.Subject = "subject";
			client.Send(mailMessage);
			ViewBag.Message = "Mesajiniz başarıyla iletilmiştir. en kısa zaman da doneriz.";
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IEnumerable<Region> GetCities(string parentRegionId)
		{
			var result = db.Regions.Where(r => r.RegionType == RegionType.City && r.ParentRegionId == parentRegionId).OrderBy(o => o.Name).ToList();
			return result;
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
