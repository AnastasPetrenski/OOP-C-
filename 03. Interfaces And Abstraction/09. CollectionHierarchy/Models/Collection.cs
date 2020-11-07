
namespace CollectionHierarchy.Models
{
    public abstract class Collection<T>
    {
        protected const int capacity = 100;
        protected int index = -1;
        protected T[] array;

        public Collection()
        {
            this.array = new T[capacity];
        }

        public int Count => this.array.Length;
    }
}
