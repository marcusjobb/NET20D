namespace TDD_inl_1.Geometry
{
    using Geothings.Extensions;
    using System;
    using TDD_inl_1.Interfaces;

    public class Triangle : IGeometric
    {
        // Set triangle sides a, b, c 
        public float SideA { get; set; }
        public float SideB { get; set; }
        public float SideC { get; set; }

        public Triangle(float a, float b, float c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }

        /// <summary>
        /// Find the area of any triangle using <see href="https://en.wikipedia.org/wiki/Heron%27s_formula">Heron's Formula</see>
        /// </summary>
        /// <returns>Area: <see cref="float"/></returns>
        public float GetArea()
        {
            if (IsTriangleExist())
            {
                var semiPerimeter = GetPerimeter() / 2;
                var area = MathF.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
                return MathExtensions.Round(area);
            }
            return 0;
        }

        /// <summary>
        /// Find the perimeter of any triangle
        /// </summary>
        /// <returns>Perimeter: <see cref="float"/></returns>
        public float GetPerimeter()
        {
            if (IsTriangleExist())
            {
                return MathExtensions.Round(SideA + SideB + SideC);
            }
            return 0;
        }


        /// <summary>
        /// Check if triandle exist with this sides.
        /// A triangle exists only when the sum of its two sides is greater than the third.
        /// </summary>
        /// <returns>True or false</returns>
        public bool IsTriangleExist()
        {
            if (SideA + SideB >= SideC)
            {
                if (SideB + SideC >= SideA)
                {
                    if (SideA + SideC >= SideB)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
