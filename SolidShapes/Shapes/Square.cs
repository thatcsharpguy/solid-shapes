namespace SolidShapes.Shapes
{
    public class Square : Rectangle
    {
        private double _height;
        private double _width;

        public override double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                _width = value;
            }
        }

        public override double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                _height = value;
            }
        }
    }
}