
public class BookBorrowedEventArgs : EventArgs
{
    public Book Book { get; }
    public Member Member { get; }
    public DateTime BorrowedAt { get; }

    public BookBorrowedEventArgs(Book book, Member member, DateTime borrowedAt)
    {
        Book = book;
        Member = member;
        BorrowedAt = borrowedAt;
    }
}
