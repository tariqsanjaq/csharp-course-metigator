/// <summary>
/// Event data describing a completed book borrow, passed to <see cref="Library.OnBookBorrowed"/> subscribers.
/// </summary>
public class BookBorrowedEventArgs : EventArgs
{
    /// <summary>The book that was borrowed.</summary>
    public Book Book { get; }

    /// <summary>The member who borrowed it.</summary>
    public Member Member { get; }

    /// <summary>When the borrow occurred.</summary>
    public DateTime BorrowedAt { get; }

    /// <summary>Creates the event data for a completed borrow.</summary>
    /// <param name="book">The book that was borrowed.</param>
    /// <param name="member">The member who borrowed it.</param>
    /// <param name="borrowedAt">When the borrow occurred.</param>
    public BookBorrowedEventArgs(Book book, Member member, DateTime borrowedAt)
    {
        Book = book;
        Member = member;
        BorrowedAt = borrowedAt;
    }
}