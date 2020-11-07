using CollectionHierarchy.Common;
using CollectionHierarchy.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection<T> : Collection<T>, IAddCollection<T>, IEnumerable<T>
    {
        public virtual int Add(T element)
        {
            if (++index >= array.Length)
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.IndexOutOfRangeExpMsg, nameof(Index), Count));
            }

            this.array[index] = element;

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= index; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
