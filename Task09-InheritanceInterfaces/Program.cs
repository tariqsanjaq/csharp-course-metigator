using Task09_InheritanceInterfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        //Circle circle = new Circle(32.3);
        //Rectangle rectangle = new Rectangle(12, 34);
        //Triangle triangle = new Triangle(32.2,31);

        //Console.WriteLine(circle.CalculateArea());
        //Console.WriteLine(rectangle.CalculateArea());
        //Console.WriteLine(triangle.CalculateArea());

        //circle.Resize(1.2);
        //rectangle.Resize(2.1);
        //triangle.Resize(1.4);

        //circle.Draw();
        //rectangle.Draw();
        //triangle.Draw();

        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle(21.1));
        shapes.Add(new Rectangle(12.3,12));
        shapes.Add(new Triangle(21,2));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Area: {shape.CalculateArea()}");

            if (shape is IResizable r)
            {
                r.Resize(1.3);
            }
            if (shape is IDrawable d)
            {
                d.Draw();
            }
        }


    }
}