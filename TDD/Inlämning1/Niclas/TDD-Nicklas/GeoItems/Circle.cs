using System;
using TDD_Nicklas.Interfaces;
using TDD_Nicklas.Utility;

namespace TDD_Nicklas.GeoItems
{
    /// <summary>
    /// Calculate the area and radius of a circle by entering its radius.
    /// Ex. new Circle(3);
    /// </summary>
    public class Circle : IGeoObjectable
    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            var isValid = CheckInput.IsValidNumber(radius);
            if (isValid) { this.Radius = radius; }
            else { this.Radius = 0; }
        }

        public float GetArea() { return MathF.PI * MathF.Pow(Radius, 2); }

        public float GetPerimeter() { return 2 * MathF.PI * Radius; }
    }
}