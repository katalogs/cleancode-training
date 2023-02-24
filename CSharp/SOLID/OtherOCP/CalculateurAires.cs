using System.Collections.Generic;

namespace SOLID.OtherOCP
{
    public class CalculateurAires
    {
        public double SommeAires(IList<IFigure> figures)
        {
            var area = 0d;
            foreach (var figure in figures)
            {
                switch (figure)
                {
                    case Rectangle figureRectangle:
                    {
                        var rectangle = figureRectangle;
                        area += rectangle.Largeur * rectangle.Longueur;
                        break;
                    }
                    case Triangle figureTriangle:
                    {
                        var triangle = figureTriangle;
                        area += (double)(triangle.Base * triangle.Hauteur) / 2;
                        break;
                    }
                }
            }

            return area;
        }
    }
}