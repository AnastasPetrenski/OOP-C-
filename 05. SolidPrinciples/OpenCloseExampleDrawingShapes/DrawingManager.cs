using OpenCloseExampleDrawingShapes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleDrawingShapes
{
    public abstract class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            this.DrawFigure(shape);
        }

        protected abstract void DrawFigure(IShape shape);
    }
}
