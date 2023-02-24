namespace SOLID.DependencyInversion.domain.booking
{
    public class BookingService
    {
        private readonly IAvailability bookings;

        public BookingService(IAvailability bookings)
        {
            this.bookings = bookings;
        }

        public BookingOutcome Book()
        {
            bool successful = bookings.IsAvailable();
            return new BookingOutcome(successful);
        }
    }
}