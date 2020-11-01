using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count > 0)
            {
                return false;
            }

            return true;
        }

        public void AddRange(IEnumerable<string> array)
        {
            foreach (var item in array)
            {
                this.Push(item);
            }
        }
    }
}
