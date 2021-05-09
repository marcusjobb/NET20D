using System;
using System.Collections.Generic;
using System.Text;
using Geometry.Interfaces;
using Geometry.Models;

namespace Geometry.Controllers
{
    public class GeometricCalculator
    {
        public float GetArea(IShape shape)
        {
            try
            {
                float area = 0;
                if (shape.GetType() == typeof(Rectangle) && shape.Height > 0)
                {
                    area = shape.Height * shape.ShapeBase;
                }
                else if (shape.GetType() == typeof(Square) && shape.Height > 0)
                {
                    area = (float)Math.Pow(shape.Height, 2);
                }
                else if (shape.GetType() == typeof(Triangle) && shape.Height > 0)
                {
                    area = (shape.ShapeBase / 2) * shape.Height;
                }
                else if (shape.GetType() == typeof(Circle) && shape.Height > 0)
                {
                    var radius = shape.Height / 2;
                    area = shape.Pi * radius;
                }
                else
                {
                    Console.WriteLine("No shapes found");
                    Console.ReadLine();
                }

                if (area < 0)
                {
                    Console.WriteLine("Value needs to be greater than 0");
                    return 0;
                }
                return area;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public float GetPerimeter(IShape shape)
        {
            try
            {
                float perimeter = 0;
                if (shape.GetType() == typeof(Rectangle) && shape.Height > 0 && shape.ShapeBase > 0)
                {
                    perimeter = 2 * shape.Height + 2 * shape.ShapeBase;
                }
                else if (shape.GetType() == typeof(Square) && shape.Height > 0)
                {
                    perimeter = 4 * shape.Height;
                }
                else if (shape.GetType() == typeof(Triangle) && shape.Height > 0 && shape.ShapeBase > 0)
                {
                    var halfBase = shape.ShapeBase / 2;
                    var longSide = (float)Math.Sqrt(Math.Pow(shape.Height, 2) + Math.Pow(halfBase, 2));
                    perimeter = longSide + shape.ShapeBase + shape.Height;
                }
                else if (shape.GetType() == typeof(Circle) && shape.Height > 0)
                {
                    perimeter = shape.Height * (float)Math.Pow(shape.Pi, 2);
                }
                else
                {
                    Console.WriteLine("Value needs to be greater than 0");
                    Console.ReadLine();
                }


                return perimeter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("No shapes found");
                throw;
            }

        }

        public float GetPerimeter(List<IShape> shapes)
        {
            try
            {
                float totalPerimeter = 0;
                foreach (var shape in shapes)
                {
                    float perimeter = 0;
                    if (shape.GetType() == typeof(Rectangle))
                    {
                        perimeter = GetPerimeter(shape);
                    }
                    else if (shape.GetType() == typeof(Square))
                    {
                        perimeter = GetPerimeter(shape);
                    }
                    else if (shape.GetType() == typeof(Triangle))
                    {
                        perimeter = GetPerimeter(shape);
                    }
                    else if (shape.GetType() == typeof(Circle))
                    {
                        perimeter = GetPerimeter(shape);
                    }

                    totalPerimeter += perimeter;
                }

                return totalPerimeter;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
