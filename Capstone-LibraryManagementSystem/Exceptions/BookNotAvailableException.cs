
public class BookNotAvailableException : LibraryException 
{
    public BookNotAvailableException(string message) : base(message) { }
    public BookNotAvailableException(string message, Exception innerException) : base(message, innerException) { }

}
