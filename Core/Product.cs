namespace Core
{
    /// <summary>Product model — plain data, no behaviour.</summary>
    public class Product
    {
        private readonly int _id;

        public int Id => _id;
        public string Name { get; }
        public decimal Price { get; }

        public Product(int id, string name, decimal price)
        {
            _id = id;
            Name = name;
            Price = price;
        }

        public override string ToString() => $"Id: {Id}, Name: {Name}, Price: {Price}";
    }
}