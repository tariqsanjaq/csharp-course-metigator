
using System.Collections.ObjectModel;

namespace Task10_GenericsGenericDelegates
{

    internal class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void AddItem(T item) => _items.Add(item);
        public bool Remove(int id)
        {
            T? found = default(T);
            bool exists = false;

            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    found = item;
                    exists = true;
                    break;
                }
            }

            if (!exists)
                return false;

            _items.Remove(found);
            return true;
        }
        public T GetById(int id)
        {
            foreach (T item in _items)
            {
                if (item.Id == id)
                {
                    return item;  
                }
            }

            return default(T);  
        }

        public ReadOnlyCollection<T> GetAll() => _items.AsReadOnly();


        public void Process(Action<T> action)
        {
            foreach (T item in _items)
            {
                action(item);
            }
        }
        public List<T> Filter(Func<T, bool> predicate)
        {
            List<T> results = new List<T>();

            foreach (T item in _items)
            {
                if (predicate(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public T Search(Predicate<T> match)
        {
            
            foreach (T item in _items)
            {
                if (match(item))
                {
                    return item;
                }
                
            }
            return default(T);
        }

    }
}