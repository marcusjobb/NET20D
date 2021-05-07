namespace Inlamningsuppgift1TDD.Geometric
{
    using System;
    public class GeometricCalculator
    {
        /// <summary>
        /// Recieves a IGeometric object and calls the objects GetArea Method.
        /// Also rounds the return value to two decimals.
        /// </summary>
        /// <param name="geometricObj"></param>
        /// <returns>Area of object as type float</returns>
        public float GetArea(IGeometric geometricObj)
        {
            if(geometricObj != null)
            {
                return MathF.Round(geometricObj.GetArea(), 2);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Recieves a IGeometric object and calls the objects GetPerimeter Method.
        /// Also rounds the return value to two decimals.
        /// </summary>
        /// <param name="geometricObj"></param>
        /// <returns>Perimeter of object as type float</returns>
        public float GetPerimeter(IGeometric geometricObj)
        {
            if (geometricObj != null)
            {
                return MathF.Round(geometricObj.GetPerimeter(), 2);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Recieves an array of IGeometric objects and calls their respective GetPerimeter methods.
        /// Then return the total value of all objects parameters.
        /// Also rounds the return value to two decimals.
        /// </summary>
        /// <param name="geometricObjs"></param>
        /// <returns>Total perimeter of objects as type float</returns>
        public float GetPerimeter(IGeometric[] geometricObjs)
        {
            float totalPerimeter = 0;
            foreach(var geometric in geometricObjs)
            {
                if(geometric != null)
                {
                    totalPerimeter += geometric.GetPerimeter();
                }
            }
            return MathF.Round(totalPerimeter, 2);
        }
    }
}