

public class MemberNotFoundException : LibraryException
{
    public MemberNotFoundException(string message) : base(message) { }
    public MemberNotFoundException(string message, Exception innerException) : base(message, innerException) { }


}
