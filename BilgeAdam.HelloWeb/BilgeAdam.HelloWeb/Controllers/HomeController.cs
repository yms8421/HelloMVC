using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BilgeAdam.HelloWeb.Models;

namespace BilgeAdam.HelloWeb.Controllers
{
    public class HomeController : Controller
    {
        public static List<Person> PeopleList { get; set; }
        static HomeController()
        {
            PeopleList = new List<Person>
            {
                new Person("Can", "PERK") { BirthDate = new DateTime(1988,2,8) },
                new Person("Deniz", "ASLAN") { BirthDate = new DateTime(1996,6,21) },
                new Person("Gamze", "EFENDİOĞLU") { BirthDate = new DateTime(1982,4,29) },
                new Person("Gülşah", "DUMAN") { BirthDate = new DateTime(1998,3,30) },
                new Person("Ayşegül", "SARIKAYA") { BirthDate = new DateTime(1978,10,22) },
                new Person("Fatih", "ESER") { BirthDate = new DateTime(1997,4,29) },
                new Person("Mehmet", "İLHAN") { BirthDate = new DateTime(1981,6,11) },
                new Person("Ali", "ERCAN") { BirthDate = new DateTime(1992,5,21) }
            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult People()
        {
            return View(PeopleList);
        }

        public IActionResult Person(int id)
        {
            var p = PeopleList.FirstOrDefault(i => i.Id == id);
            if (p != null)
            {
                return View(p);
            }
            return RedirectToAction("People");
        }
    }
}
