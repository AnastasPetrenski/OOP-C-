using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IModelable
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
