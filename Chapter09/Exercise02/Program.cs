using System;
using System.Collections.Generic;
using Shapes;
using System.Xml.Serialization;
using System.IO;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle {Color = "Red", Radius = 2.5},
                new Rectangle { Color = "Blue", Height = 20.0, Width = 10.0},
                new Circle { Color = "Green", Radius = 8.0},
                new Circle {Color = "Purple", Radius = 12.3},
                new Rectangle { Color = "Blue", Height = 45.0, Width = 18.0}
            };

      // create an object that knows how to serialize and deserialize 
      // a list of Shape objects
            var XMLSeralizer= new XmlSerializer(typeof(List<Shape>));

            string path = Combine(CurrentDirectory, "shapes.xml");

            FileStream xmlFile = File.Create(path);

            //saves to the file system
            XMLSeralizer.Serialize(xmlFile, listOfShapes);
            //release resources
            xmlFile.Dispose();

            xmlFile = File.Open(path, FileMode.Open);

            List<Shape> loadedShapesXML = XMLSeralizer.Deserialize(xmlFile) as List<Shape>;

            xmlFile.Dispose();

            foreach (Shape item in loadedShapesXML)
            {
                WriteLine($"{item.GetType().Name} is {item.Color} and ha an area of {item.Area}");
            }

        }
    }
}
