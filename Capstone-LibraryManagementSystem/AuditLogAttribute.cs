/// <summary>
/// Marks a method as auditable. Adds metadata only — a reader like
/// reflection-based scanning is what acts on it.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class AuditLogAttribute : Attribute
{
    /// <summary>Human-readable description of what the audited method does.</summary>
    public string Description { get; }

    /// <summary>Creates the attribute with a description.</summary>
    /// <param name="description">What the audited method does.</param>
    public AuditLogAttribute(string description)
    {
        Description = description;
    }
}