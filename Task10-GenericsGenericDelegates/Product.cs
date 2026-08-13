using System;
using System.Collections.Generic;
using System.Text;

namespace Task10_GenericsGenericDelegates
{
    internal class Product : IEntity
    {
        private readonly int _id;
        private string _name;
        private decimal _price;

        public int Id => _id;
        public decimal Price { get => _price; private set { _price = value; } }
        public string Name { get => _name; private set { _name = value; } }

        public Product(int id , string name, decimal price)
        {
            _id = id;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}
