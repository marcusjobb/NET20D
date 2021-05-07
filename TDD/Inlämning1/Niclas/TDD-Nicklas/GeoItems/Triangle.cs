using TDD_Nicklas.Interfaces;
using TDD_Nicklas.Utility;

namespace TDD_Nicklas.GeoItems
{
    /// <summary>
    /// Calculate the area and radius of a triangle by entering its base and height.
    /// Ex. new Triangle(10, 15);
    /// </summary>
    public class Triangle : IGeoObjectable
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public Triangle(float _base, float height)
        {
            var isValid = CheckInput.IsValidNumber(_base, height);
            if (isValid)
            {
                this.Base = _base;
                this.Height = height;
            }
            else
            {
                this.Base = 0;
                this.Height = 0;
            }
        }

        public float GetArea() { return Base * Height / 2; }

        public float GetPerimeter() { return (Base * 2) + (Height * 2) / 2; }
    }
}