using System.Collections.Generic;
using Xunit;

namespace SOLID.OtherOCP
{
    public class FigureTest
    {
        [Fact]
        public void CalculationTest()
        {
            List<IFigure> figures = new List<IFigure>
            {
                new Rectangle
                {
                    Largeur = 8,
                    Longueur = 6
                },
                new Triangle
                {
                    Base = 5,
                    Hauteur = 3,
                    Cote2 = 3,
                    Cote3 = 4
                }
            };
             
            Assert.Equal(55.5, new CalculateurAires().SommeAires(figures));
            Assert.Equal(40, new CalculateurPerimetres().SommePerimetres(figures));
            
        }
    }
}