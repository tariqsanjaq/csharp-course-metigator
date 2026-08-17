using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Task10_GenericsGenericDelegates
{
    /// <summary>
    /// A generic in-memory store for entities that carry a unique integer identifier.
    /// </summary>
    /// <typeparam name="T">
    /// The entity type held by this repository. Must implement <see cref="IEntity"/>
    /// so that items can be located by their <see cref="IEntity.Id"/>.
    /// </typeparam>
    /// <example>
    /// <code>
    /// Repository&lt;Product&gt; repo = new Repository&lt;Product&gt;();
    /// repo.AddItem(new Product(1, "Orange juice", 2m));
    /// Product p = repo.GetById(1);
    /// </code>
    /// </example>
    internal class Repository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        /// <summary>
        /// Adds an item to the repository.
        /// </summary>
        /// <param name="item">The entity to store. Duplicate identifiers are not checked.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="item"/> is null.</exception>
        /// <example>
        /// <code>
        /// repo.AddItem(new Product(2, "Apple juice", 1m));
        /// </code>
        /// </example>
        public void AddItem(T item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _items.Add(item);
        }

        /// <summary>
        /// Removes the first item whose identifier matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The identifier of the entity to remove.</param>
        /// <returns>
        /// <c>true</c> if a matching item was found and removed; otherwise <c>false</c>.
        /// </returns>
        /// <example>
        /// <code>
        /// bool removed = repo.Remove(5);   // true if id 5 existed
        /// </code>
        /// </example>
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

            _items.Remove(found!);   // safe: 'exists' guarantees 'found' was assigned
            return true;
        }

        /// <summary>
        /// Finds the first item with the given identifier.
        /// </summary>
        /// <param name="id">The identifier to search for.</param>
        /// <returns>
        /// The matching entity, or <c>default(T)</c> when no match exists
        /// (<c>null</c> for reference types).
        /// </returns>
        /// <example>
        /// <code>
        /// Product p = repo.GetById(3);
        /// if (p is null) { /* not found */ }
        /// </code>
        /// </example>
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

        /// <summary>
        /// Returns every stored item as a read-only view.
        /// </summary>
        /// <returns>
        /// A <see cref="ReadOnlyCollection{T}"/> wrapping the internal list. The caller
        /// cannot add or remove through it, but later changes to the repository are visible.
        /// </returns>
        /// <example>
        /// <code>
        /// foreach (Product p in repo.GetAll()) Console.WriteLine(p);
        /// </code>
        /// </example>
        public ReadOnlyCollection<T> GetAll() => _items.AsReadOnly();

        /// <summary>
        /// Runs the supplied action once for every item in the repository.
        /// </summary>
        /// <param name="action">The operation to perform on each item.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="action"/> is null.</exception>
        /// <example>
        /// <code>
        /// repo.Process(p =&gt; Console.WriteLine(p.Name));
        /// </code>
        /// </example>
        public void Process(Action<T> action)
        {
            ArgumentNullException.ThrowIfNull(action);

            foreach (T item in _items)
            {
                action(item);
            }
        }

        /// <summary>
        /// Returns every item that satisfies the given condition.
        /// </summary>
        /// <param name="predicate">The test applied to each item.</param>
        /// <returns>
        /// A new list containing the matching items. Empty when nothing matches — never null.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="predicate"/> is null.</exception>
        /// <example>
        /// <code>
        /// List&lt;Product&gt; expensive = repo.Filter(p =&gt; p.Price &gt; 2m);
        /// </code>
        /// </example>
        public List<T> Filter(Func<T, bool> predicate)
        {
            ArgumentNullException.ThrowIfNull(predicate);

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

        /// <summary>
        /// Returns the first item that satisfies the given condition.
        /// </summary>
        /// <param name="match">The test applied to each item.</param>
        /// <returns>
        /// The first matching entity, or <c>default(T)</c> when nothing matches.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="match"/> is null.</exception>
        /// <example>
        /// <code>
        /// Product p = repo.Search(x =&gt; x.Name == "Apple juice");
        /// </code>
        /// </example>
        public T Search(Predicate<T> match)
        {
            ArgumentNullException.ThrowIfNull(match);

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