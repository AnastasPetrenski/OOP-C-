using System;
using System.Collections.Generic;
using System.Text;

namespace CustomValidator
{
    public class RangeAttribute : Attribute
    {
        public RangeAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }

        public bool IsValid(int number)
        {
            return number >= this.Min && number <= this.Max;
        }
    }
}
