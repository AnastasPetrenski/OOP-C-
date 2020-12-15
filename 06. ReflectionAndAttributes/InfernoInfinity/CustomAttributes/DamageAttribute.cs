using System;
using System.Collections.Generic;
using System.Text;

namespace InfernoInfinity.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DamageAttribute : Attribute
    {
        public DamageAttribute(int min, int max)
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
