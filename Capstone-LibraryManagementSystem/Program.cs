using System.Reflection;

Library library = new Library();

Book book1 = new Book(1, "Clean Code", "Robert Martin");
Book book2 = new Book(2, "The Pragmatic Programmer", "David Thomas");
Book book3 = new Book(3, "Design Patterns", "Gang of Four");

Member member1 = new Member(1, "Tariq Sanjaq", "tariq@bestdev.com");
Member member2 = new Member(2, "Sara Ali", "sara@bestdev.com");

library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);
library.RegisterMember(member1);
library.RegisterMember(member2);

library.OnBookBorrowed += (sender, e) =>
{
    Console.WriteLine($"[Event] {e.Member.Name} borrowed \"{e.Book.Title}\" at {e.BorrowedAt}");
};

library.BorrowBook(1, 1);

try
{
    library.BorrowBook(1, 1);   // already borrowed — should throw BookNotAvailableException
}
catch (BookNotAvailableException ex)
{
    Console.WriteLine($"[Expected] {ex.Message}");
}

try
{
    library.BorrowBook(2, 99);  // member 99 doesn't exist — should throw MemberNotFoundException
}
catch (MemberNotFoundException ex)
{
    Console.WriteLine($"[Expected] {ex.Message}");
}

library.ReturnBook(1);
Console.WriteLine($"After return, book1 available: {book1.IsAvailable}");

foreach (Book b in library.SearchBooks("code"))
    Console.WriteLine($"Found by title: {b.Title}");

foreach (Member m in library.SearchMembers("sara"))
    Console.WriteLine($"Found by name: {m.Name}");

await library.SaveAsync("library.json");
Console.WriteLine("Saved.");

Library reloaded = new Library();
await reloaded.LoadAsync("library.json");
Console.WriteLine($"Reloaded books: {reloaded.SearchBooks("").Count}");

Console.WriteLine("\n=== Audited methods ===");
foreach (var method in typeof(Library).GetMethods())
{
    var audit = method.GetCustomAttribute<AuditLogAttribute>();
    if (audit != null)
    {
        Console.WriteLine($"[AuditLog] {method.Name} — {audit.Description}");
    }
}