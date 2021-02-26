using System;
using static System.Console;

namespace Exercise02
{

    abstract class  Shape 
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual int Area { get; set; }

        public Shape (int height = 0, int width = 0)
        {
            Height = height;
            Width = width;
            Area = width * height;
        }
    }

    class Rectangle : Shape
    {

        public Rectangle(int height, int width) : base(height, width) {}
    }

    class Square : Shape
    {
        public Square(int height, int width) : base(height,width) {}
    }

    class Circle : Shape
    {

    }
    class Program
    {
        static void Main()
        {
            var r = new Rectangle(3,5);
            WriteLine($"Rectangle {r.Height} {r.Width} {r.Area}");
            var s = new Square(5, 5);
            WriteLine($"Rectangle {s.Height} {s.Width} {s.Area}");
        }


    }
}
