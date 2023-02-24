namespace SOLID.OpenClosePrinciple
{

    public class Trip
    {

        private readonly City departure;
        private readonly City arrival;

        private Trip(City departure, City arrival)
        {
            this.departure = departure;
            this.arrival = arrival;
        }

        public static TripBuilder from(City departure)
        {
            return new TripBuilder(departure);
        }

        public class TripBuilder
        {
            private City departure;
            private City arrival;

            public TripBuilder(City departure)
            {
                this.departure = departure;
            }

            public Trip to(City arrival)
            {
                this.arrival = arrival;
                return new Trip(this.departure, this.arrival);
            }
        }
    }
}