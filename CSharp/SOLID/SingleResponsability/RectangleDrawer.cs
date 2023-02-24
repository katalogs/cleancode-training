using System.Drawing;

namespace SOLID.SingleResponsability
{
    public class RectangleDrawer
    {
        public Graphics graphics { get; set; }

        public RectangleDrawer(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public void Draw(Rectangle rectangle)
        {
            //top horizontal line
            graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.topLeft.Y,
                rectangle.bottomRight.X, rectangle.topLeft.Y
            );
            //bottom horizontal line
            graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.bottomRight.Y,
                rectangle.bottomRight.X, rectangle.bottomRight.Y
            );
            //left vertical line
            graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.topLeft.Y,
                rectangle.topLeft.X, rectangle.topLeft.Y - rectangle.Heigth
            );
            //right vertical line
            graphics.DrawLine(Pens.Black,
                rectangle.bottomRight.X, rectangle.bottomRight.Y - rectangle.Heigth,
                rectangle.bottomRight.X, rectangle.bottomRight.Y
            );
        }
    }
}
