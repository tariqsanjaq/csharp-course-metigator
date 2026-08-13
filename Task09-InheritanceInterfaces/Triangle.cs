using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    internal class Triangle : Shape, IDrawable, IResizable
    {
        private double _base;
        private double _height;


        public double Base { get => _base; private set => _base = value; }
        public double Height { get => _height; private set => _height = value; }

        public Triangle(double baseTriangle, double hight)
        {
            Base = baseTriangle;
            Height = hight;
        }

        public Triangle() : this(0.0, 0.0)
        {
        }

        public override double CalculateArea()
        {
            return 0.5* Base * Height;
        }

        public void Resize(double factor)
        {
            Base *= factor;
            Height *= factor;

        }


        public void Draw()
        {
            Console.WriteLine($"It's Triangle\nAreaSize: {CalculateArea()}");

        }

    }
}



