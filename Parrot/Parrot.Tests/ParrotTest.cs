using Xunit;

namespace Parrot.Tests
{
    public class ParrotTest
    {
        [Fact]
        public void GetSpeedNorwegianBlueParrot_nailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 0, true);
            Assert.Equal(0.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 1.5, false);
            Assert.Equal(18.0, parrot.GetSpeed());
        }

        [Fact]
        public void GetSpeedNorwegianBlueParrot_not_nailed_high_voltage()
        {
            var parrot = new Parrot(ParrotTypeEnum.NORWEGIAN_BLUE, 0, 4, false);
            Assert.Equal(24.0, parrot.GetSpeed());
        }

        [Theory]
        [InlineData(0, 12.0)]
        [InlineData(1, 3.0)]
        [InlineData(2, 0.0)]
        public void GetSpeedOfAfricanParrot_With_No_Coconuts(int numberOfCoconuts, double speed)
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