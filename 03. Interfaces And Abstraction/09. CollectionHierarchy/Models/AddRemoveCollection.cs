using CollectionHierarchy.Common;
using CollectionHierarchy.Interfaces;
using System;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
    {
        public override int Add(T element)
        {
            if (++index >= array.Length)
            {
                throw new ArgumentException(message: String.Format(GlobalConstants.IndexOutOfRangeExpMsg, nameof(Index), Count));
            }

            for (int i = index; i > 0; i--)
            {
                this.array[i] = this.array[i - 1];
            }

            this.array[0] = element;

            return 0;
        }

        public virtual T Remove()
        {
            if (index < 0)
            {
                throw new ArgumentException(message:String.Format(GlobalConstants.EmptyArrayExpMsg));
            }

            T x = array[index];

            array[index] = default;
            index--;

            return x;
        }
    }
}
