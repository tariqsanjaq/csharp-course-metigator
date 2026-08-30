/// <summary>
/// A library member who can borrow books and be found by name.
/// </summary>
public class Member : Person, ISearchable
{
    /// <summary>Books currently checked out by this member.</summary>
    public List<Book> BorrowedBooks { get; } = new List<Book>();

    /// <summary>Creates a member with the given id, name, and email.</summary>
    /// <param name="id">Unique identifier for this member.</param>
    /// <param name="name">The member's full name.</param>
    /// <param name="email">The member's email address.</param>
    public Member(int id, string name, string email) : base(id, name, email) { }

    /// <inheritdoc/>
    public bool Matches(string query)
    {
        return Name.Contains(query, StringComparison.OrdinalIgnoreCase);
    }
}