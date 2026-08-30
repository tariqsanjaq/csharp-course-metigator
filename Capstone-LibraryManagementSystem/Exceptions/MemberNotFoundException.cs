
/// <summary>Base exception for all Member domain errors.</summary>

public class MemberNotFoundException : LibraryException
{
    /// <summary>Creates the exception with a message.</summary>
    /// <param name="message">Description of what went wrong.</param>
    public MemberNotFoundException(string message) : base(message) { }
    /// <summary>Creates the exception with a message and an inner exception.</summary>
    /// <param name="message">Description of what went wrong.</param>
    /// <param name="innerException">The exception that caused this one.</param>

    public MemberNotFoundException(string message, Exception innerException) : base(message, innerException) { }


}
