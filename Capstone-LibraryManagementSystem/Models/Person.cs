/// <summary>
/// Abstract base for anyone associated with the library — a person's
/// identity and contact info, shared by <see cref="Member"/> and <see cref="Librarian"/>.
/// </summary>
public abstract class Person
{
    /// <summary>Unique identifier, assigned once at construction.</summary>
    public int Id { get; }

    /// <summary>The person's full name.</summary>
    public string Name { get; protected set; }

    /// <summary>The person's email address.</summary>
    public string Email { get; protected set; }

    /// <summary>Creates a person with the given id, name, and email.</summary>
    /// <param name="id">Unique identifier for this person.</param>
    /// <param name="name">The person's full name.</param>
    /// <param name="email">The person's email address.</param>
    protected Person(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"id : {Id}\nName : {Name}\nEmail: {Email}";
    }
}