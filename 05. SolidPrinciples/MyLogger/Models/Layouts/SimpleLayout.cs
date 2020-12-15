using MyLogger.Models.Contracts;
using MyLogger.Models.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLogger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => this.GetFormat();

        private string GetFormat()
        {
            return "{0} - {1} - {2}";
        }
    }
}
