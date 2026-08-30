/// <summary>
/// Plain data container for serializing a library's full state to JSON —
/// the root object written by <see cref="Library.SaveAsync"/> and read by <see cref="Library.LoadAsync"/>.
/// </summary>
public class LibraryData
{
    /// <summary>All books in the library.</summary>
    public List<Book> Books { get; set; } = new();

    /// <summary>All members registered with the library.</summary>
    public List<Member> Members { get; set; } = new();
}