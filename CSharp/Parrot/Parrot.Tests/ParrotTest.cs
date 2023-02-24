using Xunit;

namespace Parrot.Tests
{
    public class ParrotTest
    {
        [Theory]
        [InlineData(true, 0, 0.0)]
        [InlineData(false, 1.5, 18.0)]
        [InlineData(false, 4, 24.0)]
        public void GetSpeedNorwegianBlueParrot(bool isNailed, double voltage, double speed)
        {
            var parrot = new NorwegianBlueParrot(isNailed, voltage);
            Assert.Equal(speed, parrot.GetSpeed());
        }

        [Theory]
        [InlineData(0, 12.0)]
        [InlineData(1, 3.0)]
        [InlineData(2, 0.0)]
        public void GetSpeedOfAfricanParrot(int numberOfCoconuts, double speed)
        {
            var parrot = new AfricanParrot(numberOfCoconuts);
            Assert.Equal(speed, parrot.GetSpeed());
        }  

        [Fact]
        public void GetSpeedOfEuropeanParrot()
        {
            var parrot = new EuropeanParrot();
            Assert.Equal(12.0, parrot.GetSpeed());
        }
    }
}