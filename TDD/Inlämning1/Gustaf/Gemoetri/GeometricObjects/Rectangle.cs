namespace Geometri.GeometricObjects
{
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// Constructor that takes two arguments, length and height
        /// </summary>
        /// <param name="length">Length parameter</param>
        /// <param name="height">Height parameter</param>
        public Rectangle(float length, float height) : base(length, height)
        {
            if (ValidateInput(length))
            {
                Length = length;
            }
            else
                Length = 1.0f;
            if (ValidateInput(height))
            {
                Height = height;
            }
            else
                Height = 1.0f;
        }
    }
}
