namespace Task15_CollectionsDataStructures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ContactManager manager = new ContactManager();

            Console.WriteLine("=== 1. List<Contact> ===");

            manager.Add(new Contact(1, "Tariq Sanjaq", "tariq@bestdev.com", "Amman"));
            manager.Add(new Contact(2, "Sara Ali", "sara@bestdev.com", "Amman"));
            manager.Add(new Contact(3, "Omar Nabil", "omar@bestdev.com", "Irbid"));
            manager.Add(new Contact(4, "Lina Tariq", "lina@bestdev.com", "Zarqa"));

            foreach (Contact contact in manager.GetAll())
                Console.WriteLine($"  {contact}");

            Console.WriteLine("\n-- Search --");
            foreach (Contact contact in manager.SearchByName("tar"))
                Console.WriteLine($"  found: {contact.Name}");

            Console.WriteLine($"  FindById(3) -> {manager.FindById(3)}");
            Console.WriteLine($"  FindById(99) -> {manager.FindById(99)}");


            Console.WriteLine("\n=== 2. Dictionary<string, List<Contact>> ===");
            // Print everyone in "Amman" using GetByCity.
            foreach (var item in manager.GetByCity("Amman"))
            {
                Console.WriteLine(item);
            }
            // Then try an unregistered city like "Aqaba" — note it returns an
            // empty list, not null, so foreach works without a null check.
           Console.WriteLine($"  Aqaba count -> {manager.GetByCity("Aqaba").Count}");
            


            Console.WriteLine("\n=== 3. HashSet<string> ===");
            bool added = manager.Add(new Contact(5, "Mohammed Ali", "tariq@bestdev.com", "Amman"));
            Console.WriteLine($"  Add duplicate email -> {added}");

            Console.WriteLine($"  IsEmailRegistered(tariq@bestdev.com) -> {manager.IsEmailRegistered("tariq@bestdev.com")}");
            Console.WriteLine($"  IsEmailRegistered(ghost@bestdev.com) -> {manager.IsEmailRegistered("ghost@bestdev.com")}");

            Console.WriteLine("\n=== 4. Stack<string> ===");
            // Call Undo three times and print each result.

            Console.WriteLine(manager.Undo());
            Console.WriteLine(manager.Undo());
            Console.WriteLine(manager.Undo());

            // Note the reverse order — the last action recorded comes out first (LIFO).
            

            Console.WriteLine("\n=== 5. Queue<string> ===");
            // Call QueueOperation three times with different strings.
            manager.QueueOperation("provide action ");
            manager.QueueOperation("provide action2 ");
            manager.QueueOperation("provide action3 ");
            // Then call ProcessNextOperation three times and print the results.
            Console.WriteLine($"  {manager.ProcessNextOperation()}");
            Console.WriteLine($"  {manager.ProcessNextOperation()}");
            Console.WriteLine($"  {manager.ProcessNextOperation()}");
            // Note the natural order — the first one queued comes out first (FIFO).


            Console.WriteLine("\n=== 6. LinkedList<Contact> ===");
            Contact? first = manager.FindById(1);
            Contact? second = manager.FindById(3);

            if (first != null && second != null)
            {
                manager.AddFavoriteLast(first);
                manager.AddFavoriteFirst(second);
            }

            foreach (Contact favorite in manager.GetFavorites())
                Console.WriteLine($"  {favorite.Name}");

            Console.WriteLine($"\n  RemoveFavorite(3) -> {manager.RemoveFavorite(3)}");

            foreach (Contact favorite in manager.GetFavorites())
                Console.WriteLine($"  {favorite.Name}");
        }
    }
}