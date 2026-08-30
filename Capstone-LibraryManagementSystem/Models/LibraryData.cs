// Person.cs
// Member.cs
// Librarian.cs
// Book.cs
// IBorrowable.cs
// ISearchable.cs
// BookBorrowedEventArgs.cs
// Library.cs — orchestrator, holds collections, raises event
// LibraryData.cs — JSON root, single file per your earlier call
public class LibraryData
{
    public List<Book> Books { get; set; }
    public List<Member> Members { get; set; }
}
