
public class Librarian : Person
{
    public string StaffId { get; }

    public Librarian(int id, string name, string email, string staffId) : base(id, name, email)
    { 
        StaffId = staffId; 
    }

    public void AddBook(Library library, Book book) { }
    public void RegisterMember(Library library, Member member) { }
}
