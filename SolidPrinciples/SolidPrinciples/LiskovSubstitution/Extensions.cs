using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciples.LiskovSubstitution
{
    public static class Extensions
    {
        public static double Area(this Rectangle rectangle)
        {
            return rectangle.Width * rectangle.Height;
        }
    }
}
