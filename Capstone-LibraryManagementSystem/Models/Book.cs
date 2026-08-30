public class Book : IBorrowable, ISearchable
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public bool IsAvailable { get; private set; } = true;
    public DateTime? DueDate { get; private set; }
    public Member? BorrowedBy { get; private set; }

    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }


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
    public void Return()
    {
        BorrowedBy?.BorrowedBooks.Remove(this);
        IsAvailable = true;
        DueDate = null;
        BorrowedBy = null;
    }
    public bool Matches(string query)
    {
        return Title.Contains(query, StringComparison.OrdinalIgnoreCase) || Author.Contains(query, StringComparison.OrdinalIgnoreCase);


    }
}
