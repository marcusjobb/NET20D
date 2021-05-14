namespace Geometri
{
    using System.Linq;

    public class Calculator
    {
    public double area { get; set; }
        public double Area(Shape[] shapes)
        {
            area = 0.0;

            if (shapes == null) return 0;
            foreach (var shape in from shape in shapes
                                  where shape != null
                                  select shape)
            {
                area += shape.Area();
            }

            return area;
        }
        public double Omkrets(Shape[] shapes)
        {
            var omkrets = 0.0;

            if (shapes == null) return 0;
            foreach (var shape in from shape in shapes
                                  where shape != null
                                  select shape)
            {
                omkrets += shape.Omkrets();
            }

            return omkrets;
        }
    }
}