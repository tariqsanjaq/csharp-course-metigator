
public interface IBorrowable
{
    bool IsAvailable { get; }
    DateTime? DueDate { get; }
    void Borrow(Member member);
    
    void Return();
}
