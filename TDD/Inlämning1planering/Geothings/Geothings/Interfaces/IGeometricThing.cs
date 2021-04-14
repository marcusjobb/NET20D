namespace Geothings.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGeometricThing
    {
        /// <summary>
        /// Gets the perimeter for the object
        /// </summary>
        /// <returns>The perimeter</returns>
        public abstract float GetPerimeter();
        /// <summary>
        /// Gets the area for the object
        /// </summary>
        /// <returns>Duh! The area</returns>
        public abstract float GetArea();
    }
}
