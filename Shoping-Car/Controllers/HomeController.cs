using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System.Diagnostics;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("All", "Cars");
            //}
            // return View();

            return RedirectToAction("All", "Cars");

           // return View();
        }
        public IActionResult Privacy()
        {
            //if (User?.Identity?.IsAuthenticated ?? false)
            //{
            //    return RedirectToAction("All", "Cars");
            //}
            // return View();

            return RedirectToAction("All", "Cars");
        }
    }
}