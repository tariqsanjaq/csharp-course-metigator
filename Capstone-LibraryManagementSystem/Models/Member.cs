
public class Member : Person, ISearchable
{
    public List<Book> BorrowedBooks { get; } = new List<Book>();

    public Member(int id, string name, string email) : base(id, name, email) { }
    public bool Matches(string query)
    {
        return Name.Contains(query, StringComparison.OrdinalIgnoreCase);
    }

}
