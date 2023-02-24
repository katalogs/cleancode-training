using Xunit;

namespace SOLID.OpenClosePrinciple
{

    public class ItinerarySearchTest
    {

        private readonly ItinerarySearchEngine search = new ItinerarySearchEngine();

        [Fact]
        public void should_find_shortest_itinerary()
        {
            var trip = Trip.from(City.Paris).to(City.Tokyo);

            var shortest = search.OptimalItinerary(trip, i => i.Duration);

            Assert.NotNull(shortest);
            Assert.Equal("Direct flight", shortest.Label);
        }

        [Fact]
        public void should_find_lessConnection_itinerary()
        {
            var trip = Trip.from(City.Paris).to(City.Tokyo);

            var lessConnection = search.OptimalItinerary(trip, i => i.Connections);

            Assert.NotNull(lessConnection);
            Assert.Equal("Direct flight", lessConnection.Label);
        }

        [Fact]
        public void should_find_cheapest_itinerary()
        {
            var trip = Trip.from(City.Paris).to(City.Tokyo);

            var cheapest = search.OptimalItinerary(trip, i => i.Cost);

            Assert.NotNull(cheapest);
            Assert.Equal("With Dubai stopover", cheapest.Label);
        }

    }

}
