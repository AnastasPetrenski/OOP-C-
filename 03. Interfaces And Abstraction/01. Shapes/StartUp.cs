using System;
using System.Collections;
using System.Collections.Generic;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var collection = new List<IDrawable>();
            var radius = int.Parse(Console.ReadLine());
            IDrawable circle = new Circle(radius);

            var width = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            IDrawable rect = new Rectangle(width, height);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rect.Draw());

            collection.Add(new Circle(3));
            collection.Add(new Rectangle(8, 4));

            //foreach (var shape in collection)
            //{
            //    Console.WriteLine(shape.Draw());
            //}

        }
    }
}
