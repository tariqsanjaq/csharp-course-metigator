using System;

namespace Core
{
    /// <summary>
    /// Marks a method as auditable. Adds metadata only — it does not change
    /// how the method behaves. A reader (see AuditScanner) is what acts on it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class AuditLogAttribute : Attribute
    {
        public string Description { get; }

        public AuditLogAttribute(string description)
        {
            Description = description;
        }
    }
}