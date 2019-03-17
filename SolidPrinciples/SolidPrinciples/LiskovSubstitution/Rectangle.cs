using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciples.LiskovSubstitution
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Rectangle (Width: {Width}, Height: {Height})";
        }
    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set => base.Width = base.Height = value;
        }

        public override int Height
        {
            set => base.Width = base.Height = value;
        }

        public Square(int width)
            : base(width, width)
        {
        }
    }
}
