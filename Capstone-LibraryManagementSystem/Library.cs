
using System.Text.Json;
using System.Text.Json.Serialization;
/// <summary>
/// Orchestrates the library's catalog and membership — borrowing, returning,
/// searching, and persisting the whole collection to disk.
/// </summary>
public class Library
{

    private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve
    };
    /// <summary>Raised whenever a book is successfully borrowed.</summary>

    public event EventHandler<BookBorrowedEventArgs>? OnBookBorrowed;

    private List<Book> Books { get; } = new();
    private List<Member> Members { get; } = new();

    /// <summary>Adds a book to the catalog.</summary>
    /// <param name="book">The book to add.</param>

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    private T? FindById<T>(List<T> items, int id, Func<T, int> idSelector) where T : class
    {
        foreach (T item in items)
        {
            if (idSelector(item) == id)
            {
                return item;
            }
        }
        return null;
    }

    /// <summary>Borrows a book on behalf of a member and raises <see cref="OnBookBorrowed"/> on success.</summary>
    /// <param name="bookId">Id of the book to borrow.</param>
    /// <param name="memberId">Id of the borrowing member.</param>
    /// <exception cref="BookNotAvailableException">Thrown if no book matches <paramref name="bookId"/>, or it's already borrowed.</exception>
    /// <exception cref="MemberNotFoundException">Thrown if no member matches <paramref name="memberId"/>.</exception>

    [AuditLog("Borrows a book for a member")]
    public void BorrowBook(int bookId, int memberId)
    {
        Book? book = FindById(Books, bookId, b => b.Id);
        if (book == null)
        {
            throw new BookNotAvailableException("the book is not available");
        }

        Member? member = FindById(Members, memberId, m => m.Id);
        if (member == null)
        {
            throw new MemberNotFoundException("the member is not available");
        }

        book.Borrow(member);
        OnBookBorrowed?.Invoke(this, new BookBorrowedEventArgs(book, member, DateTime.Now));
    }

    /// <summary>Registers a new member with the library.</summary>
    /// <param name="member">The member to register.</param>

    public void RegisterMember(Member member)
    {
        Members.Add(member);
    }
    /// <summary>Returns a borrowed book, making it available again.</summary>
    /// <param name="bookId">Id of the book to return.</param>
    /// <exception cref="BookNotAvailableException">Thrown if no book matches <paramref name="bookId"/>.</exception>

    [AuditLog("Returns a book from a member")]
    public void ReturnBook(int bookId)
    {
        Book? book = FindById(Books, bookId, b => b.Id);
        if (book == null)
        {
            throw new BookNotAvailableException("the book not available");
        }
        book.Return();
    }
    /// <summary>Finds all books whose title or author matches the query.</summary>
    /// <param name="query">The search text.</param>
    /// <returns>Matching books, empty if none.</returns>

    public List<Book> SearchBooks(string query)
    {
        List<Book> results = new List<Book>();
        foreach (var book in Books)
        {
            if (book.Matches(query))
            {
                results.Add(book);
            }
        }
        return results;
    }
    /// <summary>Finds all members whose name matches the query.</summary>
    /// <param name="query">The search text.</param>
    /// <returns>Matching members, empty if none.</returns>

    public List<Member> SearchMembers(string query)
    {
        List<Member> results = new List<Member>();
        foreach (var member in Members)
        {
            if (member.Matches(query))
            {
                results.Add(member);
            }
        }
        return results;
    }
    /// <summary>Saves the current catalog and membership to a JSON file.</summary>
    /// <param name="path">File path to write to.</param>

    public async Task SaveAsync(string path)
    {
        LibraryData data = new LibraryData { Books = Books, Members = Members };
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            await System.Text.Json.JsonSerializer.SerializeAsync(stream, data, Options);
        }
    }
    /// <summary>Loads a catalog and membership from a JSON file, replacing the current contents.</summary>
    /// <param name="path">File path to read from.</param>

    public async Task LoadAsync(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            LibraryData? data = await System.Text.Json.JsonSerializer.DeserializeAsync<LibraryData>(stream, Options);
            if (data != null)
            {
                Books.Clear();
                Books.AddRange(data.Books);
                Members.Clear();
                Members.AddRange(data.Members);
            }
        }
    }


}
