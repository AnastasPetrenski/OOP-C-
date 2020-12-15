using OpenCloseExampleDrawingShapes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleDrawingShapes
{
    class CircleDrawingManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;

            Console.WriteLine("this is circle");
        }
    }
}
