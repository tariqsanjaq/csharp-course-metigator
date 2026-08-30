/// <summary>
/// Contract for library items that can be checked out and returned.
/// </summary>
public interface IBorrowable
{
    /// <summary>Whether the item is currently available to borrow.</summary>
    bool IsAvailable { get; }

    /// <summary>The date the item is due back, or null if not currently borrowed.</summary>
    DateTime? DueDate { get; }

    /// <summary>Marks the item as borrowed by the given member.</summary>
    /// <param name="member">The member borrowing the item.</param>
    void Borrow(Member member);

    /// <summary>Marks the item as returned and available again.</summary>
    void Return();
}