namespace SOLID.Liskov
{
    public class Square : Rectangle
    {
        public override int Height
        {
            set => Side = value;
        }

        public override int Width
        {
            set => Side = value;
        }

        public int Side
        {
            get => Height;
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }
}