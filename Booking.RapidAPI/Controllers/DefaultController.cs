using Microsoft.AspNetCore.Mvc;

namespace Booking.RapidAPI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
