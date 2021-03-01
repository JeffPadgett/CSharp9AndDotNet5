using System;
using System.Xml.Linq;
using static System.Console;
using DialectSoftware.Collections;
using DialectSoftware.Collections.Generics;

namespace AssembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Axis("x", 0, 10, 1);
            var y = new Axis("y", 0, 4, 1);
            var matrix = new Matrix<long>(new[] {x, y});
        }
    }
}
