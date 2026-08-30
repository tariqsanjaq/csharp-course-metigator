/// <summary>
/// A library book that can be borrowed, returned, and searched by title or author.
/// </summary>
public class Book : IBorrowable, ISearchable
{
    /// <summary>Unique identifier for this book.</summary>
    public int Id { get; }

    /// <summary>The book's title.</summary>
    public string Title { get; }

    /// <summary>The book's author.</summary>
    public string Author { get; }

    /// <inheritdoc/>
    public bool IsAvailable { get; private set; } = true;

    /// <inheritdoc/>
    public DateTime? DueDate { get; private set; }

    /// <summary>The member currently holding this book, or null if not borrowed.</summary>
    public Member? BorrowedBy { get; private set; }

    /// <summary>Creates a book with the given id, title, and author.</summary>
    /// <param name="id">Unique identifier for this book.</param>
    /// <param name="title">The book's title.</param>
    /// <param name="author">The book's author.</param>
    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    /// <inheritdoc/>
    /// <exception cref="BookNotAvailableException">Thrown if the book is already borrowed.</exception>
    public void Borrow(Member member)
    {
        if (!IsAvailable)
        {
            throw new BookNotAvailableException("The book is not available.");
        }
        else
        {
            IsAvailable = false;
            DueDate = DateTime.Now.AddDays(14);
            BorrowedBy = member;
            member.BorrowedBooks.Add(this);
        }
    }

    /// <inheritdoc/>
    public void Return()
    {
        BorrowedBy?.BorrowedBooks.Remove(this);
        IsAvailable = true;
        DueDate = null;
        BorrowedBy = null;
    }

    /// <inheritdoc/>
    public bool Matches(string query)
    {
        return Title.Contains(query, StringComparison.OrdinalIgnoreCase) || Author.Contains(query, StringComparison.OrdinalIgnoreCase);
    }
}