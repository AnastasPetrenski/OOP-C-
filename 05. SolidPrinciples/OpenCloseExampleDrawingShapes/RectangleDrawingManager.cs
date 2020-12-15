using OpenCloseExampleDrawingShapes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleDrawingShapes
{
    public class RectangleDrawingManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var rectangle = shape as Rectangle;

            Console.WriteLine("this is rectangle");
        }
    }
}
