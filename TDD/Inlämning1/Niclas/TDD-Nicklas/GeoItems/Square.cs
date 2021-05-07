using TDD_Nicklas.Interfaces;
using TDD_Nicklas.Utility;

namespace TDD_Nicklas.GeoItems
{
    /// <summary>
    /// Calculate the area and radius of a square by entering its height and width.
    /// Ex. new Square(10, 15);
    /// </summary>
    public class Square : IGeoObjectable
    {
        public float Height { get; set; }
        public float Width { get; set; }

        public Square(float height, float width)
        {
            var isValid = CheckInput.IsValidNumber(height, width);
            if (isValid)
            {
                this.Height = height;
                this.Width = width;
            }
            else
            {
                this.Height = 0;
                this.Width = 0;
            }
        }

        public float GetArea() { return Height * Width; }

        public float GetPerimeter() { return (Height * 2) + (Width * 2); }
    }
}