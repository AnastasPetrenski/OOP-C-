using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCloseExampleDrawingShapes.Contracts
{
    public interface IDrawingManager : IShape
    {
        public void Draw(IShape shape); 
    }
}
