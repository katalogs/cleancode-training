using Moq;
using SOLID.DependencyInversion.domain;
using SOLID.DependencyInversion.domain.booking;
using Xunit;

namespace SOLID.DependencyInversion
{
    public class BookingTest
    {
        private Mock<IAvailability> availabilities;
        private BookingService booking;

        public BookingTest()
        {
            availabilities = new Mock<IAvailability>();
            booking = new BookingService(availabilities.Object);
        }

        [Fact]
        public void should_book_when_available()
        {
            availabilities.Setup(a => a.IsAvailable()).Returns(true);
            BookingOutcome outcome = booking.Book();

            Assert.True(outcome.IsSuccessful());
        }

        [Fact]
        public void should_not_book_when_not_available()
        {
            availabilities.Setup(a => a.IsAvailable()).Returns(false);

            BookingOutcome outcome = booking.Book();

            Assert.False(outcome.IsSuccessful());
        }
    }
}