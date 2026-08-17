using System.Collections.ObjectModel;
using Core;

namespace Services
{
    /// <summary>Business logic for products. Knows nothing about the UI.</summary>
    public class ProductService
    {
        private readonly List<Product> _products = new List<Product>();

        [AuditLog("Adds a new product to the store")]
        public void Add(Product product)
        {
            _products.Add(product);
        }

        [AuditLog("Removes a product by its id")]
        public bool Remove(int id)
        {
            Product? found = null;

            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    found = product;
                    break;
                }
            }

            if (found == null)
                return false;

            _products.Remove(found);
            return true;
        }

        // Intentionally NOT audited — read-only queries need no audit trail.
        public ReadOnlyCollection<Product> GetAll() => _products.AsReadOnly();
    }
}