using System;

namespace Parrot
{
    public class Parrot
    {
        private readonly bool _isNailed;
        private readonly int _numberOfCoconuts;
        private readonly ParrotTypeEnum _type;
        private readonly double _voltage;
        private const double LoadFactor = 9.0;
        private const double BaseSpeed = 12.0;

        public Parrot(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            _type = type;
            _numberOfCoconuts = numberOfCoconuts;
            _voltage = voltage;
            _isNailed = isNailed;
        }

        public double GetSpeed()
        {
            switch (_type)
            {
                case ParrotTypeEnum.EUROPEAN:
                    return BaseSpeed;
                case ParrotTypeEnum.AFRICAN:
                    return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
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