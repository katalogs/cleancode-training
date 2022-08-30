using System;

namespace Parrot
{
    public class Parrot : IParrot
    {
        private readonly bool _isNailed;
        private readonly ParrotTypeEnum _type;
        private readonly double _voltage;
        private const double LoadFactor = 9.0;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public override double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return _isNailed ? 0 : GetBaseSpeed(_voltage);
                default:
                    throw new Exception("Should be unreachable");
            }
        }

        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(24.0, voltage * BaseSpeed);
        }
    }
}