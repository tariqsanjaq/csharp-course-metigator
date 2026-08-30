
using System.Xml.Linq;

public class Library
{
    public event EventHandler<BookBorrowedEventArgs>? OnBookBorrowed;

    private List<Book> Books { get; } = new();
    private List<Member> Members { get; } = new();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    public void RegisterMember(Member member)
    {
        Members.Add(member);
    }
    public void BorrowBook(int bookId, int memberId)
    {
        bool bookFound = false;
        foreach (var item in Books)
        {
            if (item.Id == bookId)
            {
                bookFound = true;
                bool memberFound = false;
                foreach (var member in Members)
                {
                    if (member.Id == memberId)
                    {
                        memberFound = true;
                        item.Borrow(member);

                        OnBookBorrowed?.Invoke(this, new BookBorrowedEventArgs(item, member, DateTime.Now));
                        break;
                    }
                    
                }
                if (!memberFound)
                {
                    throw new MemberNotFoundException("the member is not available");

                }
                break;
            }
        }
        if (!   bookFound)
        {
            throw new BookNotAvailableException("the book is not avalable");
        }

    }   // raise OnBookBorrowed here
    public void ReturnBook(int bookId)
    {
        bool found = false;
        foreach (var item in Books)
        {
            
            if (item.Id == bookId)
            {
                found = true;
                item.Return();
                break;
            }
        }
        if (!found)
        {
            throw new BookNotAvailableException("the book not available");
        }
    }
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
    public async Task SaveAsync(string path)
    {
        LibraryData data = new LibraryData { Books = Books, Members = Members };
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            await System.Text.Json.JsonSerializer.SerializeAsync(stream, data);
        }
    }
    public async Task LoadAsync(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            LibraryData? data = await System.Text.Json.JsonSerializer.DeserializeAsync<LibraryData>(stream);
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
