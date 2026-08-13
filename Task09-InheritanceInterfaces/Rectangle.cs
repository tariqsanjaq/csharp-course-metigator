using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    internal class Rectangle : Shape, IDrawable,IResizable
    {
        private double _length;
        private double _width;


        public double Width { get => _width; private set => _width= value; }
        public double Length { get => _length; private set => _length = value; }

        public Rectangle(double length , double width)
        {
            Width = width;
            Length = length;
        }

        public Rectangle() : this(0.0 , 0.0)
        {
        }

        public override double CalculateArea()
        {
            return Width*Length;
        }

        public void Resize(double factor)
        {
            Length *= factor;
            Width *= factor;

        }


        public void Draw()
        {
            Console.WriteLine($"It's Rectangle\nAreaSize: {CalculateArea()}");

        }

    }
}
