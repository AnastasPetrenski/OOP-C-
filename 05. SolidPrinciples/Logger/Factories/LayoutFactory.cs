using Logger.Models.Contracts;
using Logger.Models.Layouts;
using System;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            ILayout layout = type switch
            {
                "SimpleLayout" => new SimpleLayout(),
                "XmlLayout" => new XmlLayout(),
                "JsonLayout" => new JsonLayout(),
                _=> throw new ArgumentException("Invalid layout type!")
            };

            return layout;
        }
    }
}
