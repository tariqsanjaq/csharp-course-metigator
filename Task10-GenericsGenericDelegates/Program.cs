using Task10_GenericsGenericDelegates;

internal class Program
{
    static void Main(string[] args)
    {
        Repository<Product> repo = new Repository<Product>();

        repo.AddItem(new Product(2, "orange juice", 2));
        repo.AddItem(new Product(3, "apple juice", 1));
        repo.AddItem(new Product(4, "manga juice", 3));
        repo.AddItem(new Product(5, "sturbary juice", 2));


        foreach (Product i in repo.GetAll())
        {
            Console.WriteLine(i);
        }


        Console.WriteLine(repo.GetById(2));
        Console.WriteLine(repo.GetById(0));

        Console.WriteLine(repo.Remove(5));
        Console.WriteLine(repo.Remove(0));

        foreach (Product i in repo.GetAll())
        {
            Console.WriteLine(i);
        }

        repo.Process(p => Console.WriteLine($"Processing: {p.Name}"));

        List<Product> cheap = repo.Filter(p => p.Price > 2);
        foreach (Product p in cheap)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("-------------------------------");

        Product product = repo.Search(p => p.Name == "apple juice");
        Product productNothing = repo.Search(p => p.Name == "sturbary");
        Console.WriteLine(product);
        Console.WriteLine(productNothing);



    }


}