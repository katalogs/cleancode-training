using System;

namespace Parrot
{
    public class AfricanParrot : IParrot
    {
        private readonly int _numberOfCoconuts;
        private const double LoadFactor = 9.0;

        public AfricanParrot(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        } 

        public override double GetSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
        }
    }
}
