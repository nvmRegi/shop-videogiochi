using Microsoft.AspNetCore.Mvc;
using Shop_Videogiochi.Models;
using System.Diagnostics;

namespace Shop_Videogiochi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}