using Booking.RapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Booking.RapidAPI.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query=%C4%B0stanbul"),
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

            return View(values); // Mutlaka return et!
        }

    }
}
