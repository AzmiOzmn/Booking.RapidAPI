using Microsoft.AspNetCore.Mvc;

namespace Booking.RapidAPI.ViewComponents.Default
{
    public class _DefaultBookingComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
