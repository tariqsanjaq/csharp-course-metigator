using App;
using Core;
using Services;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductService service = new ProductService();

        service.Add(new Product(12, "milk", 1));
        service.Add(new Product(14, "orange", 2));
        service.Add(new Product(13, "apple", 1));

        Console.WriteLine("=== All products ===");
        PrintAll(service);

        Console.WriteLine("\n=== Remove ===");
        Console.WriteLine($"Remove(12) -> {service.Remove(12)}");
        Console.WriteLine($"Remove(99) -> {service.Remove(99)}");
        PrintAll(service);

        Console.WriteLine("\n=== Reflection scan ===");
        AuditScanner.Scan(typeof(ProductService).Assembly);
    }

    private static void PrintAll(ProductService service)
    {
        foreach (Product product in service.GetAll())
            Console.WriteLine($"  {product}");
    }
}