using System;
using System.Collections.Generic;
using System.Text;

namespace Task09_InheritanceInterfaces
{
    internal class Circle : Shape, IDrawable, IResizable
    {
        private double _radius;

        public double Radius { get => _radius; private set => _radius = value;  }
        public Circle(double radius)
        {
            _radius = radius;
        }

        public Circle(): this(0.0) 
        {          
        }

        public override double CalculateArea()
        {
            return 3.14*_radius*_radius;
        }

        public void Resize(double factor)
        {
            Radius *= factor;
        }

        public void Draw()
        {
            Console.WriteLine($"It's Circle\nAreaSize: {CalculateArea()}");
        }
    }
}
