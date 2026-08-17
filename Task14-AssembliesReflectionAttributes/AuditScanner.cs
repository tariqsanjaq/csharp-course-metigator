using System.Reflection;
using Core;

namespace App
{
    /// <summary>
    /// Reads an assembly's metadata at runtime and reports every method
    /// carrying [AuditLog]. It never references those methods by name —
    /// new audited methods are picked up automatically.
    /// </summary>
    public static class AuditScanner
    {
        private const BindingFlags DeclaredPublicInstance =
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;

        public static void Scan(Assembly assembly)
        {
            Console.WriteLine($"Scanning assembly: {assembly.GetName().Name}");

            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine($"  Class: {type.Name}");

                foreach (MethodInfo method in type.GetMethods(DeclaredPublicInstance))
                {
                    AuditLogAttribute? audit = method.GetCustomAttribute<AuditLogAttribute>();

                    if (audit != null)
                        Console.WriteLine($"    [AuditLog] {method.Name} — {audit.Description}");
                }
            }
        }
    }
}
