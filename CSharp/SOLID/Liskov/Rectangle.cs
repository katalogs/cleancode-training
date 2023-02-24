namespace SOLID.Liskov
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public virtual int Area => Height * Width;
    }
}