using Microsoft.AspNetCore.Mvc;

namespace Shop_Videogiochi.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
