using System;
using System.Drawing;

namespace SOLID.SingleResponsability
{
    public class Rectangle
    {
        public readonly Point topLeft;
        public readonly Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
            if (Width <= 0) throw new ArgumentException($"topLeft {topLeft} is not to the left of bottomRight ({bottomRight})");
            if (Heigth <= 0) throw new ArgumentException($"topLeft({topLeft}) is not to the top of bottomRight({bottomRight})");
        }

        public int Perimeter => 2 * (Width + Heigth);
        public int Area => Width * Heigth;
        public int Width => bottomRight.X - topLeft.X;
        public int Heigth => topLeft.Y - bottomRight.Y;
    }


}
