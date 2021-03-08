using System;
using System.Xml.Serialization;

namespace Shapes
{
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class Shape
    {
        public string Color { get; set; }
        public double Radius { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area { get {return Height * Width;}
        }

    }

    public class Circle : Shape { }
    public class Rectangle : Shape { }
}
