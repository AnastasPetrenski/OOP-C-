using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IModelable
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
