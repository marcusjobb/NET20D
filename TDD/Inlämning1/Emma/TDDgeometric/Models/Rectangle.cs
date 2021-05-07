namespace TDDgeometric.Models
{
    public class Rectangle : GeometricShapes
    {
        private float Base { get; set; }
        private float Height { get; set; }

        /// <summary>
        /// Sets the properties of the object
        /// </summary>
        /// <param name="Rbase">input data, rectangle base</param>
        /// <param name="height">input data, rectangle height</param>
        public Rectangle(float Rbase, float height)
        {
            Base = Rbase;
            Height = height;
        }

        public override float GetArea()
        {
            if (Base > 0 && Height > 0)
            {
                var result = Base * Height;
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }

        public override float GetPerimiter()
        {
            if (Base > 0 && Height > 0)
            {
                var result = (Base * 2) + (Height * 2);
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }
    }
}
