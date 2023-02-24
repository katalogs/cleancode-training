using System;

namespace Parrot
{
    public class NorwegianBlueParrot: Parrot
    {
        private readonly bool _isNailed;
        private readonly double _voltage;

        public NorwegianBlueParrot(bool isNailed, double voltage)
        {
            _isNailed = isNailed;
            _voltage = voltage;
        }

        public override double GetSpeed()
        {
            return _isNailed ? 0 : Math.Min(24.0, _voltage * BaseSpeed);
        }
    }
}