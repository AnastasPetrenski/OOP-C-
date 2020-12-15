using MyLogger.Models.Contracts;
using MyLogger.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLogger.Factories
{
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            ILayout layout = type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                //"XmlLayout" => new XmlLayout(),
                //"JsonLayout" => new JsonLayout(),
                _ => throw new ArgumentException("Invalid layout type!")
            };

            return layout;
        }
    }
}
