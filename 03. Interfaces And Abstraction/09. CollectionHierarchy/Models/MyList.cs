using CollectionHierarchy.Common;
using System;

namespace CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>
    {
        //public override T Add(T element)

        public override T Remove()
        {
            if (index < 0)
            {
                throw new ArgumentException(message: String.Format(GlobalConstants.EmptyArrayExpMsg));
            }

            T returned = array[0];

            for (int i = 0; i < index; i++)
            {
                array[i] = array[i + 1];
            }

            array[index] = default;
            index--;

            return returned;
        }
    }
}
