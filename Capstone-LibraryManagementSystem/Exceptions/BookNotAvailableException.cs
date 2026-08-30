/// <summary>Base exception for all Book domain errors.</summary>

public class BookNotAvailableException : LibraryException 
{
    /// <summary>Creates the exception with a message.</summary>
    /// <param name="message">Description of what went wrong.</param>
    public BookNotAvailableException(string message) : base(message) { }

    /// <summary>Creates the exception with a message and an inner exception.</summary>
    /// <param name="message">Description of what went wrong.</param>
    /// <param name="innerException">The exception that caused this one.</param>
    public BookNotAvailableException(string message, Exception innerException) : base(message, innerException) { }

}
