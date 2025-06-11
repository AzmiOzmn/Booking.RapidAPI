using Booking.RapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Booking.RapidAPI.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new SearchBookingViewModel
            {
                ArrivalDate = DateTime.Today,
                DepartureDate = DateTime.Today.AddDays(1),
                Adults = 1
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchBookingViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.City))
            {
                ModelState.AddModelError("City", "Lütfen şehir giriniz.");
                return View(model);
            }

            var client = new HttpClient();

            string url = $"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?" +
                         $"query={model.City}" +
                         $"&adults={model.Adults}" +
                         $"&arrival_date={model.ArrivalDate:yyyy-MM-dd}" +
                         $"&departure_date={model.DepartureDate:yyyy-MM-dd}";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "x-rapidapi-key", "2e50c62f72msh8300f24891bdde6p1dca80jsn87512fb40da1" },
                    { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonBody = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<BookingViewModel>(jsonBody);

            model.Results = values;

            return View(model);
        }
    }
}
