using Booking.RapidAPI.Models;

public class SearchBookingViewModel
{
    public string City { get; set; }
    public int Adults { get; set; } = 1;
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }

    public BookingViewModel Results { get; set; } // API cevabı
}
