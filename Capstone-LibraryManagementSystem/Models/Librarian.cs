/// <summary>
/// A staff member who manages the book catalog.
/// </summary>
public class Librarian : Person
{
    /// <summary>The librarian's staff identifier.</summary>
    public string StaffId { get; }

    /// <summary>Creates a librarian with the given id, name, email, and staff id.</summary>
    /// <param name="id">Unique identifier for this librarian.</param>
    /// <param name="name">The librarian's full name.</param>
    /// <param name="email">The librarian's email address.</param>
    /// <param name="staffId">The librarian's staff identifier.</param>
    public Librarian(int id, string name, string email, string staffId) : base(id, name, email)
    {
        StaffId = staffId;
    }
    /// <summary>Adds a book to the given library's catalog.</summary>
    /// <param name="library">The library to add the book to.</param>
    /// <param name="book">The book to add.</param>
    public void AddBook(Library library, Book book)
    {
        library.AddBook(book);
    }

    /// <summary>Registers a member with the given library.</summary>
    /// <param name="library">The library to register the member with.</param>
    /// <param name="member">The member to register.</param>
    public void RegisterMember(Library library, Member member)
    {
        library.RegisterMember(member);
    }
}