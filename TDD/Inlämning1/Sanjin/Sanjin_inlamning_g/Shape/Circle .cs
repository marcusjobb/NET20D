using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Shape
{
   public class Circle : GeometricThing
    {
       public float Radius { get; set; }
       /// <summary>
       /// Gets the radius of the object
       /// </summary>
       /// <param name="radius"></param>
       public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Gets the area of the circle
        /// </summary>
        /// <returns>Area</returns>
        public override float GetArea()
        {
            return (float) Math.PI * (Radius) * (Radius);
        }
        
        /// <summary>
        /// Gets the peramiters of the circle
        /// </summary>
        /// <returns>Perimeters</returns>
        public override float GetPerimeter()
        {
            return Radius * (float)Math.PI * 2;
        }
    }
}
