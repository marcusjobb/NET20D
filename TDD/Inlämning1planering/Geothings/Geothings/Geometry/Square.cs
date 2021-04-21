//----------------------------------------------------------------------------------------------
// <copyright file="Square.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

namespace Geothings.Geometry
{
    using Geothings.Interfaces;

    /// <summary>
    /// Defines the <see cref="Square" />.
    /// </summary>
    public class Square : IGeometricThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Gets or sets the Side.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// The GetArea.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public override float GetArea()
        {
            return -1;
        }

        /// <summary>
        /// The GetPerimeter.
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public override float GetPerimeter()
        {
            return -1;
        }
    }
}
